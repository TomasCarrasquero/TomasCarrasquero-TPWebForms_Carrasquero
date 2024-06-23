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
    public partial class SiteMaster : MasterPage


    {
        public List<Articulo> listaBuscar { get; set; }
        public string cont;
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Articulo> listaArticulo = new List<Articulo>();
            if (Session["carrito"] == null)
            {
                Session.Add("carrito", new List<Articulo>());
            }
            else
            {
                listaArticulo = (List<Articulo>)Session["carrito"];
                cont = listaArticulo.Count.ToString();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            List<Articulo> lista = new List<Articulo>();
            ArticuloNegocio negocio = new ArticuloNegocio();
            if (txtBuscar.Text != "")
            {
                lista = negocio.listar();
                listaBuscar = lista.FindAll(x => x.nombre.ToLower().Contains(txtBuscar.Text.ToLower()) || x.marca.nombre.ToLower().Contains(txtBuscar.Text.ToLower()));//Busca por nombre o marca
                Session.Add("ListBuscar", listaBuscar);
                Response.Redirect("Default.aspx");
            }
        }

        protected void txtBuscar_TextChange (object sender, EventArgs e)
        {
            //List<Articulo> listas = (List<Articulo>)session["carrito"];
            List<Articulo> lista = new List<Articulo>();
            ArticuloNegocio negocio = new ArticuloNegocio();
            if (txtBuscar.Text != "")
            {
                lista = negocio.listar();
                listaBuscar = lista.FindAll(x => x.nombre.ToLower().Contains(txtBuscar.Text.ToLower()) || x.marca.nombre.ToLower().Contains(txtBuscar.Text.ToLower()));//Busca por nombre o marca
                Session.Add("ListBuscar", listaBuscar);
                Response.Redirect("Default.aspx");
            }
        }
    }
}