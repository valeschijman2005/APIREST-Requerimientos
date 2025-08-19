using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaEntities;
using Newtonsoft.Json;

namespace RequerimientosData
{
    public static class Archivos
    {
        public static  Requerimiento AgregarRequerimiento (Requerimiento requerimiento)
        {
            var listarequerimientos= LeerDesdeJson();
            if (requerimiento.Id == 0)
            {
                requerimiento.Id= listarequerimientos.Count+1;
                requerimiento.EstadoActual = 0;
                requerimiento.FechaDeCreacion = DateTime.Now;
                listarequerimientos.Add(requerimiento);

            }
            else if (requerimiento.Id!=0 && requerimiento.)
            {
                listarequerimientos.RemoveAll(x=>x.Id== requerimiento.Id);
            }
            string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Requerimientos.json");
            string json = JsonConvert.SerializeObject(listarequerimientos, Formatting.Indented);
            File.WriteAllText(rutaArchivo, json);
            return requerimiento;

        }
        public static List<Requerimiento> LeerDesdeJson()
        {
            string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Requerimientos.json");
            if (File.Exists(rutaArchivo))
            {
                string json = File.ReadAllText(rutaArchivo);
                return JsonConvert.DeserializeObject<List<Requerimiento>>(json);
            }
            return new List<Requerimiento>();
        }
    }
}
