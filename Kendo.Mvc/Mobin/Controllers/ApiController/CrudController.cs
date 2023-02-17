using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Mobin.Common;
using Mobin.ExpressionJsonSerializer;
using Mobin.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Kendo.Mvc.Mobin.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CrudController<TEntity> : ControllerBase where TEntity : class, new()
    {
        protected readonly ICrudService<TEntity> crudService;

        public CrudController(ICrudService<TEntity> _crudService)
        {
            crudService = _crudService;
        }

        [HttpGet("{key}")]
        public virtual TEntity GetEntityByKey<TKey>(TKey key)
        {
            return crudService.GetEntityByKey(key);
        }

        [HttpGet]
        public virtual IEnumerable<TEntity> GetAllAsEnumerable()
        {
            return crudService.GetAllAsEnumerable();
        }

        [HttpGet]
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
        [HttpPost]
        public virtual void Insert([MyBind] TEntity entity)
        {
            var res = crudService.Insert(entity);
        }


        [HttpPut]
        [Display(Name = "ویرایش رکورد {0}")]
        public virtual void Update(TEntity entity)
        {
            crudService.Update(entity);
          
            //throw new MobinException("asdasdasd");
        }


        [HttpDelete("{entity}")]
        [Display(Name = "حذف رکورد {0}")]
        public virtual void Delete(TEntity entity)
        {
            crudService.Delete(entity);
        }

        [HttpDelete("{key}")]
        [Display(Name = "حذف رکورد {0}")]
        public virtual void Delete<TKey>(TKey key)
        {
            crudService.Delete(key);
        }
    }

    public class MyBind : BindAttribute
    {
        public MyBind()
        {

        }
        public override bool IsDefaultAttribute()
        {
            return base.IsDefaultAttribute();
        }

        public override bool Match(object obj)
        {
            return base.Match(obj);
        }
    }
}