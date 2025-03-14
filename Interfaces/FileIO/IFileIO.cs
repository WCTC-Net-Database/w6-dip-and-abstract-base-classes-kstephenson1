﻿namespace w6_assignment_ksteph.Interfaces.FileIO;

public interface IFileIO
{
    List<T> Read<T>(string dir);
    void Write<T>(List<T> t, string dir);
}
