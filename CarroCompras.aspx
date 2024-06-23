<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CarroCompras.aspx.cs" Inherits="TPWebForms_Carrasquero.CarroCompras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row pt-3">
        <div class="col-12 col-md-9  ">
            <table class="table table-hover table-dark table-striped">
                <tr>
                    <th scope="col"></th>
                    <th scope="col">Codigo</th>
                    <th scope="col">Nombre</th>
                    <th scope="col">Precio</th>
                    <th scope="col">cantidad</th>
                    <th scope="col"></th>
                </tr>
                <%foreach (dominio.Articulo art in carritoCompra)
                    { %>
                <tr>
                    <td>
                        <img src="<%=art.imagen.UrlImagen %>" alt="No hay imagen" width="100" height="100"></td>
                    <td><b><%=art.codigo %> </b></td>
                    <td><%=art.nombre %></td>
                    <td><%=string.Format("{0:C2}",art.precio) %></td>
                    <td><a class="btn btn-primary" href="CarroCompras.aspx?idCant=<%= art.id %>" role="button">+</a></td>
                    <td><a class="btn btn-warning" href="CarroCompras.aspx?idCancelar=<%= art.id %>" role="button">Cancelar</a></td>

                </tr>
                <%}%>
            </table>
        </div>
        <div class="col-12 col-md-3">
            <div class="total">
                <hr />
                <h3>El Precio total de tu compra es</h3>
                <hr />
                <asp:Label ID="lbtotal" runat="server" Text="lbTotal"></asp:Label>
            </div>
        </div>
    </div>
    <div class="container text-center mt-3">
        <a href="Default.aspx" class="btn btn-primary">Seguir Navegando</a>
    </div>
</asp:Content>
