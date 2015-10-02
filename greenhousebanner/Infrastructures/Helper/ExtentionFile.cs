using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace greenhousebanner.Infrastructures.Helper
{
    public static class ExtentionFile
    {

        public static bool CheckExtention(string file)
        {
            var listextension = WebConfigurationManager.AppSettings["extentionfile"];
            var extensionfile = Path.GetExtension(file);
            return extensionfile != null && listextension.Contains(extensionfile);
        }

        public static string GetExtentionString(string file)
        {
            var result = String.Empty;
            var listextension = WebConfigurationManager.AppSettings["extentionfile"];
            var extensionfile = Path.GetExtension(file);
            if (extensionfile == null) return result;
            if (listextension.Contains(extensionfile))
                result = extensionfile.Replace(".", "");
            return result;
        }

        public static bool CheckExtentionFileImage(string file)
        {
            var listextension = WebConfigurationManager.AppSettings["typeimage"];
            var extensionfile = Path.GetExtension(file);
            return extensionfile != null && listextension.Contains(extensionfile);
        }

        public static string GetExtentionFileImageString(string file)
        {
            var result = String.Empty;
            var listextension = WebConfigurationManager.AppSettings["typeimage"];
            var extensionfile = Path.GetExtension(file);
            if (extensionfile == null) return result;
            if (listextension.Contains(extensionfile))
                result = extensionfile.Replace(".", "");
            return result;
        }
    }
}