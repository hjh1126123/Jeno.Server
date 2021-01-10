using Jeno.Common.Features;
using Masuit.Tools;
using Masuit.Tools.Security;

namespace Jeno.Common.Utils
{
    /// <summary>
    /// 加密解密工具类
    /// </summary>
    [DI(AutoFacInstanceType = Enum.AutoFacInstanceType.SingleInstance)]
    public class SecurityUtils
    {
        public SecurityUtils()
        {
        }


        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="content">密文原文</param>
        /// <param name="count">多重加密次数（默认1次，最多3次，非范围内值则为默认1次）</param>
        /// <param name="salt">盐值（默认不加盐）</param>
        /// <returns></returns>
        public string MD5Encrypt(string content, int count = 1, string salt = null)
        {
            switch (count)
            {
                case 1:
                    if (string.IsNullOrWhiteSpace(salt))
                    {
                        return content.MDString();
                    }
                    else
                    {
                        return content.MDString(salt);
                    }
                case 2:
                    if (string.IsNullOrWhiteSpace(salt))
                    {
                        return content.MDString2();
                    }
                    else
                    {
                        return content.MDString2(salt);
                    }

                case 3:
                    if (string.IsNullOrWhiteSpace(salt))
                    {
                        return content.MDString3();
                    }
                    else
                    {
                        return content.MDString3(salt);
                    }

                default:
                    if (string.IsNullOrWhiteSpace(salt))
                    {
                        return content.MDString();
                    }
                    else
                    {
                        return content.MDString(salt);
                    }
            }
        }

        /// <summary>
        /// Aes加密
        /// </summary>
        /// <param name="content">密文原文</param>
        /// <param name="password">密钥</param>
        /// <returns></returns>
        public string AESEncrypt(string content, string password)
        {
            return content.AESEncrypt(password);
        }

        /// <summary>
        /// Aes解密
        /// </summary>
        /// <param name="ciphertext">密文</param>
        /// <param name="password">密钥</param>
        /// <returns></returns>
        public string AESDecrypt(string ciphertext, string password)
        {
            return ciphertext.AESDecrypt(password);
        }

        /// <summary>
        /// Des加密
        /// </summary>
        /// <param name="content">密文原文</param>
        /// <param name="password">密钥（密钥必须为8位）</param>
        /// <returns></returns>
        public string DesEncrypt(string content, string password)
        {
            return content.DesEncrypt(password);
        }

        /// <summary>
        /// Des解密
        /// </summary>
        /// <param name="ciphertext">密文</param>
        /// <param name="password">密钥</param>
        /// <returns></returns>
        public string DesDecrypt(string ciphertext, string password)
        {
            return ciphertext.DesDecrypt(password);
        }

        /// <summary>
        /// 生成rsa秘钥
        /// </summary>
        /// <param name="rsaKeyType">密钥类型</param>
        /// <param name="length">密钥长度</param>
        /// <returns></returns>
        public RsaKey GenerateRsaKeys(RsaKeyType rsaKeyType = RsaKeyType.XML, int length = 1024)
        {
            return RsaCrypt.GenerateRsaKeys(rsaKeyType, length);
        }

        /// <summary>
        /// rsa加密
        /// </summary>
        /// <param name="content">密文原文</param>
        /// <param name="rsaPublicKey">签证公钥</param>
        /// <returns></returns>
        public string RSAEncrypt(string content, string rsaPublicKey)
        {
            return content.RSAEncrypt(rsaPublicKey);
        }

        /// <summary>
        /// rsa解密
        /// </summary>
        /// <param name="ciphertext">密文</param>
        /// <param name="rsaPrivateKey">签证私钥</param>
        /// <returns></returns>
        public string RSADecrypt(string ciphertext, string rsaPrivateKey)
        {
            return ciphertext.RSADecrypt(rsaPrivateKey);
        }

        /// <summary>
        /// 生成crc摘要
        /// </summary>
        /// <param name="content">内容</param>
        /// <param name="is32"></param>
        /// <returns></returns>
        public string Crc32(string content, bool is32 = true)
        {
            if (is32)
            {
                return content.Crc32();
            }
            else
            {
                return content.Crc64();
            }
        }
    }
}
