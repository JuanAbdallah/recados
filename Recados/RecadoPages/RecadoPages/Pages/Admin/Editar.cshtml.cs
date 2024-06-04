using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RecadoPages.Models;
using RecadoPages.Services;

namespace RecadoPages.Pages.Admin
{
    public class EditarModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly AplicationDbContext context;

        [BindProperty]
        public RecadoDTO recadoDTO {  get; set; } = new RecadoDTO(); 

        public Recado Recado { get; set; } = new Recado();

        public EditarModel(IWebHostEnvironment environment, AplicationDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }
        public void OnGet(int? id)
        {
            var recado = context.Recados.Find(id);
            recadoDTO.Mensagem = recado.Mensagem;
            recadoDTO.Destinatario = recado.Destinatario;
            recadoDTO.Remetente = recado.Remetente;

            Recado = recado;
        }
        public void OnPost(int? id)
        {
            var recado = context.Recados.Find(id);
            Recado = recado;
            Response.Redirect("/Admin/Index");
        }
    }
}

