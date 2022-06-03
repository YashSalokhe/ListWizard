namespace ListWizard.Services
{
    public class MailService
    {
        public void SendMail(string Email , string token)
        {

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("warlordgmaing123yt@gmail.com");
            mail.To.Add(Email);


            mail.Subject = "ResetPassword";
            mail.Body = $"click on the link" +
            $"https://localhost:7132/Auth/ResetPassword?email={Email}.com&token={token}" /*+ $".com&token={token}"*/;
                

            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential("warlordgmaing123yt@gmail.com", "password");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);

        }
    }
}
