using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace rp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IWebHostEnvironment _webHostEnv;
        public IndexModel(ILogger<IndexModel> logger, IWebHostEnvironment webHostEnv)
        {
            _logger = logger;
            _webHostEnv = webHostEnv;
        }

        public void OnGet() { }
        public IActionResult OnGetFavicon()
        {
            string filePath = Path.Combine(_webHostEnv.WebRootPath, "favicon.ico");
            return PhysicalFile(filePath, "image/x-icon");
        }

        public bool isPosted { get; set; }
        public void OnPost() => isPosted = true;
        public void OnPostCustom() => isPosted = false;
        public IActionResult OnPostRedirect() => RedirectToPage("./Privacy");
    }
}
