using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using System.Collections;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {

            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //datos.setearConsulta("Select A.Codigo, A.Nombre, A.Descripcion, A.Precio, I.ImagenUrl, C.Descripcion Categoria, M.Descripcion Marca from ARTICULOS AS A INNER JOIN IMAGENES I ON I.IdArticulo = A.Id INNER JOIN CATEGORIAS C ON C.Id = A.IdCategoria INNER JOIN MARCAS M ON M.Id = A.IdMarca"); //ESTA NO ME TRAE DOS REGISTROS PORQUE TIENE NULL EN CATEGORIA
                datos.setearConsulta("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, (SELECT TOP 1 ImagenUrl FROM IMAGENES WHERE IdArticulo = A.Id AND ISNULL(ImagenUrl,'') <> '') as ImagenUrl, ISNULL(C.Descripcion, 'Sin Descripcion') Categoria, C.Id IDCategoria, M.Descripcion Marca, M.Id IDMarca  FROM ARTICULOS A LEFT JOIN CATEGORIAS C ON C.Id = A.IdCategoria LEFT JOIN MARCAS M ON M.Id = A.IdMarca"); // ESTA CAMBIA EL ISNNUL POR LA PALABRA SIN DESCRIPCION
                datos.ejecturaLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.id = (int)datos.Lector["Id"];
                    aux.codigo = (string)datos.Lector["Codigo"];
                    aux.nombre = (string)datos.Lector["Nombre"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];
                    aux.precio = (decimal)datos.Lector["Precio"];

                    aux.imagen = new Imagen();
                    aux.imagen.UrlImagen = datos.Lector["ImagenUrl"] != System.DBNull.Value ? (string)datos.Lector["ImagenUrl"] : "";

                    //IMPORTANTE PARA COMPOSICION y PARA TRAER COSAS DE OTRAS TABLAS REGISTROS COMPUESTOS
                    aux.categoria = new Categoria();
                    aux.categoria.nombre = (string)datos.Lector["Categoria"];
                    aux.categoria.id = (int)datos.Lector["IDCategoria"];

                    aux.marca = new Marca();
                    aux.marca.nombre = (string)datos.Lector["Marca"];//PARA LA LISTA DESPLEGABLE Y MODIFICAR
                    aux.marca.id = (int)datos.Lector["IDMarca"];//PARA LA LISTA DESPLEGABLE Y MODIFICAR

                    lista.Add(aux);
                }
            }

            catch (Exception ex)
            {
                //throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return lista;
        }

        public Articulo obtenerArticuloPorId(int idArticulo)
        {
            Articulo articulo = new Articulo();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta($"SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, (SELECT TOP 1 ImagenUrl FROM IMAGENES WHERE IdArticulo = A.Id AND ISNULL(ImagenUrl,'') <> '') as ImagenUrl, ISNULL(C.Descripcion, 'Sin Descripcion') Categoria, C.Id IDCategoria, M.Descripcion Marca, M.Id IDMarca  FROM ARTICULOS A LEFT INNER CATEGORIAS C ON C.Id = A.IdCategoria LEFT JOIN MARCAS M ON M.Id = A.IdMarca WHERE A.Id = {idArticulo}"); // ESTA CAMBIA EL ISNNUL POR LA PALABRA SIN DESCRIPCION
                datos.ejecturaLectura();

                while (datos.Lector.Read())
                {
                    articulo.id = (int)datos.Lector["Id"];
                    articulo.codigo = (string)datos.Lector["Codigo"];
                    articulo.nombre = (string)datos.Lector["Nombre"];
                    articulo.descripcion = (string)datos.Lector["Descripcion"];
                    articulo.precio = (decimal)datos.Lector["Precio"];

                    articulo.imagen = new Imagen();
                    articulo.imagen.UrlImagen = datos.Lector["ImagenUrl"] != System.DBNull.Value ? (string)datos.Lector["ImagenUrl"] : "";

                    //IMPORTANTE PARA COMPOSICION y PARA TRAER COSAS DE OTRAS TABLAS REGISTROS COMPUESTOS
                    articulo.categoria = new Categoria();
                    articulo.categoria.nombre = (string)datos.Lector["Categoria"];
                    articulo.categoria.id = (int)datos.Lector["IDCategoria"];

                    articulo.marca = new Marca();
                    articulo.marca.nombre = (string)datos.Lector["Marca"];//PARA LA LISTA DESPLEGABLE Y MODIFICAR
                    articulo.marca.id = (int)datos.Lector["IDMarca"];//PARA LA LISTA DESPLEGABLE Y MODIFICAR
                }
            }

            catch (Exception ex)
            {
                //throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return articulo;
        }

        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert into ARTICULOS (Codigo,Nombre, Descripcion , IdMarca, IdCategoria, Precio) values ('" + nuevo.codigo + "', '" + nuevo.nombre + "','" + nuevo.descripcion + "' , @IDMarca , @IDCategoria , @Precio)");
                datos.setearParametros("@IDMarca", nuevo.marca.id);
                datos.setearParametros("@IDCategoria", nuevo.categoria.id);
                datos.setearParametros("@Precio", nuevo.precio);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Articulo articuloParaModificar)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta($"update ARTICULOS SET Codigo = '{articuloParaModificar.codigo}', Nombre = '{articuloParaModificar.nombre}', Descripcion = '{articuloParaModificar.descripcion}', Precio = {articuloParaModificar.precio.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)}, IdCategoria = {articuloParaModificar.categoria.id}, IdMarca = {articuloParaModificar.marca.id} WHERE Id = {articuloParaModificar.id}");
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar(Articulo articuloParaEliminar)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                // Elimino imagenes asociadas al articulo
                datos.setearConsulta("delete from IMAGENES where IdArticulo = @IdArticulo");
                datos.setearParametros("@IdArticulo", articuloParaEliminar.id);
                datos.ejecutarAccion();
                datos.cerrarConexion();

                // Elimino articulo
                datos.setearConsulta("delete from Articulos where id = " + articuloParaEliminar.id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool validarCodigoExistente(string codigo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta($"select 1 from ARTICULOS where Codigo = '{codigo}'");
                datos.ejecturaLectura();

                if (datos.Lector.Read())
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int obtenerIdArticuloPorCodigo(string codigo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta($"select Id from ARTICULOS where Codigo = '{codigo}'");
                datos.ejecturaLectura();

                if (datos.Lector.Read())
                {
                    return (int)datos.Lector["Id"];
                }

                throw new Exception("Codigo articulo invalido");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregarImagen(int idArticulo, string urlImagen)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta($"Insert into IMAGENES (IdArticulo,ImagenUrl) values ({idArticulo}, '{urlImagen}')");
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<string> obtenerImagenes(int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            List<string> imagenes = new List<string>();
            try
            {
                datos.setearConsulta($"select ImagenUrl from IMAGENES where IdArticulo = '{idArticulo}'");
                datos.ejecturaLectura();

                while (datos.Lector.Read())
                {
                    imagenes.Add((string)datos.Lector["ImagenUrl"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return imagenes;
        }

        public List<int> obtenerImagenesSinPrincipal(int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            List<int> imagenes = new List<int>();
            try
            {
                datos.setearConsulta($"select Id from IMAGENES where IdArticulo = '{idArticulo}' ORDER BY Id ASC");
                datos.ejecturaLectura();

                while (datos.Lector.Read())
                {
                    imagenes.Add((int)datos.Lector["Id"]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return imagenes.Skip(1).ToList();
        }

        public int obtenerImagenPrincipal(int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            int imagen = 0;
            try
            {
                datos.setearConsulta($"select TOP 1 Id from IMAGENES where IdArticulo = '{idArticulo}' ORDER BY Id ASC");
                datos.ejecturaLectura();

                while (datos.Lector.Read())
                {
                    imagen = (int)datos.Lector["Id"];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return imagen;
        }

        public void modificarImagen(int idImagen, string imagenUrl)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta($"update IMAGENES SET ImagenUrl = '{imagenUrl}' WHERE Id = {idImagen}");
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminarImagen(int idImagen)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta($"delete from IMAGENES where Id = '{idImagen}'");
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
