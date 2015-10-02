using System;

namespace greenhousebanner.Infrastructures.Helper
{
    public class GetStringTimes
    {
       public static string GetTimes(DateTime input)
        {
            if (input != null)
            {
                var _str = String.Format("{0:d-M-yyyy HH-mm-ss}", input).Replace(" ", "-") + "-";
                return string.Format("{0}{1}", _str, input.Millisecond.ToString());
            }
            return string.Empty;

        }
    }
}