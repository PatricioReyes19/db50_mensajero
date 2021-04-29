using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensajeroModel.DTO
{
    public class Mensaje
    {
        private String nombre;
        private String detalle;
        private String tipo;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Detalle { get => detalle; set => detalle = value; }
        public string Tipo { get => tipo; set => tipo = value; }

        public override string ToString()
        {
            return Nombre + ";" + Detalle + ";" + Tipo;
        }
    }
}
