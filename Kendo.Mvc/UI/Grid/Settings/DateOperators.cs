﻿using Kendo.Mvc.Resources;
using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    public class DateOperators : JsonObject
    {
        public DateOperators()
        {
            Operators = new Dictionary<string, string>()
            {
                { "eq", Messages.Filter_DateIsEqualTo },
                { "neq", Messages.Filter_DateIsNotEqualTo },
                { "gte", Messages.Filter_DateIsGreaterThanOrEqualTo },
                { "gt", Messages.Filter_DateIsGreaterThan },
                { "lte", Messages.Filter_DateIsLessThanOrEqualTo},
                { "lt", Messages.Filter_DateIsLessThan },
                { "isnotnull", Messages.Filter_DateIsNotNull }
            };
        }

        protected override void Serialize(IDictionary<string, object> json)
        {
            bool dirty = false;

            if (Operators.Count != DefaultDateOfFilters)
            {
                dirty = true;
            }

            if (Operators.ContainsKey("eq") && Operators["eq"] != DefaultIsEqualTo)
            {
                dirty = true;
            }

            if (Operators.ContainsKey("neq") && Operators["neq"] != DefaultIsNotEqualTo)
            {
                dirty = true;
            }

            if (Operators.ContainsKey("gte") && Operators["gte"] != DefaultIsGreaterThanOrEqualTo)
            {
                dirty = true;
            }

            if (Operators.ContainsKey("gt") && Operators["gt"] != DefaultIsGreaterThan)
            {
                dirty = true;
            }

            if (Operators.ContainsKey("lte") && Operators["lte"] != DefaultIsLessThanOrEqualTo)
            {
                dirty = true;
            }
            if (Operators.ContainsKey("lt") && Operators["lt"] != DefaultIsLessThan)
            {
                dirty = true;
            }

            if (Operators.ContainsKey("isnull") && Operators["isnull"] != DefaultIsNull)
            {
                dirty = true;
            }

            if (Operators.ContainsKey("isnotnull") && Operators["isnotnull"] != DefaultIsNotNull)
            {
                dirty = true;
            }

            if (dirty)
            {
                foreach (var keyValue in Operators)
                {
                    json[keyValue.Key] = keyValue.Value;
                }
            }
        }

        public IDictionary<string, string> Operators { get; private set; }

        private const int DefaultDateOfFilters = 8;

        private const string DefaultIsEqualTo = "Is equal to";
        private const string DefaultIsNotEqualTo = "Is not equal to";
        private const string DefaultIsGreaterThanOrEqualTo = "Is after or equal to";
        private const string DefaultIsGreaterThan = "Is after";
        private const string DefaultIsLessThanOrEqualTo = "Is before or equal to";
        private const string DefaultIsLessThan = "Is before";
        private const string DefaultIsNull = "Is null";
        private const string DefaultIsNotNull = "Is not null";
    }
}
