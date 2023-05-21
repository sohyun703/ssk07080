using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.IO;
public class email : MonoBehaviour
{
    public String emailAddress;
    private String path = System.IO.Path.Combine(Application.streamingAssetsPath, "Result.txt");

  /*  private void Start()
    {
        FileInfo file = new FileInfo(path);
        file.IsReadOnly = false;
        File.Delete(path);

    }*/

    void send()
    {
        MailMessage mail = new MailMessage();

        mail.From = new MailAddress("codingcellduk@gmail.com");
        mail.To.Add(emailAddress);
        mail.Subject = "Result";
        mail.Body = "This is for testing SMTP mail from GMAIL";

        SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
        smtpServer.Port = 587;
        smtpServer.Credentials = new System.Net.NetworkCredential("codingcellduk@gmail.com", "dgfwwlwuewvkbhrd") as ICredentialsByHost;
        smtpServer.EnableSsl = true;
        ServicePointManager.ServerCertificateValidationCallback =
            delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
            { return true; };
        System.Net.Mail.Attachment attachment;
        attachment = new System.Net.Mail.Attachment(path);
        mail.Attachments.Add(attachment);
        smtpServer.Send(mail);
        Debug.Log("success");



    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "end")
        {
            Invoke("send", 1f);
            Debug.Log("Àü¼Û");

        }
    }
}
