using ProductoServices.Dominio;
using ProductoServices.Errores;
using ProductoServices.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ProductoServices
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Productos" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Productos.svc o Productos.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Productos : IProductos
    {
        private ProductoDAO productoDAO = new ProductoDAO();

        public Producto CrearProducto(Producto productoACrear)
        {
            if (productoDAO.Obtener(productoACrear.Codigo) != null)
            {
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        Codigo1 = "101",
                        Descripcion = "El producto ya existe"
                    },
                    new FaultReason("Error al intentar creación"));
            }
            return productoDAO.Crear(productoACrear);
        }

        public Producto ObtenerProducto(int codigo)
        {
            return productoDAO.Obtener(codigo);
        }

        public Producto ModificarProducto(Producto productoAModificar)
        {
            return productoDAO.Modificar(productoAModificar);
        }

        public void EliminarProducto(int codigo)
        {
            productoDAO.Eliminar(codigo);
        }

        public List<Producto> ListarProductos()
        {
            return productoDAO.Listar();
        }

    }
}

