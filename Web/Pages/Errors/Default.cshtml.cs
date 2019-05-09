using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Errors
{
    public class DefaultModel : PageModel
    {
        public int Code { get; set; }
        public string ErrorMessage { get; set; }
        public void OnGet(int code)
        {
            Code = code;
            if (code == 404)
            {
                ErrorMessage = "Page not found";
            }
            else
            {
                ErrorMessage = $"Something went wrong";
            }
        }
    }
}