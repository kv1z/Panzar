<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<div>
    <% using (Html.BeginForm("Index", "Home", FormMethod.Post))
       { %>           
        <span>
            <%= Html.TextBox("query") %>  
        </span>
        <span>
            <input type="submit" value="Найти" />
        </span>
    <% } %>    
</div>