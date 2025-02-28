namespace w6_assignment_ksteph.FileIO;

using w6_assignment_ksteph.FileIO.Csv;
using w6_assignment_ksteph.FileIO.Json;
using w6_assignment_ksteph.DataTypes;
using w6_assignment_ksteph.Entities.Characters;
using w6_assignment_ksteph.Entities.Monsters;
using w6_assignment_ksteph.Items.WeaponItems;
using w6_assignment_ksteph.Items;
using w6_assignment_ksteph.Configuration;

public class FileManager<T>
{
    // FileManager contains redirects to functions that assist with file IO functions.  This class allows the import and export of a generic
    // unit type.

    private static FileType _fileType = Config.DEFAULT_FILE_TYPE;

    private Type _type = typeof(T);
    private Dictionary<Type, int> _typeDict = new()
    {
            {typeof(Character),0},
            {typeof(Monster),1},
            {typeof(WeaponItem),2},
        };

    private string GetFilePath()
    {
        return _typeDict[_type] switch
        {
            0 => "Files/characters",
            1 => "Files/monsters",
            2 => "Files/weapons",
            _ => throw new ArgumentOutOfRangeException($"GetFilePath() has invalid type ({_typeDict})")
        };

    }

    private static IFileIO GetFileType<T>() // Checks to see what the current file type is set to and execute the proper file system.
    {
        return _fileType switch
        {
            FileType.Csv => new CsvFileHandler<T>(),
            FileType.Json => new JsonFileHandler<T>(),
            _ => throw new NullReferenceException("Error: File type not found in FileManager.GetFileType()"),
        };
    }

    public static void SwitchFileType()
    {
        Console.Clear();
        if (_fileType == FileType.Csv)
        {
            Console.WriteLine("File format set to Json.");
            _fileType = FileType.Json;
        } else
        {
            Console.WriteLine("File format set to Csv.");
            _fileType = FileType.Csv;
        }
    }

    public List<T> Import<T>() => GetFileType<T>().Read<T>(GetFilePath());
    public void Export<T>(List<T> tList) => GetFileType<T>().Write<T>(tList, GetFilePath());
}
