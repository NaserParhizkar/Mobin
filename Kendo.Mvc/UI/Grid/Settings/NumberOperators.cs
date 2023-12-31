﻿using Kendo.Mvc.Resources;
using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    public class NumberOperators : JsonObject
    {
        public NumberOperators()
        {
            Operators = new Dictionary<string, string>()
            {
                { "eq", Messages.Filter_NumberIsEqualTo },
                { "neq", Messages.Filter_NumberIsNotEqualTo },
                { "gte", Messages.Filter_NumberIsGreaterThanOrEqualTo },
                { "gt", Messages.Filter_NumberIsGreaterThan },
                { "lte", Messages.Filter_NumberIsLessThanOrEqualTo},
                { "lt", Messages.Filter_NumberIsLessThan },
                { "isnull", Messages.Filter_NumberIsNull },
                { "isnotnull", Messages.Filter_NumberIsNotNull }
            };
        }

        protected override void Serialize(IDictionary<string, object> json)
        {
            bool dirty = false;

            if (Operators.Count != DefaultNumberOfFilters)
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

        private const int DefaultNumberOfFilters = 8;

        private const string DefaultIsEqualTo = "Is equal to";
        private const string DefaultIsNotEqualTo = "Is not equal to";
        private const string DefaultIsGreaterThanOrEqualTo = "Is greater than or equal to";
        private const string DefaultIsGreaterThan = "Is greater than";
        private const string DefaultIsLessThanOrEqualTo = "Is less than or equal to";
        private const string DefaultIsLessThan = "Is less than";
        private const string DefaultIsNull = "Is null";
        private const string DefaultIsNotNull = "Is not null";
    }
}
