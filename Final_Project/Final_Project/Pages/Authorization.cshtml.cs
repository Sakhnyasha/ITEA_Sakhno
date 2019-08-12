using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Final_Project.Pages
{
    public class AuthorizationModel : PageModel
    {
        public void OnGet()
        {
            HttpContext.Session.SetString("test", "hello world");
        }
    }
}