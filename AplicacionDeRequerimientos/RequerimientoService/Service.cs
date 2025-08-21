using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RequerimientosData;
using RequerimientosDTO;
using RequerimientosEntities;

namespace RequerimientoService
{
    public class Service
    {
        public List<RequerimientoDescripcionDTO> ObtenerRequerimientos()
        {
            var requerimientos = Archivos.LeerDesdeJson();


            return requerimientos.Where(x => x.Eliminado != true)
                .Select(x => new RequerimientoDescripcionDTO
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion,
                    Titulo = x.Titulo,
                    Prioridad = (Prioridad)x.Prioridad,
                    FechaCreacion = x.FechaDeCreacion,
                    Estado = (Estado)x.EstadoActual,
                    FechaVencimiento = x.FechaDeVencimiento
                }).ToList();
        }
        public RequerimientoDescripcionDTO AgregarRequerimiento(RequerimientoACrearDTO requerimientocrear)
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
                Estado = (Estado)requerimientoentidad.EstadoActual,
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
                    Estado = (Estado)requerimiento.EstadoActual,
                    Prioridad = (Prioridad)requerimiento.Prioridad,


                };
                return requerimientoamostrar;
            }
            return null;
        }
        public RequerimientoDescripcionDTO ActualizarEstadoPorId(int id, Estado estado)
        {
            var requerimientoaactualizar = Archivos.LeerDesdeJson().FirstOrDefault(x => x.Id == id);
            if (requerimientoaactualizar != null)
            {
                var requerimientoactualizado = new Requerimiento
                {
                    Id = requerimientoaactualizar.Id,
                    EstadoActual = (int)estado,
                    Titulo = requerimientoaactualizar.Titulo,
                    Descripcion = requerimientoaactualizar.Descripcion,
                    FechaDeCreacion = requerimientoaactualizar.FechaDeCreacion,
                    FechaDeVencimiento = requerimientoaactualizar.FechaDeVencimiento,
                    Prioridad = requerimientoaactualizar.Prioridad,


                };
                Archivos.AgregarRequerimiento(requerimientoactualizado);
                var requerimientomostrarDTO = new RequerimientoDescripcionDTO
                {
                    Id = requerimientoaactualizar.Id,
                    Prioridad = (Prioridad)requerimientoaactualizar.Prioridad,
                    Estado = (Estado)estado,
                    Titulo = requerimientoaactualizar.Titulo,
                    Descripcion = requerimientoaactualizar.Descripcion,
                    FechaCreacion = requerimientoaactualizar.FechaDeCreacion,
                    FechaVencimiento = requerimientoaactualizar.FechaDeVencimiento,

                };
                return requerimientomostrarDTO;
            }
            return null;
        }
        public bool EliminarRequerimientoPorId(int id)
        {
            var requerimientoeliminar = Archivos.LeerDesdeJson().FirstOrDefault(x => x.Id == id);
            if (requerimientoeliminar != null)
            {
                requerimientoeliminar.Eliminado = true;
                Archivos.AgregarRequerimiento(requerimientoeliminar);
                return true;
            }
            return false;
        }

    }
}

