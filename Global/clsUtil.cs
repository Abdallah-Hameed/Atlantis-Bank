using AtlantisBank.BLL;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Atlantis_Bank
{
    public class clsUtil
    {
        public static void CreateEventLog(Exception ex, EventLogEntryType eventType = EventLogEntryType.Warning)
        {
            string SourceName = "AtlantisBank";

            try
            {
                if (!EventLog.SourceExists(SourceName, "."))
                {
                    EventLog.CreateEventSource(SourceName, "Application");
                }

                string Message = "Message: " + ex.Message + Environment.NewLine + "Stack Trace: " + ex.StackTrace;

                EventLog.WriteEntry(SourceName, Message, eventType);
            }

            catch
            {
            }
        }

        static string GeneerateGUID()
        {
            Guid g = Guid.NewGuid();

            return g.ToString();
        }

        static bool CreateFolderIfDoesNotExist(string FolderPath)
        {
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    Directory.CreateDirectory(FolderPath);

                    return true;
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }
            }

            return true;
        }

        static string ReplaceFileNameWithGUID(string SourceFile)
        {
            FileInfo fi = new FileInfo(SourceFile);

            return GeneerateGUID() + fi.Extension;
        }

        public static bool CopyImageToProjectImagesFolder(ref string SourceFile)
        {
            if (!CreateFolderIfDoesNotExist(@"C:\AtlantisBank-People-Images\"))
                return false;

            string destinationFile = @"C:\AtlantisBank-People-Images\" + ReplaceFileNameWithGUID(SourceFile);

            try
            {
                File.Copy(SourceFile, destinationFile, true);
            }

            catch (IOException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            SourceFile = destinationFile;

            return true;
        }

        public static bool RememberUsernameAndPassword(string Username, string Password)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Atlantis Bank"))
                {
                    if (Username == "")
                    {
                        key.DeleteValue("Credentials", false);

                        return true;
                    }

                    key.SetValue("Credentials", Username + "#//#" + Password);

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");

                return false;
            }
        }

        public static bool GetStoredCredential(ref string Username, ref string Password)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Atlantis Bank"))
                {
                    if (key == null) return false;

                    string value = key.GetValue("Credentials") as string;

                    if (value == null) return false;

                    string[] result = value.Split(new string[] { "#//#" }, StringSplitOptions.None);

                    Username = result[0];

                    Password = result[1];

                    return true;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");

                return false;
            }
        }

        public static string ComputeHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));

                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        private static readonly byte[] Key = Encoding.UTF8.GetBytes("AtlantisBankKey1");

        private static readonly byte[] IV = Encoding.UTF8.GetBytes("AtlantisBankIV12");

        public static string Encrypt(string plainText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;

                aes.IV = IV;

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);

                        cryptoStream.Write(plainBytes, 0, plainBytes.Length);

                        cryptoStream.FlushFinalBlock();
                    }

                    return Convert.ToBase64String(memoryStream.ToArray());
                }
            }
        }

        public static string Decrypt(string cipherText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;

                aes.IV = IV;

                byte[] cipherBytes = Convert.FromBase64String(cipherText);

                using (MemoryStream memoryStream = new MemoryStream(cipherBytes))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cryptoStream))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
