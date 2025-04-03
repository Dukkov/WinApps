using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainForm.Models;

namespace MainForm.Services
{
    class FileCacheService
    {
        public static List<FileItemDto> BuildFileCache(List<FileItemDto> allFiles)
        {
            return allFiles
                .OrderByDescending(f => f.IsDirectory)
                .ThenBy(f => f.Name)
                .ToList();
        }

        /// <summary>
        /// 파일목록 캐시, 정렬기준을 받아서 정렬된 캐시를 반환하는 메서드.
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="field"></param>
        /// <param name="descending"></param>
        /// <returns></returns>
        public static List<FileItemDto> SortFiles(List<FileItemDto> cache, 
            Func<FileItemDto, object> field, bool descending = false)
        {
            return descending 
                ? cache.OrderByDescending(field).ToList() 
                : cache.OrderBy(field).ToList();
        }

        /// <summary>
        /// 파일목록 캐시, 검색어를 받아서 검색된 목록을 반환하는 메서드.
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public static List<FileItemDto> FilterFiles(List<FileItemDto> cache, string keyword)
        {
            return cache
                .Where(f => f.Name.ToLower().Contains(keyword.ToLower()))
                .ToList();
        }
    }
}
