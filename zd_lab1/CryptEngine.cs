using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zd_lab1
{
    public enum HashAlg
    {
        sha512,
        sha1
    }

    public enum CryptAlg
    {
        rsa,
        dsa
    }

    class CryptEngine
    {
        
        private const string rsa = "RSA";
        private const string dsa = "DSA";
        private const string sha1 = "SНA1";
        private const string sha512 = "SНA512";

        private static CspParameters cspParameters;
        private static RSACryptoServiceProvider dsaCsp;
        private static RSACryptoServiceProvider rsaCsp;


        public static HashAlgorithm GetHashAlgoritm(string hashAlg) {
            HashAlgorithm hashAlgorithm;
            if (hashAlg == sha512)
            {
                hashAlgorithm = new SHA512CryptoServiceProvider();
            }
            else
            {
                hashAlgorithm = new SHA1CryptoServiceProvider();
            }
            return hashAlgorithm;
        }

        public static byte[] GetEds(byte[] data, string hashAlg, string cryptAlg)
        {
            HashAlgorithm hashAlgorithm = GetHashAlgoritm(hashAlg);

            if (cryptAlg == dsa)
                return dsaCsp.SignData(data, hashAlgorithm);
            else
                return rsaCsp.SignData(data, hashAlgorithm);
        }

        public static bool CheckEds(byte[] eds, byte[] data, string hashAlg, string cryptAlg)
        {
            HashAlgorithm hashAlgorithm = GetHashAlgoritm(hashAlg);

            if (cryptAlg == dsa)
                return dsaCsp.VerifyData(data, hashAlgorithm, eds);
            else
                return rsaCsp.VerifyData(data, hashAlgorithm, eds);
        }

        public static bool CheckEds(byte[] eds, byte[] data, string hashAlg, string cryptAlg, byte[] pubKey)
        {
            HashAlgorithm hashAlgorithm = GetHashAlgoritm(hashAlg);
            CspParameters localCspParameters = new CspParameters();

            if (cryptAlg == dsa)
            {
                localCspParameters.ProviderType = 1;
                RSACryptoServiceProvider localDsaCsp = new RSACryptoServiceProvider(localCspParameters);
                localDsaCsp.ImportCspBlob(pubKey);
                return localDsaCsp.VerifyData(data, hashAlgorithm, eds);
            }
            else
            {
                localCspParameters.ProviderType = 1;
                RSACryptoServiceProvider localRsaCsp = new RSACryptoServiceProvider(localCspParameters);
                localRsaCsp.ImportCspBlob(pubKey);
                return localRsaCsp.VerifyData(data, hashAlgorithm, eds);
            }
        }
/*
        public static byte[] GetHash(byte[] data, HashAlg alg)
        {
            HashAlgorithm hashAlgorithm;
            if (alg == HashAlg.sha512)
                hashAlgorithm = new SHA512Managed();
            else
                hashAlgorithm = new SHA1Managed();

            return hashAlgorithm.ComputeHash(data);
        }

        public static byte[] GetEds(byte[] data, HashAlg hashAlg, CryptAlg cryptAlg)
        {
            byte[] hash = GetHash(data, hashAlg);
            if (cryptAlg == CryptAlg.dsa)
                return dsaCsp.SignHash(hash, "SHA1");
            else
                return rsaCsp.SignHash(hash, "SHA1");
        }

        public static bool CheckEDS(byte[] eds, byte[] data, HashAlg hashAlg, CryptAlg cryptAlg)
        {
            byte[] hash = GetHash(data, hashAlg);
            if (cryptAlg == CryptAlg.dsa)
                return dsaCsp.VerifyHash(hash, "SHA1", eds);
            else
                return rsaCsp.VerifyHash(hash, "SHA1", eds);
        }

        public static bool CheckEDS(byte[] eds, byte[] document, HashAlg hashAlg, CryptAlg cryptAlg, byte[] pubKey)
        {
            byte[] hash = GetHash(document, hashAlg);
            CspParameters localCspParameters = new CspParameters()
            {

            };

            if (cryptAlg == CryptAlg.dsa)
            {
                localCspParameters.ProviderType = 1;
                RSACryptoServiceProvider localDsaCsp = new RSACryptoServiceProvider(localCspParameters);
                localDsaCsp.ImportCspBlob(pubKey);
                return localDsaCsp.VerifyHash(hash, "SHA1", eds);
            }
            {
                localCspParameters.ProviderType = 1;
                RSACryptoServiceProvider localRsaCsp = new RSACryptoServiceProvider(localCspParameters);
                localRsaCsp.ImportCspBlob(pubKey);
                return localRsaCsp.VerifyHash(hash, "SHA1", eds);
            }
        }
*/
        public static bool CspContainerExists(string containerName)
        {
            var localCspParameters = new CspParameters
            {
                Flags = CspProviderFlags.UseExistingKey,
                KeyContainerName = containerName
            };

            try
            {
                var localDsaCsp = new RSACryptoServiceProvider(localCspParameters);
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
            dsaCsp = new RSACryptoServiceProvider(cspParameters);
            cspParameters.ProviderType = 1;
            rsaCsp = new RSACryptoServiceProvider(cspParameters);
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
        }

        public static byte[] GetCurrentPublicKey()
        {
            return dsaCsp.ExportCspBlob(false);
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
            q.PersistKeyInCsp=false;
            q.Clear();
        }
    }
}
