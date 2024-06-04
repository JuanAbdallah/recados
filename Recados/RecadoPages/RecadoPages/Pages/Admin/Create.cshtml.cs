using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecadoPages.Models;
using RecadoPages.Services;

namespace RecadoPages.Pages.Admin
{
    public class CreateModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly AplicationDbContext context;

        [BindProperty]
        public RecadoDTO Recado { get; set; } = new RecadoDTO();
        public CreateModel(IWebHostEnvironment environment, AplicationDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }
        public void OnGet()
        {
        }
        public string errorMensage = "";
        public void OnPost()
        {
            Recado recado = new Recado()
            {
                Mensagem = Recado.Mensagem,
                Destinatario = Recado.Destinatario,
                Remetente = Recado.Remetente
            };
            context.Recados.Add(recado);
            context.SaveChanges();
            Response.Redirect("/Admin/Index");
        }
    }
}
