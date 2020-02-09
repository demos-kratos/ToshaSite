using Microsoft.JSInterop;
using SQLite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ToshaSite.Data.Implementations
{
    public class DummyService : IEntityService
    {
        private SQLiteConnection db;
        private UserSettings userSettings;

        public DummyService(UserSettings u)
        {
            var dbPath = Path.Combine(Environment.CurrentDirectory, "data.db");
            db = new SQLiteConnection(dbPath);
            db.CreateTable<Entity>();
            userSettings = u;
        }

        public IEnumerable<Entity> GetEntities()
        {
            return db.Table<Entity>().OrderBy(x => x.Weight).ThenByDescending(x => x.CreationDate);
        }

        public void SaveEntity(Entity e)
        {
            if(db.Table<Entity>().Any(x => x.Id == e.Id))
            {
                db.Update(e);
            }
            else
            {
                e.CreationDate = DateTime.Now;
                db.Insert(e);
            }
        }

        public void DeleteEntity(Entity e)
        {
            if(db.Table<Entity>().Any(x => x.Id == e.Id))
            {
                db.Delete(e);
            }
        }

        public bool CheckCredentials(string username, string password)
        {
            using var sha = SHA256.Create();
            var currentPwdHash = BitConverter.ToString(sha.ComputeHash(Encoding.UTF8.GetBytes(password + userSettings.PwdSalt))).Replace("-", "");

            return userSettings.Username == username && currentPwdHash == userSettings.PwdHash;
        }
    }
}
