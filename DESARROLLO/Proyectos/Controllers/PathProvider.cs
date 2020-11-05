using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CedRentFIMAAPIPOM.Controllers
{
    public interface IPathProvider
    {
        string MapPath(string path);
    }

    public class PathProvider : IPathProvider
    {
        private IWebHostEnvironment _hostingEnvironment;

        public PathProvider(IWebHostEnvironment environment)
        {
            _hostingEnvironment = environment;
        }

        public string MapPath(string path)
        {
            var filePath = Path.Combine(_hostingEnvironment.ContentRootPath, path);
            return filePath;
        }
    }
}
