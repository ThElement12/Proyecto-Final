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
        public int NivelesLogrados { get; set; }
        [DataMember]
        public List<Items> Inventario { get; set; }
    }
}
