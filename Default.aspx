<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPWebForms_Carrasquero._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--corrousel--%>

    <div id="carouselExampleControls" class="carousel slide" data-bs-ride="carousel">
        <div class="carousel-inner">
            <div class="carousel-item active" data-bs-interval="3000">
                <img src="img/Samsung1.jpg" class="d-block w-100" alt="...">
            </div>

            <div class="carousel-item" data-bs-interval="3000">
                <img src="img/Samsung2.jpg" class="d-block w-100" alt="...">
            </div>

            <div class="carousel-item" data-bs-interval="3000">
                <img src="img/Samsung3.jpg" class="d-block w-100" alt="...">
            </div>

            <div class="carousel-item" data-bs-interval="3000">
                <img src="img/Samsung4.jpg" class="d-block w-100" alt="...">
            </div>
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

    <%--Tarjetas--%>

    <div class="row row-cols-1 row-cols-md-3 g-4">
        <%foreach (dominio.Articulo art in ListaArticulo)
            {%>

        <div class="col-12 col-sm-6 col-md-8 col-lg-3 mb-3">
            <div class="card text-center h-100 cardstyle">
                <img src="<%:art.imagen.UrlImagen %>" class="img-fluid0" alt="Imagen no disponible" />
                <div class="card-body flex-column">
                    <h5 class="card-title"><%:art.nombre %></h5>
                    <h5 class="card-title"><%= art.marca %></h5>
                    <h5 class="card-title"><%= string.Format("{0:C}", art.precio) %></h5>
                </div>
                <div class="btn-group">
                    <a href="CarroCompras.aspx?idArticulo=<%=art.id.ToString() %>" class="btn btn-primary active" aria-current="page">Agregar</a>
                    <a href="CarroCompras.aspx?idArticulo=<%=art.id.ToString() %>" class="btn btn-primary">Detalles</a>
                </div>
                <br />
            </div>
        </div>

        <%}%>
    </div>

</asp:Content>
