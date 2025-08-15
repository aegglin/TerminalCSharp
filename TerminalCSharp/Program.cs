
class Program
{
    public static void FindRecentUpdates(string path)
    {
        try
        {
            DirectoryInfo di = new DirectoryInfo(path);
            foreach (FileInfo fi in di.GetFiles())
            {
                if (fi.LastWriteTime >= DateTime.Now.AddDays(-1))
                {
                    Console.WriteLine($"{fi.FullName}");
                }
            }
            foreach (DirectoryInfo dirInfo in di.GetDirectories())
            {
                FindRecentUpdates(dirInfo.FullName);
            }
        }
        catch (UnauthorizedAccessException e)
        {
            Console.Error.WriteLine($"{e} -- Access Denied. Please try another file.");
        }
        catch (IOException e)
        {
            Console.Error.WriteLine($"{e} -- Couldn't find {path}");
        }
    }


    static void Main(string[] args)
    {
        if (args.Length != 1)
        {
            Console.WriteLine("Please enter a file directory only.");
            return;
        }
        Console.WriteLine("Files updated in the last week: ");
        string path = args[0];
        FindRecentUpdates(path);
    }
}
