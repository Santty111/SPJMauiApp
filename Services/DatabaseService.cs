using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SPJMauiApp.Models;

namespace SPJMauiApp.Services
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Catalogo>().Wait(); // Crear tabla si no existe
        }

        public Task<int> AddCatalogoAsync(Catalogo catalogo)
        {
            return _database.InsertAsync(catalogo);
        }

        public Task<List<Catalogo>> GetCatalogosAsync()
        {
            return _database.Table<Catalogo>().ToListAsync();
        }

        public Task<int> UpdateCatalogoAsync(Catalogo catalogo)
        {
            return _database.UpdateAsync(catalogo);
        }

        public Task<int> DeleteCatalogoAsync(Catalogo catalogo)
        {
            return _database.DeleteAsync(catalogo);
        }
    }
}