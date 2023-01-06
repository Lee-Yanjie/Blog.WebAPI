using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.WebAPI.FileManage
{
    public interface IFileManageService
    {
        void UploadFile(List<IFormFile> files, string subDirectory);

        (string fileType, byte[] archiveData, string archiveName) DownloadFiles(string subDirectory);

        string SizeConverter(long bytes);
    }
}
