using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using System.Collections;

namespace TPWebForms_Carrasquero
{
    public partial class _Default : Page
    {
        public List<Articulo> ListaArticulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulo = negocio.listar();
            
            try
            {

                if (Session["ListBuscar"] == null)                                  // si la session "ListBuscar" es nulo 
                {
                    ListaArticulo = negocio.listar();                                //llenamos la variable listaArticulos de todos los articulos en base de datos
                   
                }
                else
                {
                    ListaArticulo = (List<Articulo>)Session["ListBuscar"];         //si no llenamos la listaArticulos con la ssesion de busqueda
                    Session["ListBuscar"] = null;
                   
                }

            }
            catch
            {
                Response.Redirect("Error.aspx");
            }
        }
    }
}