<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="TPWebForms_Carrasquero.DetalleProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <header>

        <div class="row">
            <figure class="text-center">
                <h1>ComprasWeb.com</h1>
            </figure>
        </div>
    </header>

    <%foreach (dominio.Articulo art in detalles)
        {
    %>
    <div class="container total">
        <div class="row bg-gradient">
            <div class="col-sm">

                <div id="carouselExampleControls" class="carousel slide" data-bs-ride="carousel">
                    <div class="carousel-inner">
                        <div class="carousel-item active" data-bs-interval="3000">
                            <img src="<%:art.imagen.UrlImagen %>" class="d-block w-100" alt="...">
                        </div>

                        <%
                            if (art.imagenes != null && art.imagenes.Any())
                            {
                                foreach (var item in art.imagenes)
                                {
                        %>
                        <div class="carousel-item" data-bs-interval="3000">
                            <img src="<%:item %>" class="d-block w-100" alt="...">
                        </div>
                        <%
                                }
                            }
                        %>
                    </div>

                    <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Previous</span>
                    </button>
                    <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleControls" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Next</span>
                    </button>
                </div>

            </div>
            <div class="card" style="width: 25rem">
                <div id="detalles" style="display: flex; flex-direction: column; justify-content: space-between; width: 100%; margin-top: 1em;">
                    <h3>Detalles</h3>
                </div>
                <div class="card-body">
                    <h2 class="card-title">
                        <a>Nombre:
                        </a>
                        <%= art.nombre %>
                    </h2>
                    <h3 class="card-subtitle mb-2 text-muted">
                        <a>Marca:
                        </a>
                        <%= art.marca %>
                    </h3>
                    <a>Precio:
                    </a>
                    <h4>
                        <%= string.Format("{0:C}", art.precio) %>
                    </h4>
                    <a>Categoria:
                    </a>
                    <h4>
                        <%= art.categoria.nombre %>
                    </h4>
                    <a>Detalles:
                    </a>
                    <div class="card" style="width: 21rem;">
                        <div class="card-body">
                            <h5 class="card-title"><%= art.descripcion %></h5>

                        </div>
                    </div>
                </div>
                <div class="btn-group">
                    <a href="CarroCompras.aspx?idArticulo=<%=art.id.ToString() %>" class="btn btn-primary active "><i class="bi bi-cart4"></i>Agregar</a>

                    <a href="Default.aspx" class="btn btn-primary">Volver</a>
                </div>
                <br />
            </div>
        </div>
    </div>

    <% } %>
</asp:Content>
