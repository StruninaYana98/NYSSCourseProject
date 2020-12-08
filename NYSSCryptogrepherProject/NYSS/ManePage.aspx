<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManePage.aspx.cs" Inherits="NYSSCryptographer.ManePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/css/styles.css" rel="stylesheet" />
    <title>Cryptographer</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="content">
            <div class="menu">
                <div class="menu-container">
                    <div class="Cryptographer">
                        <asp:LinkButton runat="server"><a  class="Cryptographer-link" href="ManePage.aspx"> Cryptographer </a></asp:LinkButton>

                    </div>
                    <div class="menubutton">
                        <asp:LinkButton runat="server"><a class="link" href="TXTDecoder.aspx"> Расшифровать txt файл </a></asp:LinkButton>

                    </div>
                    <div class="menubutton">
                        <asp:LinkButton runat="server"><a class="link" href="TextEncoder.aspx"> Зашифровать текст </a></asp:LinkButton><br />
                    </div>
                    <div class="menubutton">
                        <asp:LinkButton runat="server"><a class="link" href="DOCXEncoder.aspx"> Зашифровать docx файл </a></asp:LinkButton><br />
                    </div>
                </div>
            </div>
            <div class="Description-container">
                <asp:Label runat="server" CssClass="Description">Данная программа реализует шифровку и дешифровку текстов с помощью шифра Виженера </asp:Label>
            </div>
        </div>

    </form>
</body>
</html>
