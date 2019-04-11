using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Clases
{
    class Item
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }

        public Item(string Nombre, int Cantidad)
        {
            this.Nombre = Nombre;
            this.Cantidad = Cantidad;
        }

    }
}
