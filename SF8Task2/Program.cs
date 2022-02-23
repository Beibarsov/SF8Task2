// See https://aka.ms/new-console-template for more information


List<DirectoryInfo> AllDirs = new List<DirectoryInfo>();


Console.WriteLine("Введите путь к папке");
string path = Console.ReadLine();

Console.WriteLine($"Все файлы вешают {GetLenght(path)} байт");


long GetLenght(string path)
{

    if (!Directory.Exists(path))
    {
        Console.WriteLine("Такой директории не существует, соответственно её вес - 0");
        return 0;
    }
    long sum = 0;
    DirectoryInfo dir = new DirectoryInfo(path);
    AllDirs.Add(dir);
    GetAllDirectories(dir);

    try
    {


        foreach (DirectoryInfo d in AllDirs)
        {

            FileInfo[] files = d.GetFiles();
            foreach (FileInfo f in files)
            {
                Console.WriteLine(f.FullName);
                Console.WriteLine(f.Length);
                sum += f.Length;
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }
    return sum;
}

void GetAllDirectories(DirectoryInfo dir)
{
    try
    {

        DirectoryInfo[] dirs = dir.GetDirectories();
        foreach (DirectoryInfo d in dirs)
        {
            AllDirs.Add(d);
            GetAllDirectories(d);

        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }
}

