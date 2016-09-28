using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace LargeDirCopy
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Moves all files in given directory to target directory");
                Console.WriteLine("Incorrect parameters");
                Console.WriteLine("Usage: dotnet LargeDirCopy.dll SOURCEDIRECTORY TARGETDIRECTORY");
                Console.WriteLine("Example: dotnet LargeDirCopy.dll /var/www/web /backup/web");
            }

            var sourcePath = args[0];
            var targetDirectory = args[1];

            CopyAll(sourcePath, targetDirectory);
        }

        private static void CopyAll(string sourceDirectory, string targetDirectory)
        {
            var files = Directory.EnumerateFiles(sourceDirectory);
            Parallel.ForEach(files, f => CopyFile(f, targetDirectory));
        }

        private static void CopyFile(string sourcePath, string targetDirectory)
        {
            try
            {
                var fileName = Path.GetFileName(sourcePath);
                var targetPath = Path.Combine(targetDirectory, fileName);
                File.Move(sourcePath, targetPath);
                Debug.WriteLine(sourcePath);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to copy {sourcePath}. {ex}");
            }
        }
    }
}