using System;
using System.Collections.Generic;
using System.Text;

namespace UdemyBlogProject.BusinessLayer.Utilities.LogTool
{
    public interface ICustomLogger
    {
        void Log(string errorMessage);
    }
}
