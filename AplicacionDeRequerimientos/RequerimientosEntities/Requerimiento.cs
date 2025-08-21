using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequerimientosEntities
{
    public class Requerimiento
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int Prioridad { get; set; }
        public DateTime FechaDeCreacion { get; set; }
        public DateOnly FechaDeVencimiento { get; set; }
        public int EstadoActual { get; set; }
        public bool Eliminado { get; set; }
    }
}

