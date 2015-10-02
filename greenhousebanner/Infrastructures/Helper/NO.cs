using System.Web.Configuration;

namespace greenhousebanner.Infrastructures.Helper
{
    public class SerialNumber
    {
        private static readonly int rowsdisplay = int.Parse(WebConfigurationManager.AppSettings["rowsdisplay"].ToString());
        public static int CurrentIndex(int page)
        {
            return (rowsdisplay * (page - 1)) + 1;
        }
    }
}