using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

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
        private static CspParameters cspParameters;
        private static RSACryptoServiceProvider rsaCsp;
        private static RSACryptoServiceProvider dsaCsp;

        public static byte[] GetHash(byte[] data, HashAlg alg)
        {
            HashAlgorithm hashAlgorithm;
            if (alg == HashAlg.sha512)
                hashAlgorithm = new SHA512Managed();
            else
                hashAlgorithm = new SHA1Managed();

            return hashAlgorithm.ComputeHash(data);
        }

        public static byte[] GetEds(byte[] document, HashAlg hashAlg, CryptAlg cryptAlg)
        {
            byte[] hash = GetHash(document, hashAlg);
            if (cryptAlg == CryptAlg.rsa)
                return rsaCsp.SignHash(hash, "SHA1");
            else
                return dsaCsp.SignHash(hash, "SHA1");
        }

        public static bool CheckEDS(byte[] eds, byte[] document, HashAlg hashAlg, CryptAlg cryptAlg)
        {
            byte[] hash = GetHash(document, hashAlg);
            if (cryptAlg == CryptAlg.rsa)
                return rsaCsp.VerifyHash(hash, "SHA1", eds);
            else
                return dsaCsp.VerifyHash(hash, "SHA1", eds);
        }

        public static bool CheckEDS(byte[] eds, byte[] document, HashAlg hashAlg, CryptAlg cryptAlg, byte[] pubKey)
        {
            byte[] hash = GetHash(document, hashAlg);
            CspParameters localCspParameters = new CspParameters()
            {

            };

            if (cryptAlg == CryptAlg.rsa)
            {
                localCspParameters.ProviderType = 1;
                RSACryptoServiceProvider localRsaCsp = new RSACryptoServiceProvider(localCspParameters);
                localRsaCsp.ImportCspBlob(pubKey);
                return localRsaCsp.VerifyHash(hash, "SHA1", eds);
            }
            {
                localCspParameters.ProviderType = 1;
                RSACryptoServiceProvider localDsaCsp = new RSACryptoServiceProvider(localCspParameters);
                localDsaCsp.ImportCspBlob(pubKey);
                return localDsaCsp.VerifyHash(hash, "SHA1", eds);
            }
        }

        public static bool CspContainerExists(string containerName)
        {
            var localCspParameters = new CspParameters
            {
                Flags = CspProviderFlags.UseExistingKey,
                KeyContainerName = containerName
            };

            try
            {
                var localRsaCsp = new RSACryptoServiceProvider(localCspParameters);
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
            cspParameters.ProviderType = 1;
            dsaCsp = new RSACryptoServiceProvider(cspParameters);
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
            return rsaCsp.ExportCspBlob(false);
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
