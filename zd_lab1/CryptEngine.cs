using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zd_lab1
{
    class CryptEngine
    {
        #region
        private const string rsa = "RSA";
        private const string dsa = "DSA";
        private const string sha1 = "SНA1";
        private const string sha512 = "SНA512";

        private static CspParameters cspParameters;
        private static RSACryptoServiceProvider rsaCsp;
        private static DSACryptoServiceProvider dsaCsp;
        #endregion

        public static HashAlgorithm GetHashAlgoritm(string hashAlg)
        {
            HashAlgorithm hashAlgorithm;

            if (hashAlg == sha512)
                hashAlgorithm = new SHA512CryptoServiceProvider();
            else
                hashAlgorithm = new SHA1CryptoServiceProvider();

            return hashAlgorithm;
        }

        public static byte[] GetEds(byte[] data, string hashAlg, string cryptAlg)
        {
            HashAlgorithm hashAlgorithm = GetHashAlgoritm(hashAlg);
            byte[] eds;

            if (cryptAlg == dsa)
                eds = dsaCsp.SignData(data);
            else
                eds = rsaCsp.SignData(data, hashAlgorithm);

            return eds;
        }

        public static bool CheckEds(byte[] eds, byte[] data, string hashAlg, string cryptAlg)
        {
            HashAlgorithm hashAlgorithm = GetHashAlgoritm(hashAlg);
            bool check;

            if (cryptAlg == dsa)
                check = dsaCsp.VerifyData(data, eds);
            else
                check = rsaCsp.VerifyData(data, hashAlgorithm, eds);

            return check;
        }

        public static bool CheckEds(byte[] eds, byte[] data, string hashAlg, string cryptAlg, byte[] pubKey)
        {
            HashAlgorithm hashAlgorithm = GetHashAlgoritm(hashAlg);
            CspParameters localCspParameters = new CspParameters();
            bool check;

            if (cryptAlg == dsa)
            {
               localCspParameters.ProviderType = 13;
               DSACryptoServiceProvider localDsaCsp = new DSACryptoServiceProvider(localCspParameters);
               localDsaCsp.ImportCspBlob(pubKey);
               check = localDsaCsp.VerifyData(data, eds);
            }
            else
            {
                localCspParameters.ProviderType = 1;
                RSACryptoServiceProvider localDsaCsp = new RSACryptoServiceProvider(localCspParameters);
                localDsaCsp.ImportCspBlob(pubKey);
                check = localDsaCsp.VerifyData(data, hashAlgorithm, eds);
            }

            return check;
        }

        public static bool CspContainerExists(string containerName) {
            var localCspParameters = new CspParameters
            {
                Flags = CspProviderFlags.UseExistingKey,
                KeyContainerName = containerName
            };

            try
            {
                var localRsaCsp = new RSACryptoServiceProvider(localCspParameters);
                //var locaDsaCsp = new DSACryptoServiceProvider(localCspParameters);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public static void SetExistingCspContainerByNameCurrent(string name)
        {
            if (!CspContainerExists(name))
                throw new InvalidOperationException("this container not exist");

            cspParameters = new CspParameters()
            {
                KeyContainerName = name,
            };
            cspParameters.ProviderType = 1;
            rsaCsp = new RSACryptoServiceProvider(cspParameters);
            cspParameters.ProviderType = 13;
            dsaCsp = new DSACryptoServiceProvider(cspParameters);
        }

        public static void CreateCspContainerByName(string name)
        {
            if (CspContainerExists(name))
                throw new InvalidOperationException("CspContainer with this name already exist");

            CspParameters localCspParametrs = new CspParameters()
            {
                KeyContainerName = name,
            };
            localCspParametrs.ProviderType = 1;
            var q = new RSACryptoServiceProvider(localCspParametrs);
            localCspParametrs.ProviderType = 13;
            var k = new DSACryptoServiceProvider(localCspParametrs);
        }

        public static byte[] GetCurrentPublicKey(string cryptAlg)
        {
            byte[] keyBlob;

            if (cryptAlg == dsa)
                keyBlob = dsaCsp.ExportCspBlob(false);
            else
                keyBlob = rsaCsp.ExportCspBlob(false);

            return keyBlob;
        }

        public static void RemoveKeysByName(string cName)
        {
            if (!CspContainerExists(cName)) return;
            CspParameters localCspParametrs = new CspParameters()
            {
                KeyContainerName = cName,
                Flags = CspProviderFlags.UseExistingKey,
            };
            var q = new RSACryptoServiceProvider(localCspParametrs);
            var k  = new RSACryptoServiceProvider(localCspParametrs);
            q.PersistKeyInCsp = false;
            q.Clear();
            k.PersistKeyInCsp = false;
            k.Clear();
        }
    }
}
