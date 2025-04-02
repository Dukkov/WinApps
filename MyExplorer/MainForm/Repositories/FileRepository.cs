using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using MainForm.Models;

namespace MainForm.Repositories
{
    class FileRepository : IDisposable
    {
        private readonly SQLiteConnection dbConnection;

        public FileRepository(string dbPath)
        {
            dbConnection = new SQLiteConnection($"Data Source={dbPath}");

            dbConnection.Open();
        }

        /// <summary>
        /// 디렉토리만 select하는 prepared statement 생성 메서드.
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        private SQLiteCommand CreateSelectDirectoriesCommand(SQLiteConnection conn)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT *
                FROM file
                WHERE is_directory = 1
            ;";

            return cmd;
        }

        /// <summary>
        /// 특정 디렉토리 하위 파일만 select하는 prepared statement 생성 메서드.
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        private SQLiteCommand CreateSelectFilesCommand(SQLiteConnection conn, int parentId)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                SELECT *
                FROM file
                WHERE parent_id = @parent_id
            ;";

            cmd.Parameters.AddWithValue("@parent_id", parentId);

            return cmd;
        }

        /// <summary>
        /// 쿼리 결과를 DTO로 매핑하는 메서드.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private List<FileItemDto> MapReaderToFiles(SQLiteDataReader reader)
        {
            var result = new List<FileItemDto>();

            while (reader.Read())
            {
                result.Add(new FileItemDto
                {
                    Id = reader.GetInt32(0),
                    ParentId = reader.IsDBNull(1) ? (int?)null : reader.GetInt32(1),
                    Name = reader.GetString(2),
                    IsDirectory = reader.GetBoolean(3),
                    Size = reader.IsDBNull(4) ? (int?)null : reader.GetInt32(4),
                    CreatedAt = reader.GetDateTime(5),
                    UpdatedAt = reader.IsDBNull(6) ? (DateTime?)null : reader.GetDateTime(6),
                    AccessedAt = reader.IsDBNull(7) ? (DateTime?)null : reader.GetDateTime(7),
                    Extender = reader.IsDBNull(8) ? null : reader.GetString(8)
                });
            }

            return result;
        }

        /// <summary>
        /// Select 쿼리를 실행해서 결과 리스트를 반환하는 메서드.
        /// 디렉토리 목록이 필요한 경우 directoriesOnly: true로 설정.
        /// 파일 목록이 필요한 경우 parentId 입력해야함.
        /// </summary>
        /// <param name="parentId">파일목록 조회시 디렉토리 id</param>
        /// <param name="directoriesOnly">디렉토리만 조회하는지 여부</param>
        /// <returns></returns>
        public List<FileItemDto> SelectItems(int? parentId, bool directoriesOnly = false)
        {
            if (!directoriesOnly && parentId is null)
                throw new ArgumentException("parentId is required");

            using (var cmd = directoriesOnly
                ? CreateSelectDirectoriesCommand(dbConnection)
                : CreateSelectFilesCommand(dbConnection, parentId.Value))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    return MapReaderToFiles(reader);
                }
            }
        }

        public void Dispose()
        {
            dbConnection.Dispose();
        }
    }
}
