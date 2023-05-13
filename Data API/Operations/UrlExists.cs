using System.Xml;

namespace WebApiKurlar1.Operations
{
    public class UrlExists
    {
        public bool Handle(string url)
        {
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(url);
                return true;
            }
            catch
            {
                
                return false;
            }
        }
    }
}
