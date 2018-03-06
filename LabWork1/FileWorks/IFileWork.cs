using System;
using LabWork1.Solution;

namespace LabWork1.FileWorks
{
    interface IFileWork
    {
        String ReadFromFile();
        void WriteIntoTheFile(Algorithms algo);
    }
}
