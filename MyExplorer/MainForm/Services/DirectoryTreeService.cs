using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainForm.Models;

namespace MainForm.Services
{
    class DirectoryTreeService
    {
        /// <summary>
        /// 모든 디렉토리 정보를 받아서 디렉토리 트리를 생성하는 메서드.
        /// </summary>
        /// <param name="allDirectories"></param>
        /// <returns></returns>
        public static List<DirectoryTreeNode> BuildDirectoryTree(List<FileItemDto> allDirectories)
        {
            var directoryLookup = allDirectories.ToLookup(f => f.ParentId);

            return BuildTreeNodes(directoryLookup, null);
        }

        /// <summary>
        /// 디렉토리 계층정보를 받아서 디렉토리 트리 노드를 재귀적으로 생성하는 메서드.
        /// </summary>
        /// <param name="lookup"></param>
        /// <param name="parentId"></param>
        /// <returns></returns>
        private static List<DirectoryTreeNode> BuildTreeNodes(ILookup<int?, FileItemDto> lookup, int? parentId)
        {
            var children = lookup[parentId];
            var result = new List<DirectoryTreeNode>();

            foreach (var directory in children)
            {
                var node = new DirectoryTreeNode
                {
                    Id = directory.Id,
                    Name = directory.Name,
                    Children = BuildTreeNodes(lookup, directory.Id)
                };

                result.Add(node);
            }

            return result;
        }
    }

    class DirectoryTreeNode
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DirectoryTreeNode> Children { get; set; } = new List<DirectoryTreeNode>();
    } 
}
