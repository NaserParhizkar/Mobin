﻿using Kendo.Mvc.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;

namespace Kendo.Mvc.Infrastructure
{
    public class JavaScriptInitializer : IJavaScriptInitializer
    {
        //Escape meta characters: http://api.jquery.com/category/selectors/
        private static readonly Regex EscapeRegex = new Regex(@"([;&,\.\+\*~'\:\""\!\^\$\[\]\(\)\|\/])", RegexOptions.Compiled);

        public virtual string Initialize(string id, string name, IDictionary<string, object> options)
        {
            return InitializeFor(EscapeRegex.Replace(id, @"\\$1"), name, options);
        }

        public virtual string InitializeFor(string selector, string name, IDictionary<string, object> options)
        {
            return new StringBuilder().Append("kendo.syncReady(function(){jQuery(\"")
                .Append(selector)
                .Append("\").kendo")
                .Append(name)
                .Append("(")
                .Append(Serialize(options))
                .Append(");});")
                .ToString();
        }

        public virtual IJavaScriptSerializer CreateSerializer()
        {
            return new DefaultJavaScriptSerializer();
        }

        public virtual string Serialize(IDictionary<string, object> @object)
        {
            var output = new StringBuilder();

            output.Append("{");

            foreach (var keyValuePair in @object)
            {
                var value = keyValuePair.Value;
                var @string = value as string;

                if (@string != null)
                {
                    if (keyValuePair.Key == "dataSourceId")
                    {
                        output.Append(",\"dataSource\":");
                        output.Append(@string.JavaScriptStringEncode(false));
                        continue;
                    }
                    else if (keyValuePair.Key == "dependenciesId")
                    {
                        output.Append(",\"dependencies\":");
                        output.Append(@string.JavaScriptStringEncode(false));
                        continue;
                    }
                }

                output.Append(",")
                      .Append("\"" + keyValuePair.Key + "\"")
                      .Append(":");

                if (@string != null)
                {
                    output.Append(@string.JavaScriptStringEncode(true));
                    continue;
                }

                var dictionary = value as IDictionary<string, object>;

                if (dictionary != null)
                {
                    output.Append(Serialize(dictionary));

                    continue;
                }

                var dates = value as IEnumerable<DateTime>;

                if (dates != null)
                {
                    AppendDates(output, dates);

                    continue;
                }

                var nested = value as IEnumerable<IDictionary<string, object>>;

                if (nested != null)
                {
                    AppendArrayOfObjects(output, nested);
                    continue;
                }

                var serializer = CreateSerializer();

                var enumerable = value as IEnumerable;

                if (enumerable != null)
                {
                    output.Append(serializer.Serialize(enumerable));

                    continue;
                }

                if (value is bool)
                {
                    AppendBoolean(output, (bool)value);

                    continue;
                }

                if (value is DateTime)
                {
                    AppendDate(output, (DateTime)value);

                    continue;
                }

                if (value is int)
                {
                    output.Append((int)value);

                    continue;
                }

                if (value is double)
                {
                    output.Append(((double)value).ToString("r", CultureInfo.InvariantCulture));

                    continue;
                }

                if (value is float)
                {
                    output.Append(((float)value).ToString("r", CultureInfo.InvariantCulture));

                    continue;
                }

                if (value is Guid)
                {
                    output.AppendFormat("\"{0}\"", value.ToString());

                    continue;
                }

                if (value == null)
                {
                    output.Append("null");

                    continue;
                }

                if (value.GetType().GetTypeInfo().IsPrimitive || value is decimal)
                {
                    AppendConvertible(output, value);
                    continue;
                }

                var @event = value as ClientHandlerDescriptor;

                if (@event != null)
                {
                    AppendEvent(output, @event);

                    continue;
                }

                if (value is Enum)
                {
                    output.Append(value.ToString().ToLower().JavaScriptStringEncode(true));

                    continue;
                }

                output.Append(serializer.Serialize(value));
            }

            if (output.Length >= 2)
            {
                output.Remove(1, 1); // Remove the first comma
            }

            output.Append("}");

            return output.ToString();
        }

        private void AppendBoolean(StringBuilder output, bool value)
        {
            if (value)
            {
                output.Append("true");
            }
            else
            {
                output.Append("false");
            }
        }

        private void AppendEvent(StringBuilder output, ClientHandlerDescriptor value)
        {
            if (value.HandlerName.HasValue())
            {
                output.Append(value.HandlerName);
            }
            else if (value.TemplateDelegate != null)
            {
                using (var writer = new StringWriter())
                {
                    writer.WriteContent(value.TemplateDelegate, HtmlEncoder.Default, value);
                    output.Append(writer.ToString());
                }
            }
        }

        private void AppendDates(StringBuilder output, IEnumerable<DateTime> dates)
        {
            output.Append("[");

            if (dates.Any())
            {
                foreach (var date in dates)
                {
                    AppendDate(output, date);
                    output.Append(",");
                }

                output.Remove(output.Length - 1, 1);
            }

            output.Append("]");
        }

        private void AppendArrayOfObjects(StringBuilder output, IEnumerable<IDictionary<string, object>> array)
        {
            output.Append("[");

            if (array.Any())
            {
                foreach (var obj in array)
                {
                    output.Append(Serialize(obj));
                    output.Append(",");
                }

                output.Remove(output.Length - 1, 1);
            }

            output.Append("]");
        }

        private void AppendDate(StringBuilder output, DateTime value)
        {
            output.Append("new Date(")
                  .Append(value.Year)
                  .Append(",")
                  .Append(value.Month - 1)
                  .Append(",")
                  .Append(value.Day)
                  .Append(",")
                  .Append(value.Hour)
                  .Append(",")
                  .Append(value.Minute)
                  .Append(",")
                  .Append(value.Second)
                  .Append(",")
                  .Append(value.Millisecond)
                  .Append(")");
        }

        private void AppendConvertible(StringBuilder output, object value)
        {
            output.Append(Convert.ToString(value, CultureInfo.InvariantCulture));
        }
    }
}