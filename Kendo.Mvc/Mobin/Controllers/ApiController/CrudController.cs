using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Mobin.Service;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Mobin.ExpressionJsonSerializer;
using Mobin.Common;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Kendo.Mvc.Mobin
{
    public class CrudController<TEntity> : ControllerBase where TEntity : class, new()
    {
        protected readonly ICrudService<TEntity> crudService;

        public CrudController(ICrudService<TEntity> _crudService)
        {
            crudService = _crudService;
        }

        public virtual TEntity GetEntityByKey<TKey>(TKey key)
        {
            return crudService.GetEntityByKey(key);
        }

        public virtual IEnumerable<TEntity> GetAllAsEnumerable()
        {
            return crudService.GetAllAsEnumerable();
        }

        [Display(Name = "دریافت اطلاعات {0}")]
        /// <summary>
        /// This method find expression tree which serialized in a file by unique widgetId
        /// </summary>
        /// <returns></returns>
        public virtual async System.Threading.Tasks.Task<object> Read([DataSourceRequest] DataSourceRequest request)
        {
            var query = crudService.GetAllAsQueryable();

            if (request.AutoMakeQueryExpression)
            {
                if (request.WidgetId == Guid.Empty)
                    throw new MobinException("WidgetId must has value so as to fetch expression query from related json file");

                var lambdaExpression = JsonNetAdapter.ReadDeserializedLambdaExpression<TEntity>(request.WidgetId);
                var whereQuery = query.Where(request.Filters);
                request.Filters.Clear();
                return await whereQuery.Select(lambdaExpression).ToDataSourceResultAsync(request);
            }

            return await query.ToDataSourceResultAsync(request);
        }

        [Display(Name = "درج رکورد {0}")]
        public virtual void Insert(TEntity entity)
        {
            crudService.Insert(entity);
        }

        [Display(Name = "ویرایش رکورد {0}")]
        public virtual void Update(TEntity entity)
        {
            crudService.Update(entity);
        }

        [Display(Name = "حذف رکورد {0}")]
        public virtual void Delete(TEntity entity)
        {
            crudService.Delete(entity);
        }

        [Display(Name = "حذف رکورد {0}")]
        public virtual void Delete<TKey>(TKey key)
        {
            crudService.Delete(key);
        }
    }
}