﻿namespace Kendo.Mvc.UI
{
    using Microsoft.AspNetCore.Mvc;

    public interface ISchedulerEventController<T>
        where T : ISchedulerEvent
    {
        JsonResult Read(DataSourceRequest request);
        JsonResult Destroy(T schedulerEvent);
        JsonResult Create(T schedulerEvent);
        JsonResult Update(T schedulerEvent);
    }
}