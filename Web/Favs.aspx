<%@ Page Title="Favs" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Favs.aspx.cs" Inherits="Web.Favs" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    
        <div class="card" style="position: relative">
            <div class="row" style="position: absolute; top: 0px; right: 10px; padding: 10px;">
                <asp:Button ID="Button2" runat="server" Text="Remove favorite" OnClick="Delete"></asp:Button>
            </div>
            <div style="position: absolute; bottom: 0px; right: 10px; padding: 10px;">
                <asp:Button ID="Button3" runat="server" Text="Buy" OnClick="Delete"></asp:Button>
            </div>
            <div class="card-header">
                <h2><asp:Label ID="txtTitle" runat="server"></asp:Label></h2>
            </div>
            <div class="card-body row">
                <div style="width: 300px;float: left; position: relative; height:200px">
                <p><asp:Label ID="txtContent" runat="server"></asp:Label></p>
                    <div style="position: absolute; bottom: 0px;">
                        <h3 ><asp:Label ID="txtPrice" runat="server"></asp:Label> </h3>
                    </div>
                </div>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/sandwich.jpg"  AlternateText="Image" Width="200px" Height="200px" style="float: right;"></asp:Image>
            </div>
        </div>

</asp:Content>

