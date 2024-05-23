<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FAQS.aspx.cs" Inherits="Web.FAQS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
            <!-- Preguntas frecuentes -->
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
    </form>
</body>
</html>
