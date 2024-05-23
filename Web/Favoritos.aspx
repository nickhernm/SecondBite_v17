<%@ Page Title="Favoritos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="Web.Favoritos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>

    <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
        <ItemTemplate>
            <div class="card" style="position: relative; margin-bottom: 20px;">
                <div class="row" style="position: absolute; top: 0px; right: 10px; padding: 10px;">
                    <asp:Button ID="Button2" runat="server" Text="Remove favorite" CommandName="RemoveFavorite" CommandArgument='<%# Eval("Id") %>' />
                </div>
                <div style="position: absolute; bottom: 0px; right: 10px; padding: 10px;">
                    <asp:Button ID="Button3" runat="server" Text="Buy" CommandName="Buy" CommandArgument='<%# Eval("Id") %>' />
                </div>
                <div class="card-header">
                    <h2>Nombre: <%# Eval("Nombre") %></h2>
                </div>
                <div class="card-body row">
                    <div style="width: 300px; float: left; position: relative; height: 100px;">
                        <div style="position: absolute; bottom: 0px;">
                            <h3>Alergenos: <%# Eval("Alergenos") %></h3>
                            <h3>Puntuacion: <%# Eval("Puntuacion") %>/5</h3>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>