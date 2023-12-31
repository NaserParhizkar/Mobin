﻿namespace Kendo.Mvc.UI
{
    using Extensions;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ModelDescriptor : JsonObject
    {
        public ModelDescriptor(Type modelType, IModelMetadataProvider modelMetadataProvider)
        {
            var metadata = modelMetadataProvider.GetMetadataForType(modelType);
            Fields = Translate(metadata);
        }

        public IList<ModelFieldDescriptor> Fields { get; }

        public IDataKey Id { get; set; }
        public DataSource ChildrenDataSource
        {
            get;
            set;
        }

        public string ChildrenMember
        {
            get;
            set;
        }

        public string HasChildrenMember
        {
            get;
            set;
        }

        public ModelFieldDescriptor AddDescriptor(string member)
        {

            var descriptor = Fields.FirstOrDefault(f => f.Member == member);
            if (descriptor != null)
            {
                return descriptor;
            }

            descriptor = new ModelFieldDescriptor { Member = member };
            Fields.Add(descriptor);

            return descriptor;
        }

        protected override void Serialize(IDictionary<string, object> json)
        {
            if (Id != null)
            {
                json["id"] = Id.Name;
            }

            json.Add("hasChildren", HasChildrenMember, HasChildrenMember.HasValue);

            if (ChildrenDataSource != null)
            {
                json["children"] = ChildrenDataSource.ToJson();
            }
            else if (ChildrenMember.HasValue())
            {
                json["children"] = ChildrenMember;
            }

            if (Fields.Count > 0)
            {
                var fields = new Dictionary<string, object>();
                json["fields"] = fields;

                Fields.Each(prop =>
                {
                    var field = new Dictionary<string, object>();
                    fields[prop.Member] = field;

                    if (!prop.IsEditable)
                    {
                        field["editable"] = false;
                    }

                    field["type"] = prop.MemberType.ToJavaScriptType().ToLowerInvariant();

                    if (prop.MemberType.IsNullableType() || prop.DefaultValue != null)
                    {
                        var defaultValue = prop.DefaultValue;

                        if (prop.MemberType.IsEnumType() && defaultValue is Enum)
                        {
                            var underlyingType = Enum.GetUnderlyingType(prop.MemberType.GetNonNullableType());
                            defaultValue = Convert.ChangeType(defaultValue, underlyingType);
                        }
                        field["defaultValue"] = defaultValue;
                    }

                    if (!string.IsNullOrEmpty(prop.From))
                    {
                        field["from"] = prop.From;
                    }

                    if (prop.IsNullable)
                    {
                        field["nullable"] = prop.IsNullable;
                    }

                    if (prop.Parse.HasValue())
                    {
                        field["parse"] = prop.Parse;
                    }
                });
            }
        }

        private IList<ModelFieldDescriptor> Translate(ModelMetadata metadata)
        {
            return metadata.Properties
                .Select(p => new ModelFieldDescriptor
                {
                    Member = p.PropertyName,
                    MemberType = p.ModelType,
                    IsEditable = !p.IsReadOnly
                }).ToList();
        }

        private object CreateDataItem(Type modelType)
        {
            return Activator.CreateInstance(modelType);
        }
    }

    internal static class ModelDescriptorExtentions
    {
        public static bool IsReadOnly(this DataSource dataSource, string fieldName)
        {
            return dataSource.Schema.Model.Fields.Any(f => f.Member == fieldName && !f.IsEditable);
        }
    }
}
