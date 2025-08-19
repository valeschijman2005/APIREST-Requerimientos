using SistemaEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequerimientoDTO
{
    public class RequerimientoDescripcionDTO
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Titulo { get; set; }
        public Prioridades Prioridad {  get; set; }
        public DateTime FechaCreacion { get; set; }
        public Estados Estado { get; set; }
        public DateOnly FechaVencimiento { get; set; }
    }
}
