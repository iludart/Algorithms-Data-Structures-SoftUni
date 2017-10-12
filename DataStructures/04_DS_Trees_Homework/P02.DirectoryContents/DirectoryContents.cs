namespace P02.DirectoryContents
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class DirectoryContents
    {
        private static Dictionary<string, Folder> foldersDictionary;

        static void Main()
        {
            const string RootFolderPath = @"D:\Torrentz";
            Folder rootFolder = new Folder(RootFolderPath);

            foldersDictionary = new Dictionary<string, Folder>();
            TraverseFolder(rootFolder);
            long size = foldersDictionary[RootFolderPath].Size;
        }

        static void TraverseFolder(Folder folder)
        {
            var info = new DirectoryInfo(folder.Name);

            if (!foldersDictionary.ContainsKey(folder.Name))
            {
                foldersDictionary.Add(folder.Name, folder);
            }

            folder.ChildFolders = info.GetDirectories().Select(x => new Folder(x.FullName)).ToArray();
            folder.Files = info.GetFiles().Select(f => new File(f.FullName, (int)f.Length)).ToArray();

            foreach (var childFolder in folder.ChildFolders)
            {
                TraverseFolder(childFolder);
            }
        }
    }
}
