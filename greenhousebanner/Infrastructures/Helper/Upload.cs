using System;
using System.Drawing;
using System.Web.Configuration;
using System.IO;
using System.Web;
using greenhousebanner.Infrastructures;
using greenhousebanner.Infrastructures.Helper;

namespace ssc.school.lesson.Infrastructures.Helper
{

 
    public class UploadResult
    {
        public bool IsSuccess { get; set; }
        public string FileName { get; set; }

        public string ImageThumbnail { get; set; }
        public string Result { get; set; }
    }

    public class UploadFileResult
    {

        private static readonly string Rootimage = HttpContext.Current.Server.MapPath(WebConfigurationManager.AppSettings["rootimage"].ToString());
        private static readonly string Rootimagethumbnail = HttpContext.Current.Server.MapPath(WebConfigurationManager.AppSettings["rootimagethumbnail"].ToString());
        private static readonly int Heightthumbnail = int.Parse(WebConfigurationManager.AppSettings["heightthumbnail"].ToString());
        private static readonly string Rootfile = HttpContext.Current.Server.MapPath(WebConfigurationManager.AppSettings["rootfile"].ToString());
        private static readonly int Maxlengthfile = int.Parse(WebConfigurationManager.AppSettings["maxlengthfile"].ToString());

        private static void CreateFolder(string path)
        {
            try
            {
                // Determine whether the directory exists.
                if (!Directory.Exists(path))
                {
                    // Try to create the directory.    
                    var di = Directory.CreateDirectory(path);
                }
            }
            catch (Exception ex)
            {
                Logger.Error(string.Format("Error when create temp folder. Ex:{0}", ex));
            }
        }

        private static string GetTempUploadImagePath(string saveFileName)
        {
            return string.Format("{0}{1}", Rootimage, saveFileName);
        }
        private static string GetTempUploadImageThumbnailPath(string saveFileName)
        {
            return string.Format("{0}{1}", Rootimagethumbnail, saveFileName);
        }
        private static string GetTempUploadFilePath(string saveFileName)
        {
            return string.Format("{0}{1}", Rootfile, saveFileName);
        }

        public static UploadResult UploadImage(HttpPostedFileBase fileimage)
        {
            try
            {
                if (fileimage == null)
                {
                    return new UploadResult
                    {
                        IsSuccess = false,
                        FileName = "",
                        Result = "",
                        ImageThumbnail = ""
                    };
                }

                if (!ExtentionFile.CheckExtentionFileImage(fileimage.FileName.ToLower()))
                {
                    return new UploadResult
                    {
                        IsSuccess = false,
                        FileName = "",
                        Result = ConstantStrings.ExtensionImageSupport,
                        ImageThumbnail = ""
                    };
                }

                if (fileimage.ContentLength > Maxlengthfile)
                {
                    return new UploadResult
                    {
                        IsSuccess = false,
                        FileName = "",
                        Result = ConstantStrings.MaxLengthFileSupport,
                        ImageThumbnail = ""
                    };
                }
                CreateFolder(Rootimage);
                var filename = string.Format("{0}.{1}", GetStringTimes.GetTimes(DateTime.Now), ExtentionFile.GetExtentionFileImageString(fileimage.FileName.ToLower()));
                fileimage.SaveAs(GetTempUploadImagePath(filename));
                GenerateThumbNail(filename, Heightthumbnail);
                return new UploadResult
                {
                    IsSuccess = true,
                    FileName = filename,
                    Result = ConstantStrings.UploadSuccess,
                    ImageThumbnail = filename
                };

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return new UploadResult
                {
                    IsSuccess = false,
                    FileName = "",
                    Result = ConstantStrings.UploadNonSuccess,
                    ImageThumbnail = ""
                };
            }
        }

        public static UploadResult UploadFile(HttpPostedFileBase filebase)
        {
            try
            {
                if (filebase == null)
                {
                    return new UploadResult
                    {
                        IsSuccess = false,
                        FileName = "",
                        Result = "",
                        ImageThumbnail = ""
                    };
                }

                if (!ExtentionFile.CheckExtention(filebase.FileName.ToLower()))
                {
                    return new UploadResult
                    {
                        IsSuccess = false,
                        FileName = "",
                        Result = ConstantStrings.ExtensionFileSupport,
                        ImageThumbnail = ""
                    };
                }

                if (filebase.ContentLength > Maxlengthfile)
                {
                    return new UploadResult
                    {
                        IsSuccess = false,
                        FileName = "",
                        Result = ConstantStrings.MaxLengthFileSupport,
                        ImageThumbnail = ""
                    };
                }
                CreateFolder(Rootfile);
                var filename = string.Format("{0}.{1}", GetStringTimes.GetTimes(DateTime.Now), ExtentionFile.GetExtentionString(filebase.FileName.ToLower()));
                filebase.SaveAs(GetTempUploadFilePath(filename));
                return new UploadResult
                {
                    IsSuccess = true,
                    FileName = filename,
                    Result = ConstantStrings.UploadSuccess,
                    ImageThumbnail = ""
                };
            }
            catch (Exception)
            {
                return new UploadResult
                {
                    IsSuccess = false,
                    FileName = "",
                    Result = ConstantStrings.UploadNonSuccess,
                    ImageThumbnail = ""
                };
            }
        }

        private static void GenerateThumbNail(string imageName, int height)
        {
            var image = Image.FromFile(GetTempUploadImagePath(imageName));
            var srcWidth = image.Width;
            var srcHeight = image.Height;

            var thumbHeight = (float)height;
            var thumbWidth = ((float)srcWidth / (float)srcHeight) * (float)thumbHeight;
            var bmp = new Bitmap((int)thumbWidth, (int)thumbHeight);

            var gr = Graphics.FromImage(bmp);
            gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            gr.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            gr.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            var rectDestination = new Rectangle(0, 0, (int)thumbWidth, (int)thumbHeight);
            gr.DrawImage(image, rectDestination, 0, 0, srcWidth, srcHeight, GraphicsUnit.Pixel);
            CreateFolder(Rootimagethumbnail);
            bmp.Save(GetTempUploadImageThumbnailPath(imageName));
            bmp.Dispose();
            image.Dispose();

        }
    }
}