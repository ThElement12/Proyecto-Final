using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Class
{
    [DataContract]
    public class Items
    {
        [DataMember]
        public string Nombre { get; set; }
        [DataMember]
        public int Cantidad { get; set; }

        public Items(string Nombre, int Cantidad)
        {
            this.Nombre = Nombre;
            this.Cantidad = Cantidad;

        }
    }
}
