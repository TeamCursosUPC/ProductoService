using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ProductoServices.Errores
{
    [DataContract]
    public class RepetidoException
    {
        [DataMember]
        public string Codigo1 { get; set; }

        [DataMember]
        public string Descripcion { get; set; }

    }

}