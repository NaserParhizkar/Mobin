using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Mobin.Service;
using System.Linq.Expressions;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Mobin.ExpressionJsonSerializer;
using Mobin.Common;

namespace Kendo.Mvc.Mobin
{
    public class CrudController<TEntity> : Controller where TEntity : class, new()
    {
        private readonly ICrudService<TEntity> crudService;

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

        /// <summary>
        /// This method read expression tree that serialized in a file and found it by unique callerkey
        /// </summary>
        /// <returns></returns>
        public virtual object Read(DataSourceRequest request)
        {
            Guid callerKey;
            var key = this.HttpContext.Request.Query["callerKey"];

            if (!Guid.TryParse(key, out callerKey))
                throw new MobinException("callerKey not specefied");

            var lambdaExpression = JsonNetAdapter.ReadDeserializedLambdaExpression<TEntity>(callerKey);
            var query = crudService.GetAllAsQueryable().Select(lambdaExpression);

            return query.ToDataSourceResult(request);
        }

        public virtual void Insert(TEntity entity)
        {
            crudService.Insert(entity);
        }

        public virtual void Update(TEntity entity)
        {
            crudService.Update(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            crudService.Delete(entity);
        }

        public virtual void Delete<TKey>(TKey key)
        {
            crudService.Delete(key);
        }
    }
}