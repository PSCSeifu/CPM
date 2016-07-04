using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CPM.Business.Global.Account
{
    public class Encryption
    {
        #region " Symmetric "

        public class Symmetric
        {

            #region " Properties "

            private SymmetricAlgorithm _crypto;
            private Data _key;

            private Data _iv;

            public Symmetric()
            {
                //Algorithm
                _crypto = new TripleDESCryptoServiceProvider();

                //Key
                _key = new Data("pscpayroll");
                _key.MaxBytes = _crypto.LegalKeySizes[0].MaxSize / 8;
                _key.MinBytes = _crypto.LegalKeySizes[0].MinSize / 8;
                _key.StepBytes = _crypto.LegalKeySizes[0].SkipSize / 8;

                //Initializer
                _iv = new Data("%1Az=-@qT");
                _iv.MaxBytes = _crypto.BlockSize / 8;
                _iv.MinBytes = _crypto.BlockSize / 8;
            }

            #endregion

            #region " Methods "

            public Data Encrypt(Data d)
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();

                _crypto.Key = _key.Bytes;
                _crypto.IV = _iv.Bytes;

                CryptoStream cs = new CryptoStream(ms, _crypto.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(d.Bytes, 0, d.Bytes.Length);
                cs.Close();
                ms.Close();

                return new Data(ms.ToArray());
            }

            public Data Decrypt(Data encryptedData)
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream(encryptedData.Bytes, 0, encryptedData.Bytes.Length);
                byte[] b = new byte[encryptedData.Bytes.Length];

                _crypto.Key = _key.Bytes;
                _crypto.IV = _iv.Bytes;

                CryptoStream cs = new CryptoStream(ms, _crypto.CreateDecryptor(), CryptoStreamMode.Read);

                try
                {
                    cs.Read(b, 0, encryptedData.Bytes.Length - 1);
                }
                catch (CryptographicException ex)
                {
                    throw new CryptographicException("Unable to decrypt data. The provided key may be invalid.", ex);
                }
                finally
                {
                    cs.Close();
                }
                return new Data(b);
            }

            #endregion

        }

        #endregion

        #region " Data "

        public class Data
        {

            #region " Properties "

            private byte[] _b;

            public int MaxBytes { get; set; }
            public int MinBytes { get; set; }

            public int StepBytes { get; set; }
            private System.Text.Encoding _Encoding;

            public bool IsEmpty
            {
                get
                {
                    if (_b == null)
                    {
                        return true;
                    }
                    if (_b.Length == 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            public byte[] Bytes
            {
                get
                {
                    if (MaxBytes > 0)
                    {
                        if (_b.Length > MaxBytes)
                        {
                            byte[] b = new byte[MaxBytes];
                            Array.Copy(_b, b, b.Length);
                            _b = b;
                        }
                    }
                    if (MinBytes > 0)
                    {
                        if (_b.Length < MinBytes)
                        {
                            byte[] b = new byte[MinBytes];
                            Array.Copy(_b, b, _b.Length);
                            _b = b;
                        }
                    }
                    return _b;
                }
                set { _b = value; }
            }

            public string Text
            {
                get
                {
                    if (_b == null)
                    {
                        return "";
                    }
                    else
                    {
                        //-- need to handle nulls here; oddly, C# will happily convert
                        //-- nulls into the string whereas VB stops converting at the
                        //-- first null!
                        int i = Array.IndexOf(_b, Convert.ToByte(0));
                        if (i >= 0)
                        {
                            return _Encoding.GetString(_b, 0, i);
                        }
                        else
                        {
                            return _Encoding.GetString(_b);
                        }
                    }
                }
                set { _b = _Encoding.GetBytes(value); }
            }

            public string Base64
            {
                get { return ToBase64(_b); }
                set { _b = FromBase64(value); }
            }
            public Data()
            {
                _Encoding = System.Text.Encoding.GetEncoding("Windows-1252");
            }

            public Data(byte[] b)
                : this()
            {
                _b = b;
            }

            public Data(string s)
                : this()
            {
                this.Text = s;
            }

            #endregion

            #region " Methods "

            public new string ToString()
            {
                return this.Text;
            }

            private byte[] FromBase64(string base64Encoded)
            {
                if (base64Encoded == null || base64Encoded.Length == 0)
                {
                    return null;
                }
                try
                {
                    return Convert.FromBase64String(base64Encoded);
                }
                catch (System.FormatException ex)
                {
                    throw new System.FormatException("The provided string does not appear to be Base64 encoded:" + Environment.NewLine + base64Encoded + Environment.NewLine, ex);
                }
            }

            private string ToBase64(byte[] b)
            {
                if (b == null || b.Length == 0)
                {
                    return "";
                }
                return Convert.ToBase64String(b);
            }

            #endregion

        }

        #endregion
    }
}
