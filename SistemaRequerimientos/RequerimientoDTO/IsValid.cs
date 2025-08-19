using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequerimientoDTO
{
    public class IsValid
    {
        public bool Success { get; set; }
        public List<Error> Errors { get; set; }
    }
}
