<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Apress.Recipes.WebApi._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
    <h1><asp:Literal ID="ltlTitle" runat="server"></asp:Literal></h1>
    <p class="lead"><asp:Literal ID="ltlAuthor" runat="server"></asp:Literal></p>
    <p><asp:HyperLink ID="hplLink" runat="server" Text="API link &raquo;" CssClass="btn btn-default"></asp:HyperLink></p>
</div>

</asp:Content>
