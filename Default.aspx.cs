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
    public partial class _Default : Page
    {
        public List<Articulo> ListaArticulo { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            ListaArticulo = negocio.listar();
            repRepetidor.DataSource = ListaArticulo;
            repRepetidor.DataBind();
            //if (!IsPostBack)
            //{
            //    repRepetidor.DataSource = ListaArticulo;
            //    repRepetidor.DataBind();
            //}
        }
    }
}