<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

<div>
    <% using (Html.BeginForm("Index", "Home", FormMethod.Post, new { @class = "form-wrapper" }))
       { %>           
        <span>
            <%= Html.TextBox("query")%>  
        </span>
        <span>
            <input type="submit" value="Найти" id="submit"/>
        </span>
    <% } %>    
</div>