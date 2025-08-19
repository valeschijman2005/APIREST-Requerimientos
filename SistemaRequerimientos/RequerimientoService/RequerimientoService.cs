using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequerimientoDTO;
using RequerimientosData;
using SistemaEntities;

namespace RequerimientoService
{
    public class RequerimientoService
    {
        public List<RequerimientoDescripcionDTO> ObtenerRequerimientos()
        {
            var requerimientos = Archivos.LeerDesdeJson();


            return requerimientos.Select(x => new RequerimientoDescripcionDTO
            {
                Id = x.Id,
                Descripcion = x.Descripcion,
                Titulo = x.Titulo,
                Prioridad = (Prioridades)x.Prioridad,
                FechaCreacion = x.FechaDeCreacion,
                Estado = (Estados)x.EstadoActual,
                FechaVencimiento = x.FechaDeVencimiento
            }).ToList();
        }
        public RequerimientoDescripcionDTO AgregarEnum(RequerimientoACrearDTO requerimientocrear)
        {
            var requerimientoentidad = new Requerimiento
            {
                Prioridad = (int)requerimientocrear.Prioridad,
                Titulo = requerimientocrear.Titulo,
                Descripcion = requerimientocrear.Descripcion,
                FechaDeVencimiento = requerimientocrear.FechaVencimiento,
            };
            Archivos.AgregarRequerimiento(requerimientoentidad);
            var requerimientomostrar = new RequerimientoDescripcionDTO
            {
                Id = requerimientoentidad.Id,
                Prioridad = requerimientocrear.Prioridad,
                FechaCreacion = requerimientoentidad.FechaDeCreacion,
                FechaVencimiento = requerimientocrear.FechaVencimiento,
                Titulo = requerimientocrear.Titulo,
                Descripcion = requerimientocrear.Descripcion,
                Estado = (Estados)requerimientoentidad.EstadoActual,
            };

            return requerimientomostrar;
        }
        public RequerimientoDescripcionDTO? ObtenerRequerimientoPorId(int id)
        {
            var requerimiento = Archivos.LeerDesdeJson().FirstOrDefault(x => x.Id == id);
            if (requerimiento != null)
            {
                var requerimientoamostrar = new RequerimientoDescripcionDTO
                {
                    Id = requerimiento.Id,
                    Descripcion = requerimiento.Descripcion,
                    Titulo = requerimiento.Titulo,
                    FechaCreacion = requerimiento.FechaDeCreacion,
                    FechaVencimiento = requerimiento.FechaDeVencimiento,
                    Estado = (Estados)requerimiento.EstadoActual,
                    Prioridad = (Prioridades)requerimiento.Prioridad,


                };
                return requerimientoamostrar;
            }
            return null;
        }
        public RequerimientoDescripcionDTO ActualizarEstadoPorId(int id, int estado)
        {
            var requerimientoaactualizar= Archivos.LeerDesdeJson().FirstOrDefault(x=>x.Id == id);
            if (requerimientoaactualizar != null)
            {
                var requerimientoamostrar =new RequerimientoDescripcionDTO
                {

                }
            }
        }
        
    }
}
