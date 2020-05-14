using Kendo.Mvc.Extensions;
using Kendo.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Threading.Tasks;

namespace Kendo.Mvc.UI
{
    public class DataSourceRequestModelBinder : IModelBinder
    {
        public virtual Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var request = CreateDataSourceRequest(bindingContext.ModelMetadata, bindingContext.ValueProvider, bindingContext.ModelName);

            bindingContext.Result = ModelBindingResult.Success(request);

            return Task.CompletedTask;
        }

        private static void TryGetValue<T>(ModelMetadata modelMetadata, IValueProvider valueProvider, string modelName, string key, Action<T> action)
        {
            if (modelMetadata.BinderModelName.HasValue())
            {
                key = modelName + "-" + key;
            }

            var value = valueProvider.GetValue(key);

            if (value != null && value.FirstValue != null)
            {
                object obj = value.ConvertValueTo(typeof(T));
                if (obj != null)
                {
                    action((T)((object)obj));
                }
            }
        }

        public static DataSourceRequest CreateDataSourceRequest(ModelMetadata modelMetadata, IValueProvider valueProvider, string modelName)
        {
            var request = new DataSourceRequest();

            TryGetValue(modelMetadata, valueProvider, modelName, DataSourceRequestUrlParameters.Sort, (string sort) =>
                request.Sorts = DataSourceDescriptorSerializer.Deserialize<SortDescriptor>(sort)
            );

            TryGetValue(modelMetadata, valueProvider, modelName, DataSourceRequestUrlParameters.Page, (int currentPage) => request.Page = currentPage);

            TryGetValue(modelMetadata, valueProvider, modelName, DataSourceRequestUrlParameters.PageSize, (int pageSize) => request.PageSize = pageSize);

            TryGetValue(modelMetadata, valueProvider, modelName, nameof(DataSourceRequest.WidgetId), (Guid widgetId) => request.WidgetId = widgetId);

            TryGetValue(modelMetadata, valueProvider, modelName, nameof(DataSourceRequest.AutoMakeQueryExpression),
                (bool autoMakeQueryExpression) => request.AutoMakeQueryExpression = autoMakeQueryExpression);

            TryGetValue(modelMetadata, valueProvider, modelName, DataSourceRequestUrlParameters.Filter, (string filter) =>
                request.Filters = FilterDescriptorFactory.Create(filter)
            );

            TryGetValue(modelMetadata, valueProvider, modelName, DataSourceRequestUrlParameters.Group, (string group) =>
                request.Groups = DataSourceDescriptorSerializer.Deserialize<GroupDescriptor>(group)
            );

            TryGetValue(modelMetadata, valueProvider, modelName, DataSourceRequestUrlParameters.Aggregates, (string aggregates) =>
                request.Aggregates = DataSourceDescriptorSerializer.Deserialize<AggregateDescriptor>(aggregates)
            );

            return request;
        }
    }
}