using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace RequerimientosDTO
{
    public class RequerimientoACrearDTO
    {
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Descripcion { get; set; }

        [Required]
        [EnumDataType(typeof(Prioridad))]
        public Prioridad Prioridad { get; set; }
        [Required]

        public DateOnly FechaVencimiento { get; set; }
    }
}
