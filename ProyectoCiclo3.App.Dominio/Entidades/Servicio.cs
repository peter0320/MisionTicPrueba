using System;
namespace ProyectoCiclo3.App.Dominio{
    public class Servicio{
        public int id { get; set; }
        public int origen { get; set; }
        public int destino { get; set;}

        public DateTime fecha { get; set;}
        public TimeSpan hora { get; set; }
        public int encomienda { get; set; }
    }

}