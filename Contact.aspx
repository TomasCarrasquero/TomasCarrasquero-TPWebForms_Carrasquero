<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="TPWebForms_Carrasquero.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title">Pagina de contacto</h2>
        <h3>¿Dudas? ¿consultas?</h3>
        <h4>Contactate con nosotros</h4>
        <address>
            One Microsoft Way<br />
            Redmond, WA 98052-6399<br />
            <abbr title="Phone">P:</abbr>
            425.555.0100
        </address>

        <address>
            <strong>Soporte:</strong>   <a href="mailto:tomas.carrasquero@alumnos.frgp.utn.edu.ar">carrasquero@alumnos.frgp.utn.edu.ar</a><br />
            <strong>Marketing:</strong> <a href="mailto:tomas.carrasquero@outlook.com">tomas.carrasquero@outlook.com</a>
        </address>
    </main>
</asp:Content>
