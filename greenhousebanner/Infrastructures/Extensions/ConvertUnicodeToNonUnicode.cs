using System.Globalization;

namespace greenhousebanner.Infrastructures.Extensions
{
    public static class ConvertStringExtension
    {
        public static string ConvertUnicodeToNonUnicode(this string strConvert)
        {
            string stFormD = strConvert.Normalize(System.Text.NormalizationForm.FormD);
            var sb = new System.Text.StringBuilder();
            for (int i = 0; i <= stFormD.Length - 1; i++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(stFormD[i]);
                if (uc == UnicodeCategory.NonSpacingMark == false)
                {
                    string str;
                    if (stFormD[i] == 'đ')
                        str = "d";
                    else if (stFormD[i] == 'Đ')
                        str = "D";
                    else if (stFormD[i] == '\r' | stFormD[i] == '\n')
                        str = "";
                    else
                        str = stFormD[i].ToString(CultureInfo.InvariantCulture);
                    sb.Append(str);
                }
            }
            return sb.ToString();
        }

        public static string ConvertToSeoName(this string strConvert)
        {
            return strConvert.ConvertUnicodeToNonUnicode().Trim().Replace(" ", "-");
        }
    }
}