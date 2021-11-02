using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace UdemyBlogProject.BusinessLayer.Utilities.LogTool
{
    public class NLogAdapter : ICustomLogger
    {
        public void Log(string errorMessage)
        {
            //Konfigüre ettiğimiz log dosyasını tanıttık
           var logger= LogManager.GetLogger("loggerFile");
            //içeriğine basacağı mesajı belirttik
            logger.Log(LogLevel.Error, errorMessage);
        }
    }
}
