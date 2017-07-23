using AppFidelidade_App_Adm.Interfaces;
using SQLite;
using System.IO;
using AppFidelidade_App_Adm.Droid.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection))]
namespace AppFidelidade_App_Adm.Droid.Interfaces
{
    public class DatabaseConnection : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "CustomersDb.db3";
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);
            return new SQLiteConnection(path);
        }
    }
}