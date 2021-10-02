using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioUsuario
    {
        List<Usuario> usuario;
 
    public RepositorioUsuario()
        {
            usuario = new List<Usuario>()
            {
                new Usuario{id=1,nombre="Mario",apellidos= "Sánchez",direccion= "Carrera 27",telefono= "8945412121"},
                new Usuario{id=2,nombre="Camila",apellidos= "Rodriguez",direccion= "Calle 96",telefono= "895656562"},
                new Usuario{id=3,nombre="Maria Carolina",apellidos= "Perez",direccion= "Avenida Sur con 14",telefono= "12145454"} 
            };
        
        }
 
        public IEnumerable<Usuario> GetAll()
        {
            return usuario;
        }
 
        public Usuario GetUsuarioWithId(int id){
            return usuario.SingleOrDefault(b => b.id == id);
        } 
        
        public Usuario Update(Usuario newUser){
            var user= usuario.SingleOrDefault(b => b.id == newUser.id);
            if(user != null){
                user.nombre = newUser.nombre;
                user.apellidos = newUser.apellidos;
                user.direccion = newUser.direccion;
                user.telefono = newUser.telefono;
                
            }
        return user;
        
        }
  
  } 
    

}
