namespace Repository.Configurations
{
    ///// <summary>
    ///// This class used for singleton instantiation of dbcontext object per httpcontext life time
    ///// </summary>
    ///// <typeparam name="T"></typeparam>
    //public static class DbContextCollectionFactory<T> where T : DbContext, new()
    //{
    //    /// <summary>
    //    /// Check for dbcontext is disposed then recreate a instance of dbcontext for use
    //    /// </summary>
    //    /// <returns></returns>
    //    public static T Create()
    //    {
    //        if (System.Web.HttpContext.Current == null)
    //            return new DbContextFactory<T>().Create();
    //        if (System.Web.HttpContext.Current.Items["Context"] == null)
    //        {
    //            (System.Web.HttpContext.Current.Items["Context"]) = new DbContextFactory<T>().Create();
    //            return ((T)System.Web.HttpContext.Current.Items["Context"]);
    //        }
    //        return ((T)System.Web.HttpContext.Current.Items["Context"]);
    //    }
    //}
}
