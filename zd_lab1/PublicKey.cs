using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd_lab1
{
    class PublicKey
    {
        public string ownerUserName;
        public byte[] blob;
        public byte[] eds;

        public PublicKey()
        {
            ownerUserName = "";
            blob = new byte[] { };
            eds = null;
        }

        public PublicKey(string fname)
        {
            using (BinaryReader binaryReader = new BinaryReader(new FileStream(fname, FileMode.Open, FileAccess.Read)))
            {
                int nameLength = binaryReader.ReadInt32();
                int publicKeyLength = binaryReader.ReadInt32();
                ownerUserName = Encoding.UTF8.GetString(binaryReader.ReadBytes(nameLength));
                blob = binaryReader.ReadBytes(publicKeyLength);
                if (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
                    eds = binaryReader.ReadBytes((int)(binaryReader.BaseStream.Length - binaryReader.BaseStream.Position));
                else eds = null;
            }
        }

        public void Save(string fname)
        {
            
            using (BinaryWriter binaryWriter = new BinaryWriter(new FileStream(fname, FileMode.Create, FileAccess.Write)))
            {
                binaryWriter.Write(ownerUserName.Length);
                binaryWriter.Write(blob.Length);
                binaryWriter.Write(Encoding.UTF8.GetBytes(ownerUserName));
                binaryWriter.Write(blob);
                if (eds != null)
                    binaryWriter.Write(eds);
            }
        }
    }
}
