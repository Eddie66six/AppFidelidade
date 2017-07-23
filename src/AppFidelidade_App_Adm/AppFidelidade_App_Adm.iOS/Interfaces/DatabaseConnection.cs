using AppFidelidade_App_Adm.Interfaces;
using SQLite;
using System;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(AppFidelidade_App_Adm.iOS.Interfaces.DatabaseConnection))]
namespace AppFidelidade_App_Adm.iOS.Interfaces
{
    class DatabaseConnection : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "CustomersDb.db3";
            string personalFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder = Path.Combine(personalFolder, "..", "Library");
            var path = Path.Combine(libraryFolder, dbName);
            return new SQLiteConnection(path);
        }
    }
}
