
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequerimientosDTO
{
    public class RequerimientoDescripcionDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Titulo { get; set; }
        public Prioridad Prioridad { get; set; }
        public DateTime FechaCreacion { get; set; }
        public Estado Estado { get; set; }
        public DateOnly FechaVencimiento { get; set; }
    }
}

