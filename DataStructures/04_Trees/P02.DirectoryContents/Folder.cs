namespace P02.DirectoryContents
{
    using System.Collections.Generic;

    public class Folder
    {
        private long size;

        public Folder(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public IList<File> Files { get; set; }

        public IList<Folder> ChildFolders { get; set; }

        public long Size
        {
            get
            {
                // Return folder size if is already calculated
                if (this.size != 0 || (this.Files.Count == 0 && this.ChildFolders.Count == 0))
                {
                    return this.size;
                }

                foreach (var file in this.Files)
                {
                    this.size += file.Size;
                }

                foreach (var subFolder in this.ChildFolders)
                {
                    // Calculate each subFolder size recursively
                    this.size += subFolder.Size;
                }

                return this.size;
            }
        }
    }
}
