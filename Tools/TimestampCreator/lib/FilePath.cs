using System.IO;
using System.Reflection;

namespace BeatThis.Tools
{
    class FilePath
    {
        public static void CheckFileExistsAndHasExtension(string filePath)
        {
            if (!File.Exists(filePath) || !Path.HasExtension(filePath))
            {
                throw new FileNotFoundException(string.Format("Path {0} is not correct!", filePath));
            }
        }

        public static string GetResourceFile(string resourceFilePath)
        {
            string exeFile = new System.Uri(Assembly.GetEntryAssembly().CodeBase).AbsolutePath;
            string exeDir = Path.GetDirectoryName(exeFile);
            return Path.Combine(exeDir, "..\\..\\resources\\" + resourceFilePath);
        }
    }
}
