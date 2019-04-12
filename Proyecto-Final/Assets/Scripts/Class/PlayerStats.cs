using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Class
{
    [DataContract]
    public class PlayerStats
    {
        [DataMember]
        public bool Pass { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public List<int> NivelesLogrados { get; set; }
        [DataMember]
        public List<Items> Inventario { get; set; }
        public PlayerStats()
        {
            Pass = false;
            UserName = "";
            NivelesLogrados = new List<int> { 0, 0, 0, 0 };
            Inventario = new List<Items> { new Items("Armadura", 0), new Items("Pocion", 0), new Items("Lagrima", 0), new Items("Amuleto", 0) };

        }
    }
}
