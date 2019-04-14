using System;
using System.IO;

namespace Polia02.Tools
{
    internal static class FileFolderHelper
    {
        private static readonly string AppDataPath =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        internal static readonly string ClientFolderPath =
            Path.Combine(AppDataPath, "Polia04");

        internal static readonly string LastUserFilePath =
            Path.Combine(ClientFolderPath, "Users.walsim");

        internal static void CheckAndCreateFile(string filePath)
        {
            try
            {
                FileInfo file = new FileInfo(filePath);
                if (!file.Directory.Exists)
                {
                    file.Directory.Create();
                }
                if (!file.Exists)
                {
                    file.Create().Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        internal static bool FileExists(string path)
        {
            FileInfo file = new FileInfo(path);
            return file.Exists;
        }

        internal static void CheckAndDeleteFile(string path)
        {
            try
            {
                FileInfo file = new FileInfo(path);
                if (file.Exists)
                {
                    file.Delete();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}
