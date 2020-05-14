using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Mobin.Common.Expressions;
using System;
using System.Globalization;
using System.Linq.Expressions;
using System.Reflection;

namespace Kendo.Mvc.Infrastructure
{
    internal static class ExpressionMetadataProvider
    {
        public static ModelExplorer FromLambdaExpression<TModel, TResult>(Expression<Func<TModel, TResult>> expression,
            ViewDataDictionary<TModel> viewData, IModelMetadataProvider metadataProvider)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }
            if (viewData == null)
            {
                throw new ArgumentNullException("viewData");
            }
            string text = null;
            Type type = null;
            bool flag = false;
            switch (expression.Body.NodeType)
            {
                case ExpressionType.ArrayIndex:
                    flag = true;
                    break;
                case ExpressionType.Call:
                    flag = ExpressionHelper.IsSingleArgumentIndexer(expression.Body);
                    break;
                case ExpressionType.MemberAccess:
                    {
                        MemberExpression memberExpression = (MemberExpression)expression.Body;
                        text = ((memberExpression.Member is PropertyInfo) ? memberExpression.Member.Name : null);
                        if (string.Equals(text, "Model", StringComparison.Ordinal) && memberExpression.Type == typeof(TModel) && memberExpression.Expression.NodeType == ExpressionType.Constant)
                        {
                            return FromModel(viewData, metadataProvider);
                        }
                        type = memberExpression.Expression?.Type;
                        flag = true;
                        break;
                    }
                case ExpressionType.Parameter:
                    return FromModel(viewData, metadataProvider);
            }
            if (!flag)
            {
                throw new InvalidOperationException("");
            }
            ModelMetadata modelMetadata = null;
            if (type != null && text != null)
            {
                modelMetadata = metadataProvider.GetMetadataForType(type).Properties[text];
            }
            if (modelMetadata == null)
            {
                modelMetadata = metadataProvider.GetMetadataForType(typeof(TResult));
            }

            return viewData.ModelExplorer.GetExplorerForExpression(modelMetadata, viewData.ModelExplorer.Model);
        }

        public static ModelExplorer FromStringExpression(string expression, ViewDataDictionary viewData, IModelMetadataProvider metadataProvider)
        {
            if (viewData == null)
            {
                throw new ArgumentNullException("viewData");
            }
            ViewDataInfo viewDataInfo = ViewDataEvaluator.Eval(viewData, expression);
            if (viewDataInfo == null)
            {
                ModelExplorer explorerForProperty = viewData.ModelExplorer.GetExplorerForProperty(expression);
                if (explorerForProperty != null)
                {
                    return explorerForProperty;
                }
            }
            if (viewDataInfo != null)
            {
                if (viewDataInfo.Container == viewData && viewDataInfo.Value == viewData.Model && string.IsNullOrEmpty(expression))
                {
                    return FromModel(viewData, metadataProvider);
                }
                ModelExplorer modelExplorer = viewData.ModelExplorer;
                if (viewDataInfo.Container != null)
                {
                    modelExplorer = metadataProvider.GetModelExplorerForType(viewDataInfo.Container.GetType(), viewDataInfo.Container);
                }
                if (viewDataInfo.PropertyInfo != null)
                {
                    ModelMetadata metadata = metadataProvider.GetMetadataForType(viewDataInfo.Container.GetType()).Properties[viewDataInfo.PropertyInfo.Name];
                    Func<object, object> modelAccessor = (object ignore) => viewDataInfo.Value;
                    return modelExplorer.GetExplorerForExpression(metadata, modelAccessor);
                }
                if (viewDataInfo.Value != null)
                {
                    ModelMetadata metadataForType = metadataProvider.GetMetadataForType(viewDataInfo.Value.GetType());
                    return modelExplorer.GetExplorerForExpression(metadataForType, viewDataInfo.Value);
                }
            }
            ModelMetadata metadataForType2 = metadataProvider.GetMetadataForType(typeof(string));
            return viewData.ModelExplorer.GetExplorerForExpression(metadataForType2, null);
        }

        private static ModelExplorer FromModel(ViewDataDictionary viewData, IModelMetadataProvider metadataProvider)
        {
            if (viewData == null)
            {
                throw new ArgumentNullException("viewData");
            }
            if (viewData.ModelMetadata.ModelType == typeof(object))
            {
                string model = (viewData.Model == null) ? null : Convert.ToString(viewData.Model, CultureInfo.CurrentCulture);
                return metadataProvider.GetModelExplorerForType(typeof(string), model);
            }
            return viewData.ModelExplorer;
        }
    }
}
