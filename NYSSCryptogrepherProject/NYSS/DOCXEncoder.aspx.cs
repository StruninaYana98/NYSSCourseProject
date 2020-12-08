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

namespace NYSSCryptographer
{
    public partial class DOCXEncoder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            ErrorsRefreshed();
            if (UploadDocxFile.HasFile && UploadDocxFile.PostedFile.ContentType == "application/vnd.openxmlformats-officedocument.wordprocessingml.document")
            {

                try
                {
                    string filename = Path.GetFileName(UploadDocxFile.FileName);
                    UploadDocxFile.SaveAs(Server.MapPath("~/files/") + filename);
                    using (WordprocessingDocument wpd = WordprocessingDocument.Open(Server.MapPath("~/files/") + filename, true))
                    {
                        string s = "";
                        foreach (var item in wpd.MainDocumentPart.Document.Body.Elements<Paragraph>())
                        {
                            s += item.InnerText + "\n";
                        }

                        TextFromDocx.Text = s;
                    }
                    File.Delete(Server.MapPath("~/files/") + filename);
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
            ErrorsRefreshed();
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
            ErrorsRefreshed();
            try
            {
                if (Validator.FileNameValidator(FileName.Text))
                {
                    if (Directory.Text != "")
                    {
                        using (WordprocessingDocument myDocument = WordprocessingDocument.Create(Validator.PathValidator(Directory.Text) + FileName.Text + ".docx", WordprocessingDocumentType.Document))
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
                        SaveError.Text = "Сохранено!";
                    }
                    else
                    {
                        SaveError.Text = "Введите директорию для сохранения";
                    }
                }
                else
                {
                    FileNameError.Text = "Недопустимое имя файла";
                }
            }
            catch(Exception ex)
            {
                SaveError.Text = ex.Message;
            }
        }

        protected void Download_Click(object sender, EventArgs e)
        {
            ErrorsRefreshed();
            try
            {
                if (Validator.FileNameValidator(FileName.Text))
                {
                    using (WordprocessingDocument myDocument = WordprocessingDocument.Create(Server.MapPath("~/files/") + "DocxFile.docx", WordprocessingDocumentType.Document))
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
                    Response.ContentType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                    Response.AppendHeader("Content-Disposition", $"attachment; filename={FileName.Text}.docx");
                    Response.TransmitFile(Server.MapPath("~/files/") + "DocxFile.docx");
                    Response.End();
                    

                }
                else
                {
                    FileNameError.Text = "Недопустимое имя файла";
                }
            }
            catch (Exception ex)
            {
                DownloadError.Text = ex.Message;
            }
        }
        void ErrorsRefreshed()
        {
            StatusLabel.Text = "";
            Error.Text = "";
            SaveError.Text = "";
            FileNameError.Text = "";
            DownloadError.Text = "";

        }
    }
}