<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    <%= ViewData["Title"] %>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <%= Html.Partial("_SearchFormPartial") %>  
    <div id="result">
        <div>Ожидайте результата запроса...</div>
        <img src="/Content/images/loader.gif" alt="loader" />    
    </div>
</asp:Content>

<asp:Content runat="server" ID="scriptContent" ContentPlaceHolderID="ScriptContent">
    <script type="text/javascript">
        (function($){
            $()
        })(jQuery);

        $(document).ready(function() {
            var guid = "<%= ViewData["Id"] %>";
            var checker = setInterval(function() {
                $.getJSON("/iscomplete/" + guid, function(data) {
                    if (data == 1) {
                        clearInterval(checker);
                        $.get('/result/?id=' + guid, function(result) {
                            $('#result').html(result);                            
                        });
                    }
                });
            }, 500);
        });
    </script>
</asp:Content>