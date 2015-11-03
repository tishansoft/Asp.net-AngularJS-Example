using System.Security.Cryptography;
using System.Xml;

namespace ChennaiSarees.Infrastructure.Cryptography
{
    public class MyCrypto
    {
        private RSACryptoServiceProvider rsa = null;
        private string publicPrivateKeyXML;
        private string publicOnlyKeyXML;

        public void AssignNewKey()
        {
            const int PROVIDER_RSA_FULL = 1;
            const string CONTAINER_NAME = "KeyContainer";
            CspParameters cspParams;
            cspParams = new CspParameters(PROVIDER_RSA_FULL);
            cspParams.KeyContainerName = CONTAINER_NAME;
            cspParams.Flags = CspProviderFlags.UseMachineKeyStore;
            cspParams.ProviderName = "Microsoft Strong Cryptographic Provider";
            rsa = new RSACryptoServiceProvider(cspParams);

            //Pair of public and private key as XML string.
            //Do not share this to other party
            publicPrivateKeyXML = rsa.ToXmlString(true);

            //Private key in xml file, this string should be share to other parties
            publicOnlyKeyXML = rsa.ToXmlString(false);
        }

        public void CreateKeys()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(publicPrivateKeyXML);
            doc.PreserveWhitespace = false;
            doc.Save(@"d:\temp\publicprivatekey.xml");

            XmlDocument doc1 = new XmlDocument();
            doc1.LoadXml(publicPrivateKeyXML);
            doc1.PreserveWhitespace = false;
            doc1.Save(@"d:\temp\publickey.xml");
        }
    }
}