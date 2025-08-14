
class Program
{

    public static void ReadDirectory(string path)
    {
        DirectoryInfo di = new DirectoryInfo(path);
        Console.WriteLine("The path in ReadDirectory is: ", path);
        try
        {
            foreach (FileInfo fi in di.GetFiles())
            {
                Console.WriteLine($"Name is: {fi.Name}, full name is: {fi.FullName}");
                if (File.Exists(path))
                {
                    System.Console.WriteLine($"{fi.FullName} is a file, not a directory");
                }
                else if (Directory.Exists(path))
                {
                    System.Console.WriteLine($"{fi.FullName} is a directory, not a file");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Couldn't find {path}");
        }
    }

    static void Main(string[] args)
    {
        string path = Path.Join(@"C:\", "Users", "Aiden", "dev");
        Console.WriteLine(path);
        ReadDirectory(path);
    }
}
