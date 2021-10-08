using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioServicio
    {
        List<Servicio> Servicios;

    private readonly AppContext _appContext = new AppContext();
    public IEnumerable<Servicio> GetAll()
        {
            //trae todos los usuarios de la base de datos
            return _appContext.Servicios;
        }
 
        public Servicio GetServicioWithId(int id){
            return _appContext.Servicios.Find(id);
        } 

        public Servicio Update(Servicio NewServicio){
            var servicio = _appContext.Servicios.Find(NewServicio.id);
           
            if(servicio != null){
                
                servicio.origen = NewServicio.origen;
                servicio.destino = NewServicio.destino;
                servicio.fecha = NewServicio.fecha;
                servicio.hora = NewServicio.hora;
                servicio.encomienda = NewServicio.encomienda;
                //guardar en al base de datos
                 _appContext.SaveChanges();                
            }
            
        return servicio;        
        }

        public Servicio Create(Servicio newServicio){
           
            var addServicio = _appContext.Servicios.Add(newServicio);
            _appContext.SaveChanges();
            return addServicio.Entity;//retorna el usuario que acaba de crear
           
           
           }


        public void Delete(int id)
        {
        var servicio = _appContext.Servicios.Find(id);
        if (servicio == null)
        return;
        _appContext.Servicios.Remove(servicio);
        _appContext.SaveChanges();

        
        }

     }

}
