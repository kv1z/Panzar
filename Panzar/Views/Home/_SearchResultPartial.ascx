<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IList<Panzar.Models.User>>" %>

<% if (Model.Count == 0)
   { %>
    <div>Поиск не дал результатов</div>
<% }
   else
   { %>

    <table>
        <tr>
            <td>Id</td>
            <td>Игрок</td>
        </tr>
    
        <% foreach (var user in Model)
           { %>
            <tr>
                <td><%= user.Id %></td>
                <td><%= user.Name %></td>
            </tr>
        <% } %>
    </table>  
<% } %>