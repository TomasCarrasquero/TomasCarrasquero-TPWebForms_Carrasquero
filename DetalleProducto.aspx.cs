using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace TPWebForms_Carrasquero
{
    public partial class DetalleProducto : System.Web.UI.Page
    {
        public Articulo detalleArticulo { get; set; }
        public List<Articulo> detalles = null;
        private int idArticulo;

        protected void Page_Load(object sender, EventArgs e)
        {
            detalles = new List<Articulo>();
            idArticulo = Convert.ToInt32(Request.QueryString["idArticulo"]);
            
            if (Session["detallearticulo"] == null)    // si session "carrito" es nulo creamos una session del lista de articulos
            {
                Session.Add("detallearticulo", new List<Articulo>());
            }
            
            try
            {
                int id = int.Parse(Request.QueryString["idArticulo"]);
                detalleArticulo = new Articulo();

                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                detalleArticulo = articuloNegocio.listar().Find(x => x.id == idArticulo);

                var imagenesArticulo = articuloNegocio.obtenerImagenes(idArticulo);
                if (imagenesArticulo != null)
                {
                    if (imagenesArticulo.Count() > 1)
                    {
                        imagenesArticulo.RemoveAt(0);
                    }

                    detalleArticulo.imagenes = imagenesArticulo;
                }

                detalles = (List<Articulo>)Session["detallearticulo"];
                detalles.Add(detalleArticulo);
                
                Session.Add("detallearticulo", detalles);
                Session.Abandon();
            }
            catch
            {
                Response.Redirect("Error.aspx");
            }
        }
    }
}
