using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileGenerator
{
    public static class FileMetadataGenerator
    {
        private static readonly char[] fileNameChars = Enumerable.Range(48, 122)    // 파일명을 구성할 수 있는 문자들의 배열
               .Select(c => (char)c)
               .Where(c => char.IsLetterOrDigit(c))
               .ToArray();
        private static readonly string[] extenders = new[]  // 사용 가능한 확장자 배열
        {
            "jpg", "jpeg", "gif", "png", "ico", "txt", "pdf",
            "pptx", "xlsx", "docx", "html", "zip", "rar"
        };
        private static readonly DateTime startDate = new DateTime(2010, 1, 1);
        private static readonly DateTime endDate = new DateTime(2025, 3, 1);
        private static readonly Random random = new Random();

        /// <summary>
        /// 파일 또는 폴더의 메타데이터를 생성하고 반환하는 메서드.
        /// </summary>
        /// <param name="idx">생성할 파일의 번호</param>
        /// <returns>생성된 파일 또는 폴더의 메타데이터</returns>
        public static FileMetadata Generate(int idx)
        {
            FileMetadata file = new FileMetadata
            {
                Name = GetRandomFileName(3, 16),
                IsDirectory = idx % 5000 == 1,
                CreatedAt = GetRandomDate(startDate, endDate)
            };

            if (file.IsDirectory)
            {
                file.ParentId = idx == 1 ? (int?)null : idx - 5000;
            }
            else
            {
                file.ParentId = (idx - 2) / 5000 * 5000 + 1;
                file.Size = GetRandomFileSize(1024, 52428800);
                file.AccessedAt = GetRandomDate(file.CreatedAt, endDate);
                file.UpdatedAt = GetRandomDate(file.AccessedAt.Value, endDate);
                file.Extender = GetRandomFileExtender();
            }

            return file;
        }

        /// <summary>
        /// 파일명으로 사용할 랜덤 문자열을 반환하는 메서드.
        /// 랜덤 문자열은 영문, 숫자로 구성됨.
        /// </summary>
        /// <param name="minLength">생성할 문자열 최소 길이</param>
        /// <param name="maxLength">생성할 문자열 최대 길이</param>
        /// <returns>생성된 랜덤 문자열</returns>
        private static string GetRandomFileName(int minLength, int maxLength)
        {
            int fileNameLength = random.Next(minLength, maxLength + 1);
            var sb = new StringBuilder(fileNameLength);

            for (int i = 0; i < fileNameLength; i++)
            {
                sb.Append(fileNameChars[random.Next(fileNameChars.Length)]);
            }

            return sb.ToString();
        }

        /// <summary>
        /// 랜덤 파일 확장자를 반환하는 메서드.
        /// </summary>
        /// <returns>랜덤 파일 확장자</returns>
        private static string GetRandomFileExtender()
        {
            return extenders[random.Next(extenders.Length)];
        }

        /// <summary>
        /// 랜덤한 날짜를 반환하는 메서드.
        /// </summary>
        /// <param name="startDate">시작 날짜</param>
        /// <param name="endDate">종료 날짜</param>
        /// <returns>시작과 종료 사이의 랜덤한 날짜</returns>
        private static DateTime GetRandomDate(DateTime startDate, DateTime endDate)
        {
            int dateRange = (endDate - startDate).Days;

            return startDate.AddDays(random.Next(dateRange)).AddSeconds(random.Next(0, 86400));
        }

        /// <summary>
        /// 랜덤한 파일 사이즈를 반환하는 메서드.
        /// </summary>
        /// <param name="minSize">파일 최소 사이즈</param>
        /// <param name="maxSize">파일 최대 사이즈</param>
        /// <returns>범위 내의 랜덤 정수</returns>
        private static int GetRandomFileSize(int minSize, int maxSize)
        {
            return random.Next(minSize, maxSize);
        }
    }
}
