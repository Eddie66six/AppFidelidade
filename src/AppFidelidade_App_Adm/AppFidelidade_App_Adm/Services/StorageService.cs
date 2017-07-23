using AppFidelidade_App_Adm.Interfaces;
using AppFidelidade_App_Adm.Models;
using SQLite;
using System.Linq;
using Xamarin.Forms;

namespace AppFidelidade_App_Adm.Services
{
    public class StorageService
    {
        private SQLiteConnection _Db;
        private static object collisionLock = new object();
        public StorageService()
        {
            _Db = DependencyService.Get<IDatabaseConnection>().DbConnection();
            _Db.CreateTable<SqLiteLogin>();
        }

        public void InserirLogin(SqLiteLogin loginData)
        {
            var login = _Db.Table<SqLiteLogin>().FirstOrDefault();
            if (login == null)
                _Db.Insert(loginData);
            else
            {
                _Db.DeleteAll<SqLiteLogin>();
                _Db.Insert(loginData);
            }
        }

        public SqLiteLogin ObterLogin()
        {
            return _Db.Table<SqLiteLogin>().FirstOrDefault();
        }

        public void Limpar()
        {
            _Db.DeleteAll<SqLiteLogin>();
        }
    }
}