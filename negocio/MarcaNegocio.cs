using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listar()
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.setearConsulta("select Id, Descripcion from MARCAS");
                datos.ejecturaLectura();

                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.id = (int)datos.Lector["id"];
                    aux.nombre = (string)datos.Lector["Descripcion"];

                    lista.Add(aux);
                }

                return lista;
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
        public void agregarMar(string descripcion)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert into MARCAS (Descripcion) values (@descripcion)");
                datos.setearParametros("@descripcion", descripcion);
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

        public int ProximoID()
        {
            int id = 0;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT MAX(Id) +1 AS ProximoId FROM MARCAS");
                datos.ejecturaLectura();

                if (datos.Lector.Read())
                {
                    if (!datos.Lector.IsDBNull(0))
                    {
                        id = (int)datos.Lector["ProximoId"];
                    }
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

            return id;
        }


        public bool Existencia(string descripcion)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM MARCAS WHERE Descripcion = @descripcion");
                datos.setearParametros("@descripcion", descripcion);
                datos.ejecturaLectura();

                if (datos.Lector.Read())
                {
                    int cantidad = Convert.ToInt32(datos.Lector[0]);
                    return cantidad > 0; 
                }

                return false; 
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
        public void eliminar(int marca)
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("DELETE FROM MARCAS WHERE Id = @Id");
                datos.setearParametros("@Id", marca);
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
        public void modificar(Marca marcaParaModificar)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("UPDATE MARCAS SET Descripcion = @Descripcion WHERE Id = @Id");
                datos.setearParametros("@Descripcion", marcaParaModificar.nombre);
                datos.setearParametros("@Id", marcaParaModificar.id);
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
