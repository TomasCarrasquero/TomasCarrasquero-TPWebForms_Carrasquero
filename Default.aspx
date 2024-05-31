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

    <div class="card mb-3" style="width: 18rem;">
  <div class="card-body">
    <h5 class="card-title">Special title treatment</h5>
    <p class="card-text">With supporting text below as a natural lead-in to additional content.</p>
    <a href="#" class="btn btn-primary">Go somewhere</a>
  </div>
</div>

</asp:Content>
