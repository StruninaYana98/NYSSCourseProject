using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace NYSS
{
    public partial class TXTDecoder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            ErrorsRefreshed();
            if (UploadTxtFile.HasFile && UploadTxtFile.PostedFile.ContentType == "text/plain")
            {

                try
                {
                    string filename = Path.GetFileName(UploadTxtFile.FileName);
                    UploadTxtFile.SaveAs(Server.MapPath("~/files/") + filename);
                    TextFromTxt.Text = File.ReadAllText(Server.MapPath("~/files/") + filename);
                    File.Delete(Server.MapPath("~/files/") + filename);

                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Ошибка загрузки: " + ex.Message;
                }
            }
            else
            {
                StatusLabel.Text = "Пожалуйста, загрузите файл в формате txt";
            }
        }

        protected void Decrypt_Click(object sender, EventArgs e)
        {
            ErrorsRefreshed();
            string s = TextFromTxt.Text;
            string key = Key.Text;
            if (!Cryptographer.KeyValidator(key) || key == "")
            {
                Error.Text = "Введите корректный ключ";
            }
            else if (s != "")
            {
                DecryptedText.Text = Cryptographer.DecryptText(s, key);
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
                        File.WriteAllText(Validator.PathValidator(Directory.Text) + FileName.Text + ".txt", DecryptedText.Text);
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
            catch (Exception ex)
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

                    
                    File.WriteAllText(Server.MapPath("~/files/") + "TXTFile.txt", DecryptedText.Text);
                    Response.ContentType = "text/plain";
                    Response.AppendHeader("Content-Disposition", $"attachment; filename={FileName.Text}.txt");
                    Response.TransmitFile(Server.MapPath("~/files/") + "TXTFile.txt");
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