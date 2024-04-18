namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x;
            do
            {
                DirectoryInfo d = new DirectoryInfo(@"\SkillFactory\Res");
                if (d.Exists)
                {
                    x = 1;
                    Console.WriteLine($"Объём директории {DirSize(d) } байтов");
                }
                else
                {
                    x = 0;
                    Console.WriteLine("Неверно указан путь до директории");
                }
            } while (x == 0);
           


        }
        public static long DirSize(DirectoryInfo d)
        {
            long size = 0;
            try
            {
                // Размер файла.
                var fis = d.GetFiles();
                foreach (var fi in fis)  
                {
                    size += fi.Length;
                }
                // Размер папки.
                var dis = d.GetDirectories();
                foreach (DirectoryInfo di in dis)
                {
                    size += DirSize(di);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            return size;
        }
    }
}
