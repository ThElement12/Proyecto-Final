using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Class
{
    public class Items
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }

        public Items(string Nombre, int Cantidad)
        {
            this.Nombre = Nombre;
            this.Cantidad = Cantidad;

        }
    }
}
