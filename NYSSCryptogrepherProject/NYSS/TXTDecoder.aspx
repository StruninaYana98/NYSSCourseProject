<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TXTDecoder.aspx.cs" Inherits="NYSS.TXTDecoder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="/css/styles.css" rel="stylesheet" />
    <title>Расшифровать txt файл </title>
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
            <div class="page">
                <asp:Label CssClass="Label" runat="server" Text="Загрузите файл в формате txt"></asp:Label>
                <br />
                <asp:FileUpload CssClass="Label" ID="UploadTxtFile" Text="Обзор" runat="server" />
                <br />
                <asp:Button CssClass="Button" runat="server" ID="UploadButton" Text="Загрузить" OnClick="UploadButton_Click" />
                

                <asp:Label CssClass="Error" runat="server" ID="StatusLabel" Text="" />
                <br />
                <asp:TextBox CssClass="TextBox" runat="server" ReadOnly="true" ID="TextFromTxt" TextMode="MultiLine" />
                <br />
                <asp:Label CssClass="Label" runat="server" Text="Kлюч: "></asp:Label>
                <asp:TextBox CssClass="KeyTextBox" runat="server" Wrap="true" ID="Key" Text="скорпион" Height="30px" Width="223px" />
                <br />
                <asp:Button CssClass="Button" runat="server" ID="Decrypt" Text="Расшифровать" OnClick="Decrypt_Click" />
                <asp:Label CssClass="Error" runat="server" ID="Error"></asp:Label>
                <br />
                <asp:TextBox CssClass="TextBox" runat="server" ReadOnly="true" ID="DecryptedText" TextMode="MultiLine" />
                <br />
                <br />
                <asp:Label CssClass="Label" runat="server" Text="Введите имя файла: "></asp:Label>
                <asp:TextBox CssClass="TextField" runat="server" Wrap="true" ID="FileName" Text="New File" Height="30px" Width="223px"></asp:TextBox>
                <asp:Label CssClass="Label" runat="server" Text=".txt"></asp:Label>
                <asp:Label CssClass ="Error" runat="server" ID="FileNameError"></asp:Label>
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
                <asp:Button CssClass="Button" runat="server" ID="Save" Text="Сохранить" OnClick="Save_Click" />
                <asp:Label CssClass="Error" runat="server" ID="SaveError"></asp:Label>
            </div>
        </div>

    </form>
</body>
</html>
