using System.Collections.Generic;
using ProyectoCiclo3.App.Dominio;
using System.Linq;
using System;
 
namespace ProyectoCiclo3.App.Persistencia.AppRepositorios
{
    public class RepositorioEncomienda
    {
        List<Encomienda> Encomiendas;

    private readonly AppContext _appContext = new AppContext();
    public IEnumerable<Encomienda> GetAll()
        {
            //trae todos los usuarios de la base de datos
            return _appContext.Encomiendas;
        }
 
        public Encomienda GetEncomiendaWithId(int id){
            return _appContext.Encomiendas.Find(id);
        } 

        public Encomienda Update(Encomienda NewEncomienda){
            var encomienda = _appContext.Encomiendas.Find(NewEncomienda.id);
           
            if(encomienda != null){
                
                encomienda.descripcion = NewEncomienda.descripcion;
                encomienda.peso = NewEncomienda.peso;
                encomienda.tipo = NewEncomienda.tipo;
                encomienda.presentacion = NewEncomienda.presentacion;
                //guardar en al base de datos
                 _appContext.SaveChanges();                
            }
            
        return encomienda;        
        }

        public Encomienda Create(Encomienda newEncomienda){
           
            var addEncomienda = _appContext.Encomiendas.Add(newEncomienda);
            _appContext.SaveChanges();
            return addEncomienda.Entity;//retorna el usuario que acaba de crear
           
           
           }


        public void Delete(int id)
        {
        var encomienda = _appContext.Encomiendas.Find(id);
        if (encomienda == null)
        return;
        _appContext.Encomiendas.Remove(encomienda);
        _appContext.SaveChanges();

        
        }

     }

}
