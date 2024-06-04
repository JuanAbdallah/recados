using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecadoPages.Models;
using RecadoPages.Services;

namespace RecadoPages.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly AplicationDbContext context;
        public List<Recado> recados {  get; set; } = new List<Recado>();

        public IndexModel(AplicationDbContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            recados = context.Recados.ToList();
        }
    }
}
