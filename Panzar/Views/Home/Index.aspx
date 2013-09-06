<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%= this.Html.Partial("_SearchFormPartial") %>
    <% if (this.ViewData["Message"] != null)
       { %>
        <span style="font-weight: bold"><%= this.ViewData["Message"] %></span>
    <% } %>      
</asp:Content>
