namespace Kendo.Mvc.Infrastructure.Implementation
{
    //public class VirtualPathProviderWrapper : IVirtualPathProvider
    public class VirtualPathProviderWrapper
    {
        //internal static Func<VirtualPathData> getCurrentProvider = () => HostingEnvironment.;

        //private static VirtualPathData CurrentProvider
        //{
        //    get
        //    {
        //        return VirtualPathData
        //    }
        //}

        //public bool DirectoryExists(string virtualPath)
        //{
        //    return CurrentProvider.DirectoryExists(virtualPath);
        //}

        //public bool FileExists(string virtualPath)
        //{
        //    return CurrentProvider.FileExists(virtualPath);
        //}

        //public string GetDirectory(string virtualPath)
        //{
        //    return VirtualPathUtility.GetDirectory(virtualPath);
        //}

        //public string GetFile(string virtualPath)
        //{
        //    return VirtualPathUtility.GetFileName(virtualPath);
        //}

        //public string GetExtension(string virtualPath)
        //{
        //    return VirtualPathUtility.GetExtension(virtualPath);
        //}

        //public string CombinePaths(string basePath, string relativePath)
        //{
        //    return VirtualPathUtility.Combine(VirtualPathUtility.AppendTrailingSlash(basePath), relativePath);
        //}

        //public string ReadAllText(string virtualPath)
        //{
        //    var path = VirtualPathUtility.IsAppRelative(virtualPath) ?
        //                  VirtualPathUtility.ToAbsolute(virtualPath) :
        //                  virtualPath;

        //    using (Stream stream = VirtualPathProvider.OpenFile(path))
        //    {
        //        using (var sr = new StreamReader(stream))
        //        {
        //            return sr.ReadToEnd();
        //        }
        //    }
        //}

        //public string ToAbsolute(string virtualPath)
        //{
        //    return VirtualPathUtility.ToAbsolute(virtualPath);
        //}

        //public string AppendTrailingSlash(string virtualPath)
        //{
        //    return VirtualPathUtility.AppendTrailingSlash(virtualPath);
        //}
    }
}