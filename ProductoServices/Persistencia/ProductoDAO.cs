using ProductoServices.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProductoServices.Persistencia
{
    public class ProductoDAO
    {
        private string CadenaConexion = "Data Source=.\\SQLEXPRESS;Initial Catalog=BDLicoreria;Integrated Security=SSPI;";

        public Producto Crear(Producto productoACrear)
        {
            Producto productoCreado = null;
            string sql = "INSERT INTO t_producto VALUES (@codigo, @tipo, @marca, @anio, @precio)";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@codigo", productoACrear.Codigo));
                    comando.Parameters.Add(new SqlParameter("@tipo", productoACrear.Tipo));
                    comando.Parameters.Add(new SqlParameter("@marca", productoACrear.Marca));
                    comando.Parameters.Add(new SqlParameter("@anio", productoACrear.Anio));
                    comando.Parameters.Add(new SqlParameter("@precio", productoACrear.Precio));
                    comando.ExecuteNonQuery();
                }
            }
            productoCreado = Obtener(productoACrear.Codigo);
            return productoCreado;
        }
        public Producto Obtener(int codigo)
        {
            Producto productoEncontrado = null;
            string sql = "SELECT * FROM t_producto WHERE cod_producto=@codigo";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@codigo", codigo));
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            productoEncontrado = new Producto()
                            {
                                Codigo = (int)resultado["cod_producto"],
                                Tipo = (string)resultado["tipo_producto"],
                                Marca = (string)resultado["tx_marca"],
                                Anio = (int)resultado["nu_anio"],
                                Precio = (int)resultado["nu_precio"]
                            };
                        }
                    }
                }
            }
            return productoEncontrado;
        }
        public Producto Modificar(Producto productoAModificar)
        {
            Producto productoModificado = null;
            string sql = "UPDATE t_producto SET tipo_producto=@tipo, tx_marca=@marca, nu_anio=@anio, nu_precio=@precio WHERE cod_producto=@codigo)";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@tipo", productoAModificar.Tipo));
                    comando.Parameters.Add(new SqlParameter("@marca", productoAModificar.Marca));
                    comando.Parameters.Add(new SqlParameter("@anio", productoAModificar.Anio));
                    comando.Parameters.Add(new SqlParameter("@precio", productoAModificar.Precio));
                    comando.Parameters.Add(new SqlParameter("@codigo", productoAModificar.Codigo));
                    comando.ExecuteNonQuery();
                }
            }
            productoModificado = Obtener(productoAModificar.Codigo);
            return productoModificado;
        }
        public void Eliminar(int codigo)
        {
            string sql = "DELETE FROM t_producto WHERE cod_producto=@codigo";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    comando.Parameters.Add(new SqlParameter("@codigo", codigo));
                    comando.ExecuteNonQuery();
                }
            }
        }
        public List<Producto> Listar()
        {
            List<Producto> productosEncontrados = new List<Producto>();
            Producto productoEncontrado = null;
            string sql = "SELECT *from t_producto";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            productoEncontrado = new Producto()
                            {
                                Codigo = (int)resultado["cod_producto"],
                                Tipo = (string)resultado["tipo_producto"],
                                Marca = (string)resultado["tx_marca"],
                                Anio = (int)resultado["nu_anio"],
                                Precio = (int)resultado["nu_precio"]
                            };
                            productosEncontrados.Add(productoEncontrado);
                        }
                    }
                }
                return productosEncontrados;
            }

        }
    }

}