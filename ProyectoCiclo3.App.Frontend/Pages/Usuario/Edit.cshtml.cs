using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProyectoCiclo3.App.Persistencia.AppRepositorios;
using ProyectoCiclo3.App.Dominio;
 
namespace ProyectoCiclo3.App.Frontend.Pages
{
    public class EditUsuarioModel : PageModel
    {
        private readonly RepositorioUsuario repositorioUsuario;
        [BindProperty]        
        public Usuario User {get;set;}
 
        public EditUsuarioModel(RepositorioUsuario repositorioUsuario)
       {
            this.repositorioUsuario=repositorioUsuario;
       }
 
        public IActionResult OnGet(int userId)
        {
            User=repositorioUsuario.GetUsuarioWithId(userId);
            return Page();
 
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if(User.id>0)
            {
            User = repositorioUsuario.Update(User);
            }
            return RedirectToPage("./List");
       }
    }
}
