using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SistemaEntities; 

namespace RequerimientoDTO
{
    public class RequerimientoACrearDTO
    {
        [Required]
        public string Titulo {  get; set; }
        [Required]
        public string Descripcion { get; set; }

        [Required]
        [EnumDataType(typeof(Prioridades))]
        public Prioridades Prioridad { get; set; }
        [Required]

        public DateOnly FechaVencimiento {  get; set; }
    }
}
