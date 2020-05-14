namespace Kendo.Mvc.UI
{
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using System.Linq;

    public interface ISchedulerEventService<T>
        where T : class, ISchedulerEvent
    {
        IQueryable<T> GetAll();
        void Insert(T appointment, ModelStateDictionary modelState);
        void Update(T appointment, ModelStateDictionary modelState);
        void Delete(T appointment, ModelStateDictionary modelState);
    }
}
