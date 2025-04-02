using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainForm.Repositories;
using MainForm.Models;

namespace MainForm.Services
{
    class ExplorerService
    {
        private const int ROOT_ID = 1;
        private readonly FileRepository fileRepository;
        private static readonly string dbPath = Path.Combine("..", "..", "..", "file.db");
        public List<DirectoryTreeNode> DirectoryTree { get; private set; }
        public List<FileItemDto> FileCache { get; private set; }
        public List<FileItemDto> ProcessedFileList { get; set; }

        public ExplorerService()
        {
            fileRepository = new FileRepository(dbPath);
            RefreshDirectoryTree();
            RefreshFileCache(ROOT_ID);
        }

        public void RefreshDirectoryTree()
        {
            DirectoryTree = DirectoryTreeService
                .BuildDirectoryTree(fileRepository.SelectItems(null, directoriesOnly: true));
        }

        public void RefreshFileCache(int parentId)
        {
            FileCache = fileRepository.SelectItems(parentId);
        }

        public void RefreshProcessedFileList()
        {
            ProcessedFileList = FileCache
                .OrderByDescending(f => f.IsDirectory)
                .ThenBy(f => f.Name)
                .ToList();
        }
    }
}
