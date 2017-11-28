using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;

namespace ProductoServiceTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1CrearProductoOK()
        {
            ProductosWS.ProductosClient proxy = new ProductosWS.ProductosClient();
            ProductosWS.Producto productoCreado = proxy.CrearProducto(new ProductosWS.Producto()
            {
                Codigo = 0004,
                Tipo = "Cognac",
                Marca = "Courvoisier",
                Anio = 2010,
                Precio = 28
            });
            Assert.AreEqual(0004, productoCreado.Codigo);
            Assert.AreEqual("Cognac", productoCreado.Tipo);
            Assert.AreEqual("Courvoisier", productoCreado.Marca);
            Assert.AreEqual(2010, productoCreado.Anio);
            Assert.AreEqual(28, productoCreado.Precio);
        }

        [TestMethod]
        public void Test2CrearProductoRepetido()
        {
            ProductosWS.ProductosClient proxy = new ProductosWS.ProductosClient();
            try
            {
                ProductosWS.Producto productoCreado = proxy.CrearProducto(new ProductosWS.Producto()
                {
                    Codigo = 0004,
                    Tipo = "Cognac",
                    Marca = "Courvoisier",
                    Anio = 2010,
                    Precio = 28
                });
            }
            catch (FaultException<ProductosWS.RepetidoException> error)
            {
                Assert.AreEqual("Error al intentar creación", error.Reason.ToString());
                Assert.AreEqual(error.Detail.Codigo1, "101");
                Assert.AreEqual(error.Detail.Descripcion, "El producto ya existe");
            }
        }

    }
}
