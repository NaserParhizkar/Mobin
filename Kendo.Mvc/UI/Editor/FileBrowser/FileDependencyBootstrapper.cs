﻿using Kendo.Mvc.Infrastructure;

namespace Kendo.Mvc.UI.Html
{
    static class FileDependencyBootstrapper
    {
        public static void Setup()
        {
            DI.Current.Register<IDirectoryBrowser>(() => new DirectoryBrowser());
            DI.Current.Register<IDirectoryPermission>(() => new DirectoryPermission());
        }
    }
}
