using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace MainForm.Repositories
{
    class FileRepository : IDisposable
    {
        private readonly SQLiteConnection dbConnection;
        private readonly SQLiteCommand selectCommand;
        public void Dispose()
        {

        }
    }
}
