using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace NYSS
{
    public partial class DOCXEncoder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            if (UploadDocxFile.HasFile && UploadDocxFile.PostedFile.ContentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document")
            {

                try
                {
                    string filename = Path.GetFileName(UploadDocxFile.FileName);
                    UploadDocxFile.SaveAs(Server.MapPath("~/") + filename);
                    using (WordprocessingDocument wpd = WordprocessingDocument.Open(Server.MapPath("~/") + filename, true))
                    {
                        string s = "";
                        foreach (var item in wpd.MainDocumentPart.Document.Body.Elements<Paragraph>())
                        {
                            s += item.InnerText + "\n";
                        }

                        TextFromDocx.Text = s;
                        StatusLabel.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Ошибка загрузки: " + ex.Message;
                }
            }
            else
            {
                StatusLabel.Text = "Пожалуйста, загрузите файл в формате docx";
            }
        }

        protected void Encrypt_Click(object sender, EventArgs e)
        {
            string s = TextFromDocx.Text;
            string key = Key.Text;
            if (!Cryptographer.KeyValidator(key) || key == "")
            {
                Error.Text = "Введите корректный ключ";
            }
            else if (s != "")
            {
                EncryptedText.Text = Cryptographer.EncryptText(s, key);
            }
            else
            {
                Error.Text = "Файл не выбран или пуст";
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            try
            {
                using (WordprocessingDocument myDocument = WordprocessingDocument.Create(Directory.Text+FileName.Text+".docx", WordprocessingDocumentType.Document))
                {
                    string[] strings = EncryptedText.Text.Split('\n');
                    MainDocumentPart mainPart = myDocument.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    Body body = mainPart.Document.AppendChild(new Body());
                    for (int i = 0; i < strings.Length; i++)
                    {
                        Paragraph para = body.AppendChild(new Paragraph());
                        Run run = para.AppendChild(new Run());
                        run.AppendChild(new Text(strings[i]));
                    }

                }
                SaveError.Text = "";
            }
            catch(Exception ex)
            {
                SaveError.Text = ex.Message;
            }
        }

        protected void Download_Click(object sender, EventArgs e)
        {
            try
            {
                using (WordprocessingDocument myDocument = WordprocessingDocument.Create(Server.MapPath("~/") + "DocxFile.docx", WordprocessingDocumentType.Document))
                {
                    string[] strings = EncryptedText.Text.Split('\n');
                    MainDocumentPart mainPart = myDocument.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    Body body = mainPart.Document.AppendChild(new Body());
                    for (int i = 0; i < strings.Length; i++)
                    {
                        Paragraph para = body.AppendChild(new Paragraph());
                        Run run = para.AppendChild(new Run());
                        run.AppendChild(new Text(strings[i]));
                    }
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                    Response.AppendHeader("Content-Disposition", $"attachment; filename={FileName.Text}.docx");
                    Response.TransmitFile(Server.MapPath("~/") + "DocxFile.docx");
                    Response.End();
                    DownloadError.Text = "";
                }
            }
            catch (Exception ex)
            {
                DownloadError.Text = ex.Message;
            }
        }
    }
}