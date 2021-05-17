using System;
using System.Collections.Generic;

#nullable disable

namespace CRUDMVC.Models
{
    public partial class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? Edad { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
    }
}
