using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioServicio
    {
        List<Servicio> Servicios;

    private readonly AppContext _appContext = new AppContext();
    public IEnumerable<Servicio> GetAll()
        {
            return _appContext.Servicios.Include(u => u.origen)
                       .Include(u => u.destino).
                       Include(e => e.encomienda);

        }
 
        public Servicio GetServicioWithId(int id){
            return _appContext.Servicios.Find(id);
        } 

        public Servicio Update(int id, int origen, int destino, string fecha, string hora, int encomienda){
            
            var servicio = _appContext.Servicios.Find(id);
           
            if(servicio != null){
                
                servicio.origen =  _appContext.Usuarios.Find(origen);
                servicio.destino = _appContext.Usuarios.Find(destino);
                servicio.fecha = fecha;
                servicio.hora = hora;
                servicio.encomienda = _appContext.Encomiendas.Find(encomienda);
                //guardar en al base de datos
                 _appContext.SaveChanges();                
            }
            
        return servicio;        
        }

        public Servicio Create(int origen, int destino, string fecha, string hora, int encomienda)
        {
           
            var newServicio = new Servicio();
            newServicio.origen = _appContext.Usuarios.Find(origen);
            newServicio.destino = _appContext.Usuarios.Find(destino);
            newServicio.fecha = fecha;
            newServicio.hora = hora;
            newServicio.encomienda = _appContext.Encomiendas.Find(encomienda);
            var addServicio = _appContext.Servicios.Add(newServicio);
            _appContext.SaveChanges();

            return addServicio.Entity;          
           
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
