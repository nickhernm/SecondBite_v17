<%@ Page Title="FAQs" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FAQS.aspx.cs" Inherits="Web.FAQS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="faq-section">
    <h2>Preguntas Frecuentes</h2>
    <asp:Repeater ID="rptFAQs" runat="server">
        <ItemTemplate>
            <div class="faq-item">
                <h3><%# Eval("Pregunta") %></h3>
                <p><%# Eval("Respuesta") %></p>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
</asp:Content>