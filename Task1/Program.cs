using System.IO;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            if (Directory.Exists(@"\SkillFactory\Res"))
            {
                try
                {
                    var di = new DirectoryInfo(@"\SkillFactory\Res");
                    DateTime LastAccessTime = Directory.GetLastAccessTime(@"\SkillFactory\Res");
                    DateTime currentTime = DateTime.Now;
                    TimeSpan timeDifference = currentTime - LastAccessTime;
                    if (timeDifference > TimeSpan.FromMinutes(30))
                    {
                        foreach (DirectoryInfo directories in di.GetDirectories())
                        {
                            directories.Delete(true);
                        }
                    }
                    DateTime lastAccessTimeFiles = File.GetLastAccessTime(@"\SkillFactory\Res");
                    DateTime currentTimeFiles = DateTime.Now;
                    TimeSpan timeDifferenceFiles = currentTimeFiles - lastAccessTimeFiles;
                    if (timeDifference > TimeSpan.FromMinutes(30))
                    {
                        foreach (FileInfo files in di.GetFiles())
                        {
                            files.Delete();
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла ошибка: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Указанная Вами директория не существует");
            }
        }
    }
}
