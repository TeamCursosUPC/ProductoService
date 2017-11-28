using ProductoServices.Dominio;
using ProductoServices.Errores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProductoServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IProductos" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IProductos
    {
        [FaultContract(typeof(RepetidoException))]
        [OperationContract]
        Producto CrearProducto(Producto productoACrear);

        [OperationContract]
        Producto ObtenerProducto(int codigo);

        [OperationContract]
        Producto ModificarProducto(Producto productoAModificar);

        [OperationContract]
        void EliminarProducto(int codigo);

        [OperationContract]
        List<Producto> ListarProductos();
    }

}
