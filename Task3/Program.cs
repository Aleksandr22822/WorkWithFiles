using System.Drawing;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Task3;

internal class Program
{

    public static void Main()
    {

        string path = @"\SkillFactory\Res";
        DirInspection(path);


    }
    static void DirInspection(string path)
    {
        if (!Directory.Exists(path))
        {
            return;
        }
        DirectoryInfo d = new DirectoryInfo(path);
        var CountsStart = GetFilesCountInDirectory(d);
        Console.WriteLine($"Файлов до удаления {CountsStart}");
        var start = DirSize(d);
        Console.WriteLine($"Исходный размер папки: {start} байтов");
        DeleteDir(path);
        var end = DirSize(d);
        var CountsFinish = CountsStart - GetFilesCountInDirectory(d);
        Console.WriteLine($"Файлов удалено {CountsFinish}");
        Console.WriteLine($"Освобождено: {(start - end)} байтов");
        Console.WriteLine($"Текущий размер папки: {end} байтов");
    }

    private static long DirSize(DirectoryInfo d)
    {
        long size = 0;
        try
        {
            var fis = d.GetFiles();
            
           
            foreach (var fi in fis)
            {
                size += fi.Length;
            }

            var dis = d.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                size += DirSize(di);
            }
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return size;
    }

    static int GetFilesCountInDirectory(DirectoryInfo d)
    {
        int count = d.GetFiles().Length;

        DirectoryInfo[] subDirectories = d.GetDirectories();
        foreach (DirectoryInfo subDirectory in subDirectories)
        {
            count += GetFilesCountInDirectory(subDirectory);
        }

        return count;
    }

    private static void DeleteDir(string path)
     {
         var del = new int[] { };
         //Список под папок
         var dirs = Directory.GetDirectories(path);
         //Удаление под каталогов
         foreach (var dir in dirs)
             try
             {
                 Directory.Delete(dir, true);
             }
             catch (IOException e)
             {
                 Console.WriteLine($"Для директории {dir} установлен статус {e.Message}");
             }

         //Список файлов
         var files = Directory.GetFiles(path);
         //Удаление файлов
         foreach (var file in files)
             try
             {
                 File.Delete(file);
             }
             catch (Exception e)
             {
                 Console.WriteLine($"Для файла {file} установлен статус {e.Message}");
                 throw;
             }
     }
}