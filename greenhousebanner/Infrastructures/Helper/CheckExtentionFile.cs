using System;
using System.IO;
using System.Web.Configuration;

namespace greenhousebanner.Infrastructures.Helper
{
    public class CheckExtentionFile
    {
        
        //public static bool CheckExtention(string file)
        //{
        //    string listextension = WebConfigurationManager.AppSettings["ExtentionFile"].ToString();
        //    string extensionfile = Path.GetExtension(file);
        //    if (extensionfile != null)
        //    {
        //        if (listextension.Contains(extensionfile))
        //            return true;      
        //    }
        //    return false;
        //}

        //public static string CheckExtentionString(string file)
        //{
        //    string result = String.Empty;
        //    string listextension = WebConfigurationManager.AppSettings["ExtentionFile"].ToString();
        //    string extensionfile = Path.GetExtension(file);
        //    if (extensionfile != null)
        //    {
        //        if (listextension.Contains(extensionfile))
        //            result = extensionfile.Replace(".", "");    
        //    }
        //    return result;
        //}

        public static bool CheckExtentionFileImage(string file)
        {
            string listextension = WebConfigurationManager.AppSettings["typeimage"].ToString();
            string extensionfile = Path.GetExtension(file);
            if (listextension.Contains(extensionfile))
                return true;
            return false;
        }

        public static string CheckExtentionFileImageString(string file)
        {
            string result = String.Empty;
            string listextension = WebConfigurationManager.AppSettings["typeimage"].ToString();
            string extensionfile = Path.GetExtension(file);
            if (extensionfile != null)
            {
                if (listextension.Contains(extensionfile))
                    result = extensionfile.Replace(".", "");    
            }
            return result;
        }
    }
}