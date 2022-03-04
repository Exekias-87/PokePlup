using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using PokePlup;
using PokePlup.Model;
using System.Threading.Tasks;

namespace PokePlup
{
    public class PokePlupDatabase
    {
        static SQLiteAsyncConnection Database;

        public static readonly AsyncLazy<PokePlupDatabase> Instance = new AsyncLazy<PokePlupDatabase>(async () =>
        {
            var instance = new PokePlupDatabase();
            CreateTableResult result = await Database.CreateTableAsync<MyPokemon>();
            return instance;
        });

        public PokePlupDatabase()
        {
            Database = new SQLiteAsyncConnection(constants.DatabasePath, constants.Flags);
        }

        //...
        public Task<List<MyPokemon>> GetPokemonsAsync()
        {
            return Database.Table<MyPokemon>().ToListAsync();
        }

        public Task<List<MyPokemon>> GetItemsNotDoneAsync()
        {
            // SQL queries are also possible
            return Database.QueryAsync<MyPokemon>("SELECT * FROM [MyPokemon] WHERE [Done] = 0");
        }

        public Task<MyPokemon> GetItemAsync(int id)
        {
            return Database.Table<MyPokemon>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(MyPokemon item)
        {
                return Database.InsertAsync(item);
        }

        public Task<int> DeleteItemAsync(MyPokemon item)
        {
            return Database.DeleteAsync(item);
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var todoItem = (MyPokemon)sender;
            PokePlupDatabase database = await PokePlupDatabase.Instance;
            await database.SaveItemAsync(todoItem);
        }

        public Task<bool> isEmpty()
        {
            return Task.Run(() => 0 == Database.Table<MyPokemon>().ToListAsync().Result.Count);
        }
    }

   
}
