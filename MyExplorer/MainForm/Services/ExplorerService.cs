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

        public ExplorerService()
        {
            fileRepository = new FileRepository(dbPath);
            RefreshDirectoryTree();
            RefreshFileCache(ROOT_ID);
        }

        /// <summary>
        /// 디렉토리 트리를 갱신하는 메서드.
        /// </summary>
        public void RefreshDirectoryTree()
        {
            DirectoryTree = DirectoryTreeService
                .BuildDirectoryTree(fileRepository.SelectItems(null, directoriesOnly: true));
        }

        /// <summary>
        /// 파일목록 캐시를 갱신하는 메서드.
        /// </summary>
        /// <param name="parentId"></param>
        public void RefreshFileCache(int parentId)
        {
            FileCache = FileCacheService
                .BuildFileCache(fileRepository.SelectItems(parentId));
        }

        /// <summary>
        /// 파일목록 캐시를 정렬하는 메서드.
        /// </summary>
        public void SortFileCache(Func<FileItemDto, object> field, bool descending = false)
        {
            FileCache = FileCacheService
                .SortFiles(FileCache, field, descending);
        }

        /// <summary>
        /// 파일목록 캐시를 검색어로 필터링하는 메서드.
        /// </summary>
        public void FilterFileCache(string keyword)
        {
            FileCache = FileCacheService
                .FilterFiles(FileCache, keyword);
        }

        /// <summary>
        /// DB연결 해제 메서드.
        /// </summary>
        public void Dispose()
        {
            fileRepository.Dispose();
        }
    }
}
