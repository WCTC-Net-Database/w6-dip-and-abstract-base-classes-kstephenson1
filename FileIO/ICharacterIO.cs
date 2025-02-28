namespace w6_assignment_ksteph.FileIO;

public interface ICharacterIO : IFileIO
{
    new List<TUnit> Read<TUnit>(string dir);
    new void Write<TUnit>(List<TUnit> unit, string dir);
}
