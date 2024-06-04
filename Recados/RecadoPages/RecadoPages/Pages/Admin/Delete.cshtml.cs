using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecadoPages.Services;

namespace RecadoPages.Pages.Admin
{
    public class DeleteModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly AplicationDbContext context;

        public DeleteModel(IWebHostEnvironment environment, AplicationDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }
        public void OnGet(int? id)
        {
            var recado = context.Recados.Find(id);
            context.Recados.Remove(recado);
            context.SaveChanges();
            Response.Redirect("/Admin/Index");
        }
    }
}
