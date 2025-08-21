using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using RequerimientosEntities;
using Formatting = Newtonsoft.Json.Formatting;

namespace RequerimientosData
{
    public class Archivos
    {
        public static Requerimiento AgregarRequerimiento(Requerimiento requerimiento)
        {
            var lista = LeerDesdeJson();
            var existente = lista.FirstOrDefault(x => x.Id == requerimiento.Id);

            if (requerimiento.Id == 0)
            {
                // Nuevo requerimiento
                requerimiento.Id = lista.Count + 1;
                requerimiento.EstadoActual = 0;
                requerimiento.FechaDeCreacion = DateTime.Now;
                requerimiento.Eliminado = false;
                lista.Add(requerimiento);
            }
            else if (existente != null)
            {
                if (requerimiento.Eliminado)
                {
                    // Marcar como eliminado
                    existente.Eliminado = true;
                }
                else
                {
                    // Actualizar datos
                    existente.Titulo = requerimiento.Titulo;
                    existente.Descripcion = requerimiento.Descripcion;
                    existente.Prioridad = requerimiento.Prioridad;
                    existente.FechaDeVencimiento = requerimiento.FechaDeVencimiento;
                    existente.EstadoActual = requerimiento.EstadoActual;
                    // No actualices FechaDeCreacion ni Eliminado
                }
            }

            string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "requerimientos.json");
            string json = JsonConvert.SerializeObject(lista, Formatting.Indented);
            File.WriteAllText(rutaArchivo, json);
            return requerimiento;
        }
        public static List<Requerimiento> LeerDesdeJson()
        {
            string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "requerimientos.json");
            if (File.Exists(rutaArchivo))
            {
                string json = File.ReadAllText(rutaArchivo);
                return JsonConvert.DeserializeObject<List<Requerimiento>>(json);
            }
            return new List<Requerimiento>();
        }
    }
}

