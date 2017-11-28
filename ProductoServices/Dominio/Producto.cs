using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ProductoServices.Dominio
{
    [DataContract]

    public class Producto
    {
        [DataMember]
        public int Codigo { get; set; }

        [DataMember]
        public string Tipo { get; set; }

        [DataMember]
        public string Marca { get; set; }

        [DataMember]
        public int Anio { get; set; }

        [DataMember]
        public int Precio { get; set; }
    }

}