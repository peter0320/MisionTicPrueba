using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioUsuario
    {
        List<Usuario> usuarios;

    private readonly AppContext _appContext = new AppContext();
 
        public IEnumerable<Usuario> GetAll()
        {
            //trae todos los usuarios de la base de datos
            return _appContext.Usuarios;
        }
 
        public Usuario GetUsuarioWithId(int id){
            return _appContext.Usuarios.Find(id);
        } 

        public Usuario Update(Usuario newUser){

            var user = _appContext.Usuarios.Find(newUser.id);
            /* var user= usuario.SingleOrDefault(b => b.id == newUser.id); */
            if(user != null){
                user.nombre = newUser.nombre;
                user.apellidos = newUser.apellidos;
                user.direccion = newUser.direccion;
                user.telefono = newUser.telefono;
                user.ciudad = newUser.ciudad;
                
                //guardar en al base de datos
                 _appContext.SaveChanges();
                
            }
        return user;
        
        }

        public Usuario Create(Usuario newUser){
           
            var addUsuario = _appContext.Usuarios.Add(newUser);
            _appContext.SaveChanges();
            return addUsuario.Entity;//retorna el usuario que acaba de crear
           
           /* if(usuario.Count > 0){               
           newUser.id = usuario.Max(r => r.id) +1; 
            }else{
               newUser.id = 1; 
            }

           usuario.Add(newUser);
           return newUser; */
           }


        public void Delete(int id)
        {
        var user = _appContext.Usuarios.Find(id);
        if (user == null)

        return;

        _appContext.Usuarios.Remove(user);
        _appContext.SaveChanges();

        /* var user= usuario.SingleOrDefault(b => b.id == id);
        usuario.Remove(user);
        return user; */
        }

     }

}
