<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DOCXEncoder.aspx.cs" Inherits="NYSS.DOCXEncoder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/css/style.css" rel="stylesheet" />
    <title> Зашифровать docx файл </title>
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
                <asp:Label CssClass="Label" runat="server" Text="Загрузите файл в формате docx"></asp:Label>
                <br />
                <asp:FileUpload CssClass="Label" ID="UploadDocxFile" runat="server" />
                <br />
                <asp:Button CssClass="Button" runat="server" ID="UploadButton" Text="Загрузить" OnClick="UploadButton_Click" />
                <br />

                <asp:Label CssClass="Error" runat="server" ID="StatusLabel" Text="" />
                <br />
                <asp:TextBox CssClass="TextBox" runat="server" ReadOnly="true" ID="TextFromDocx" TextMode="MultiLine" />
                <br />
                <asp:Label  CssClass="Label" runat="server" Text="Введите ключ: "></asp:Label>
                <asp:TextBox CssClass="KeyTextBox" runat="server" Wrap="true" ID="Key" />
                <br />
                <asp:Button CssClass="Button" runat="server" ID="Encrypt" Text="Зашифровать" OnClick="Encrypt_Click" />
                <asp:Label CssClass="Label" runat="server" ID="Error"></asp:Label>
                <br />
                <asp:TextBox CssClass="TextBox" runat="server" ReadOnly="true" ID="EncryptedText" TextMode="MultiLine" />
                <br />


                 <br />
                <asp:Label CssClass="Label" runat="server" Text="Введите имя файла: "></asp:Label>
                <asp:TextBox CssClass="TextField" runat="server" Wrap="true" ID="FileName" Text="New File" Height="30px" Width="223px"></asp:TextBox>
                <asp:Label CssClass="Label" runat="server" Text=".docx"></asp:Label>
                <br />
                <asp:Label CssClass="Label" runat="server" Text="Скачайте файл: "></asp:Label>
                <asp:Button CssClass="Button" runat="server" Text="Скачать" ID="Download" OnClick="Download_Click" />
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
