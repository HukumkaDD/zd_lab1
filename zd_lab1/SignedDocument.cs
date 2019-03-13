using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd_lab1
{
    class SignedDocument 
    {
        public string userName;
        public byte[] edsBlob;
        public string text;

        public SignedDocument()
        {
            userName = "";
            edsBlob = new byte[] { };
            text = "";
        }
        public SignedDocument(string fileName)
        {
            SignedDocument signedDocument;
            if (!LoadFromFile(fileName, out signedDocument))
                throw new Exception();
            userName = signedDocument.userName;
            edsBlob = signedDocument.edsBlob;
            text = signedDocument.text;
        }
        
        public static bool LoadFromFile(string fileName, out SignedDocument signedDocument)
        {
            try
            {
                signedDocument = new SignedDocument();
                using (BinaryReader binaryReader = new BinaryReader(new FileStream(fileName, FileMode.Open, FileAccess.Read)))
                {
                    int nameLength, edsLength;
                    nameLength = binaryReader.ReadInt32();
                    edsLength = binaryReader.ReadInt32();
                    string userName;
                    userName = Encoding.ASCII.GetString(binaryReader.ReadBytes(nameLength));
                    byte[] edsBlob = binaryReader.ReadBytes(edsLength);
                    string text;
                    using (StreamReader streamReader = new StreamReader(binaryReader.BaseStream, Encoding.Unicode))
                    {
                        text = streamReader.ReadToEnd();
                    }
                    signedDocument.edsBlob = edsBlob;
                    signedDocument.text = text;
                    signedDocument.userName = userName;
                }
                return true;
            }
            catch
            {
                signedDocument = null;
                return false;
            }
        }

        public void SaveToFile(string fileName)
        {
            using (BinaryWriter binaryWriter = new BinaryWriter(new FileStream(fileName, FileMode.Create, FileAccess.Write)))
            {
                binaryWriter.Write(userName.Length);
                binaryWriter.Write(edsBlob.Length);
                binaryWriter.Write(Encoding.ASCII.GetBytes(userName));
                binaryWriter.Write(edsBlob);
                binaryWriter.Write(Encoding.Unicode.GetBytes(text));
            }
        }

    }
}
