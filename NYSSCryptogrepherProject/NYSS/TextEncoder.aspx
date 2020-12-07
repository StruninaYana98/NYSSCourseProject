<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TextEncoder.aspx.cs" Inherits="NYSS.TextEncoder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="/css/style.css" rel="stylesheet" />
    <title> Зашифровать текст </title>
</head>
<body>
    <form id="form1" runat="server">
       <div class="content">
            <div class="menu">
                <div class="menubutton">
                    <asp:LinkButton runat="server" ID="ManePage"><a href="ManePage.aspx">На главную</a></asp:LinkButton>
                </div>
            </div>
            <div class="page">
                <asp:Label CssClass="Label" runat="server" Text="Введите текст: "></asp:Label>
                <br />
                <asp:TextBox CssClass="TextBox" runat="server" ID="TextInput" TextMode="MultiLine" />
                <br />
                <asp:Label CssClass="Label" runat="server" Text="Введите ключ: "></asp:Label>
                <asp:TextBox CssClass="KeyTextBox" runat="server" Wrap="true" ID="Key"  Height="30px" Width="223px" />
                <br />
                <asp:Button CssClass="Button" runat="server" ID="Encrypt" Text="Зашифровать" OnClick="Encrypt_Click"  />
                <asp:Label CssClass="Error" runat="server" ID="Error"></asp:Label>
                <br />
                <asp:TextBox CssClass="TextBox" runat="server" ReadOnly="true" ID="EncryptedText" TextMode="MultiLine" />
                <br />
                

                
                <br />
                <asp:Label CssClass="Label" runat="server" Text="Введите имя файла: "></asp:Label>
                <asp:TextBox CssClass="TextField" runat="server" Wrap="true" ID="FileName" Text="New File" Height="30px" Width="223px"></asp:TextBox>
                <asp:Label CssClass="Label" runat="server" Text=".txt"></asp:Label>
                <asp:Label CssClass ="Error" runat ="server" ID="FileNameError"></asp:Label>
                <br />
                <asp:Label CssClass="Label" runat="server" Text="Скачайте файл: "></asp:Label>
                <asp:Button CssClass="Button" runat="server" Text="Скачать" ID="Download" OnClick="Download_Click"  />
                <asp:Label CssClass="Error" runat="server" ID="DownloadError"></asp:Label>
                <br />
                <br />
                <br />
                <asp:Label CssClass="Label" runat="server" Text="Или сохраните файл в выбранной директории "></asp:Label>
                <br />
                <br />
                <asp:Label CssClass="Label" runat="server" Text="Введите директорию для сохранения: "></asp:Label>
                <asp:TextBox CssClass="TextField" runat="server" Wrap="true" ID="Directory"  Height="30px" Width="300px" ></asp:TextBox>
                <br />
                <asp:Button CssClass="Button" runat="server" ID="Button1" Text="Сохранить" OnClick="Save_Click" />
                <asp:Label CssClass="Error" runat="server" ID="SaveError"></asp:Label>
                
            </div>
        </div>
    </form>
</body>
</html>
