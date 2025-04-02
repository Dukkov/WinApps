using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace FileGenerator
{
    class FileRepository : IDisposable
    {
        private readonly SQLiteConnection dbConnection;
        private readonly SQLiteCommand createCommand;
        private readonly SQLiteCommand insertCommand;

        public FileRepository(string dbPath)
        {
            dbConnection = new SQLiteConnection(dbPath);

            dbConnection.Open();
            createCommand = GetCreateCommand(dbConnection);
            insertCommand = GetInsertCommand(dbConnection);
        }

        /// <summary>
        /// file 테이블을 create 하는 메서드
        /// </summary>
        public void CreateFileTable()
        {
            try
            {
                createCommand.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        /// <summary>
        /// Create용 prepared statement를 생성하는 메서드.
        /// </summary>
        /// <param name="conn"></param>
        /// <returns>Create prepared statement</returns>
        private SQLiteCommand GetCreateCommand(SQLiteConnection conn)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                CREATE TABLE file (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    parent_id INTEGER,
                    name TEXT NOT NULL,
                    is_directory INTEGER NOT NULL,
                    size INTEGER,
                    created_at TEXT NOT NULL,
                    updated_at TEXT,
                    accessed_at TEXT,
                    extender TEXT
                );";

            return cmd;
        }

        /// <summary>
        /// Insert용 prepared statement를 생성하는 메서드.
        /// </summary>
        /// <param name="conn"></param>
        /// <returns>Insert prepared statement</returns>
        private SQLiteCommand GetInsertCommand(SQLiteConnection conn)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO file (parent_id, name, is_directory, size, created_at, updated_at, accessed_at, extender)
                VALUES (@parent_id, @name, @is_directory, @size, @created_at, @updated_at, @accessed_at, @extender)
            ;";

            cmd.Parameters.Add(new SQLiteParameter("@parent_id", DbType.Int32));
            cmd.Parameters.Add(new SQLiteParameter("@name", DbType.String));
            cmd.Parameters.Add(new SQLiteParameter("@is_directory", DbType.Boolean));
            cmd.Parameters.Add(new SQLiteParameter("@size", DbType.Int32));
            cmd.Parameters.Add(new SQLiteParameter("@created_at", DbType.String));
            cmd.Parameters.Add(new SQLiteParameter("@updated_at", DbType.String));
            cmd.Parameters.Add(new SQLiteParameter("@accessed_at", DbType.String));
            cmd.Parameters.Add(new SQLiteParameter("@extender", DbType.String));

            return cmd;
        }

        /// <summary>
        /// 파일 메타데이터를 DB에 insert하는 메서드.
        /// </summary>
        /// <param name="file">파일 메타데이터</param>
        public void InsertFile(FileMetadata file)
        {
            insertCommand.Parameters["@parent_id"].Value = file.ParentId ?? (object)DBNull.Value;
            insertCommand.Parameters["@name"].Value = file.Name;
            insertCommand.Parameters["@is_directory"].Value = file.IsDirectory;
            insertCommand.Parameters["@size"].Value = file.Size ?? (object)DBNull.Value;
            insertCommand.Parameters["@created_at"].Value = file.CreatedAt.ToString("yyyy-MM-dd HH:mm:ss");
            insertCommand.Parameters["@updated_at"].Value = file.UpdatedAt?.ToString("yyyy-MM-dd HH:mm:ss") ?? (object)DBNull.Value;
            insertCommand.Parameters["@accessed_at"].Value = file.AccessedAt?.ToString("yyyy-MM-dd HH:mm:ss") ?? (object)DBNull.Value;
            insertCommand.Parameters["@extender"].Value = file.Extender ?? (object)DBNull.Value;

            try
            {
                insertCommand.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        /// <summary>
        /// 트랜잭션 래핑 메서드.
        /// </summary>
        /// <param name="action"></param>
        public void WithTransaction(Action action)
        {
            using (var transaction = dbConnection.BeginTransaction())
            {
                action();
                transaction.Commit();
            }
        }

        public void Dispose()
        {
            createCommand.Dispose();
            insertCommand.Dispose();
            dbConnection.Dispose();
        }
    }
}
