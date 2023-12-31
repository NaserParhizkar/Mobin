namespace Kendo.Mvc.Infrastructure
{
    using Kendo.Mvc.Extensions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;

    [KnownType(typeof(AggregateFunctionsGroup))]
    public class AggregateFunctionsGroup : Group
    {
        /// <summary>
        /// Gets or sets the aggregate functions projection for this group. 
        /// This projection is used to generate aggregate functions results for this group.
        /// </summary>
        /// <value>The aggregate functions projection.</value>
        [JsonIgnore]
        public object AggregateFunctionsProjection { get; set; }

        public IDictionary<string, object> Aggregates
        {
            get
            {
                if (AggregateFunctionsProjection != null)
                {
                    var values = ExtractPropertyValues(AggregateFunctionsProjection);
                    var aggregates = values.GroupBy(entry =>
                    {
                        var startIndex = entry.Key.IndexOf('_');
                        return entry.Key.Substring(startIndex + 1);
                    });

                    return aggregates.ToDictionary(g => g.Key, g => (object)g.ToDictionary(entry => entry.Key.Split('_').First(), entry => entry.Value));
                }

                return new Dictionary<string, object>();
            }
        }

        /// <summary>
        /// Gets the aggregate results generated for the given aggregate functions.
        /// </summary>
        /// <value>The aggregate results for the provided aggregate functions.</value>
        /// <exception cref="ArgumentNullException"><c>functions</c> is null.</exception>
        public AggregateResultCollection GetAggregateResults(IEnumerable<AggregateFunction> functions)
        {
            if (functions == null)
            {
                throw new ArgumentNullException("functions");
            }

            var resultCollection = new AggregateResultCollection();

            if (this.AggregateFunctionsProjection == null)
            {
                return resultCollection;
            }

            var propertyValues = ExtractPropertyValues(AggregateFunctionsProjection);
            var results = CreateAggregateResultsForPropertyValues(functions, propertyValues);

            resultCollection.AddRange(results);

            return resultCollection;
        }

        private static IEnumerable<AggregateResult> CreateAggregateResultsForPropertyValues(
            IEnumerable<AggregateFunction> functions, IDictionary<string, object> propertyValues)
        {
            foreach (var function in functions)
            {
                string propertyName = function.FunctionName;
                if (propertyValues.ContainsKey(propertyName))
                {
                    var value = propertyValues[propertyName];
                    var result = new AggregateResult(value, function);

                    yield return result;
                }
            }
        }

        private static IDictionary<string, object> ExtractPropertyValues(object obj)
        {
            return (from p in obj.GetType().GetProperties()
                    let value = p.GetValue(obj, null)
                    select new { Key = p.Name, Value = value }).ToDictionary(pair => pair.Key, pair => pair.Value);
        }
    }
}