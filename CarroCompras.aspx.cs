using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;

namespace TPWebForms_Carrasquero
{
    public partial class CarroCompras : System.Web.UI.Page
    {

        public Articulo articuloNuevo { get; set; }
        private int idArticulo = 0;
        public decimal total = 0;
        public List<Articulo> carritoCompra;
        protected void Page_Load(object sender, EventArgs e)
        {
            carritoCompra = new List<Articulo>();
            if (Session["carrito"] == null)    // si session "carrito" es nulo creamos una session del lista de articulos
            {
                Session.Add("carrito", new List<Articulo>());
            }
            if ( !IsPostBack )
            {
                if (Request.QueryString["idArticulo"] != null)
                {
                    try
                    {
                        idArticulo = Convert.ToInt32(Request.QueryString["idArticulo"]);
                        articuloNuevo = new Articulo();
                        ArticuloNegocio auxNegocio = new ArticuloNegocio();
                        articuloNuevo = auxNegocio.listar().Find(x => x.id == idArticulo);  // le asigna a la variable articulonuevo  el id encontrado
                        carritoCompra = (List<Articulo>)Session["carrito"];

                        carritoCompra.Add(articuloNuevo);
                        Session.Add("carrito", carritoCompra);             //agregamos a la lista secion "carrito" con el nuevo articulo 
                    }
                    catch (Exception)
                    {
                        Response.Redirect("Error.aspx");
                    }

                }         
            }
           

            if (Request.QueryString["idCant"] != null)
            {
                try
                {

                    idArticulo = Convert.ToInt32(Request.QueryString["idCant"]);
                    carritoCompra = (List<Articulo>)Session["carrito"];
                    carritoCompra.Add(carritoCompra.Find(x => idArticulo == x.id));
                    Session["carrito"] = carritoCompra;
                }
                catch
                {
                    Response.Redirect("Error.aspx");
                }
            }
            if (Request.QueryString["idCancelar"] != null)   //si se hizo click en el boton cancelar
            {
                try
                {

                    idArticulo = Convert.ToInt32(Request.QueryString["idCancelar"]);
                    carritoCompra = (List<Articulo>)Session["carrito"];
                    carritoCompra.Remove(carritoCompra.Find(x => idArticulo == x.id));
                    Session["carrito"] = carritoCompra;
                }
                catch
                {
                    Response.Redirect("Error.aspx");
                }
            }
            else
            {
                carritoCompra = (List<Articulo>)Session["carrito"];
            }
            cacular();

        }
        private void cacular()
        {
            foreach (var item in carritoCompra)
            {
                total = total + item.precio;
            }
            lbtotal.Text = string.Format("{0:C}", total);
        }


    }
}