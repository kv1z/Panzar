<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= ViewData["Title"] %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%= Html.Partial("_SearchFormPartial") %>  
    <div id="message">Ожидайте результата запроса...</div>
    <div id="loader">
        <img src="/Content/images/loader.gif" alt="loader" />
    </div>
    <div id="result"></div>
</asp:Content>

<asp:Content runat="server" ID="scriptContent" ContentPlaceHolderID="ScriptContent">
</asp:Content>