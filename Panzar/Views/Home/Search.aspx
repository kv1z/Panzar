<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= ViewData["Title"] %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%= Html.Partial("_SearchFormPartial") %>  
    <div id="wait">Ожидайте результата запроса...</div>
    <div id="loader">
        <img src="/Content/images/loader.gif" alt="loader" />
    </div>
    <div id="result"></div>
</asp:Content>

<asp:Content runat="server" ID="scriptContent" ContentPlaceHolderID="ScriptContent">
    <script type="text/javascript">
        $(document).ready(function() {
            var guid = "<%= ViewData["Id"] %>";
            var checker = setInterval(function() {
                $.getJSON("/iscomplete/?id=" + guid, function(data) {
                    if (data == 1) {
                        clearInterval(checker);
                        $.get('/result/?id=' + guid, function(result) {
                            $('#result').html(result);                            
                            $('#wait').hide();                            
                            $('#loader').hide();
                        });
                    }
                });
            }, 500);
        });
    </script>
</asp:Content>