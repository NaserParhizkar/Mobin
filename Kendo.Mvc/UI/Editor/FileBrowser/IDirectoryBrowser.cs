using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;

namespace Kendo.Mvc.UI
{
    public interface IDirectoryBrowser
    {
        IEnumerable<FileBrowserEntry> GetFiles(string path, string filter);
        IEnumerable<FileBrowserEntry> GetDirectories(string path);
        IWebHostEnvironment HostingEnvironment { get; set; }
    }
}
