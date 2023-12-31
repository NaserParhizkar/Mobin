namespace Kendo.Mvc.Extensions
{
    using Kendo.Mvc.Infrastructure.Implementation;
    using System.Collections.Generic;

    public static class FilterTokenExtensions
    {
        private static readonly IDictionary<string, FilterOperator> tokenToOperator = new Dictionary<string, FilterOperator>
        {
            { "eq", FilterOperator.IsEqualTo },
            { "neq", FilterOperator.IsNotEqualTo },
            { "lt", FilterOperator.IsLessThan },
            { "lte", FilterOperator.IsLessThanOrEqualTo },
            { "gt", FilterOperator.IsGreaterThan },
            { "gte", FilterOperator.IsGreaterThanOrEqualTo },
            { "startswith", FilterOperator.StartsWith },
            { "contains", FilterOperator.Contains },
            { "notsubstringof", FilterOperator.DoesNotContain },
            { "endswith", FilterOperator.EndsWith },
            { "doesnotcontain", FilterOperator.DoesNotContain },
            { "isnotnull", FilterOperator.IsNotNull },
            { "isnull", FilterOperator.IsNull },
            { "isempty", FilterOperator.IsEmpty },
            { "isnotempty", FilterOperator.IsNotEmpty }
        };

        private static readonly IDictionary<FilterOperator, string> operatorToToken = new Dictionary<FilterOperator, string>
        {
            { FilterOperator.IsEqualTo, "eq" },
            { FilterOperator.IsNotEqualTo, "neq" },
            { FilterOperator.IsLessThan, "lt" },
            { FilterOperator.IsLessThanOrEqualTo, "lte" },
            { FilterOperator.IsGreaterThan, "gt" },
            { FilterOperator.IsGreaterThanOrEqualTo, "gte" },
            { FilterOperator.StartsWith, "startswith" },
            { FilterOperator.Contains, "contains" },
            { FilterOperator.DoesNotContain,"notsubstringof" },
            { FilterOperator.EndsWith, "endswith" },
            { FilterOperator.IsNotNull, "isnotnull" },
            { FilterOperator.IsNull, "isnull" },
            { FilterOperator.IsEmpty, "isempty" },
            { FilterOperator.IsNotEmpty, "isnotempty" }
        };

        public static FilterOperator ToFilterOperator(this FilterToken token)
        {
            return tokenToOperator[token.Value];
        }

        public static string ToToken(this FilterOperator filterOperator)
        {
            return operatorToToken[filterOperator];
        }
    }
}
