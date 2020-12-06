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
            if (UploadTxtFile.HasFile && UploadTxtFile.PostedFile.ContentType == "text/plain")
            {

                try
                {
                    string filename = Path.GetFileName(UploadTxtFile.FileName);
                    UploadTxtFile.SaveAs(Server.MapPath("~/") + filename);

                    TextFromTxt.Text = File.ReadAllText(Server.MapPath("~/") + filename);
                    StatusLabel.Text = "";

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
            string s = TextFromTxt.Text;
            string key = Key.Text;
            if (!Cryptographer.KeyValidator(key) || key == "")
            {
                Error.Text = "Введите корректный ключ";
            }
            else if (s != "")
            {
                DecryptedText.Text = Cryptographer.DecryptText(s, key);
                Error.Text = "";
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
                File.WriteAllText(Directory.Text +FileName.Text+".txt", DecryptedText.Text);
                SaveError.Text = "";


            }
            catch (Exception ex)
            {
                SaveError.Text = ex.Message;
            }
        }

        protected void Download_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText(Server.MapPath("~/") + "TXTFile.txt", DecryptedText.Text);
                Response.ContentType = "text/plain";
                Response.AppendHeader("Content-Disposition", $"attachment; filename={FileName.Text}.txt") ;
                Response.TransmitFile(Server.MapPath("~/") + "TXTFile.txt");
                Response.End();
                DownloadError.Text = "";
            }
            catch (Exception ex)
            {
                DownloadError.Text = ex.Message;
            }
        }

        

        
    }
}