using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Media3D;
using System.Xml.Linq;
namespace PasswordKeeper
{
    public class PasswordKepper
    {
        public string Username = "Admin";
        private List<Password> ListOfPasswords;


        public PasswordKepper()
        {

            this.ListOfPasswords = new List<Password>();

        }

        public void AddPassword(string username, string domain, string password)
        {
            this.ListOfPasswords.Add(new Password(username, domain, password));
        }
        public void SavePasswords()
        {
            XDocument xml = new XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XComment("Lista haseł"),
              new XElement("password",
                  from password in this.ListOfPasswords
                  orderby password.DomainName, password.Username
                  select new XElement("password",
                      new XElement("username", password.Username),
                      new XElement("domain", password.DomainName),
                      new XElement("password", password.SecretPassword)
                   )
                  )
              );

            xml.Save(Username + ".xml");
        }

        public void LoadPasswords()
        {
            XDocument xml = XDocument.Load(Username + ".xml");

            this.ListOfPasswords.Clear();
            this.ListOfPasswords = (
                from password in xml.Root.Elements("password")
                select new Password(
                    password.Element("username").Value,
                    password.Element("domain").Value,
                    password.Element("password").Value
                    )
                    ).ToList<Password>();
            
        }
      

    }
   public class Password
    {
        public Password()
        {

        }

        public Password(string username, string domainName, string secretPassword)
        {
            this.Username = username;
            this.DomainName = domainName;
            this.SecretPassword = secretPassword;

        }

        public string Username { get; set; }

        public string DomainName { get; set; }

        public string SecretPassword { get; set; }

        private string SecretSeed;

        private void set_SecretSeed()
        {
            //todo:losowanie ziarna
            this.SecretSeed = "Abc@38d2319";
        }

    }
}
