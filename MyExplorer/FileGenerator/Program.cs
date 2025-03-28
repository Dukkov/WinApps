using System;
using System.Linq;
using System.Text;
using System.IO;

namespace FileGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string dbPath = Path.Combine("..", "..", "..", "file.db");

            if (File.Exists(dbPath))
            {
                Console.WriteLine("이미 DB가 존재합니다.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("DB 생성을 시작합니다.");

                using (var repo = new FileRepository($"Data Source={dbPath}"))
                {
                    repo.CreateFileTable();
                    repo.WithTransaction(() =>
                    {
                        for (int i = 1; i <= 500000; i++)
                        {
                            var file = FileMetadataGenerator.Generate(i);
                            repo.InsertFile(file);
                        }
                    });
                }

                Console.WriteLine("DB 생성 완료.");
                Console.ReadKey();
            }
        }
    }
}
