using System.IO;

namespace lab.crosscutting
{
    public static class FileUtilities
    {
        public static void CreateFolderIfNotExists(string path)
        {
            if (!FileUtilities.ExistsFolder(path))
            {
                FileUtilities.CreateFolder(path);
            }
        }

        public static bool ExistsFolder(string path)
        {
            return Directory.Exists(path);
        }

        public static void CreateFolder(string path)
        {
            Directory.CreateDirectory(path);
        }
    }
}
