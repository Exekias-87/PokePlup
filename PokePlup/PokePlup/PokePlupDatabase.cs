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

        //On récupère tout les pokémons de la base
        public Task<List<MyPokemon>> GetPokemonsAsync()
        {
            return Database.Table<MyPokemon>().ToListAsync();
        }


        public Task<List<MyPokemon>> GetItemsNotDoneAsync()
        {
            // SQL queries are also possible
            return Database.QueryAsync<MyPokemon>("SELECT * FROM [MyPokemon] WHERE [Done] = 0");
        }

        //On récupère un pokémon à partir de son id
        public Task<MyPokemon> GetItemAsync(int id)
        {
            return Database.Table<MyPokemon>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        //On sauvegarde un pokémon en base
        public Task<int> SaveItemAsync(MyPokemon item)
        {
                return Database.InsertAsync(item);
        }

        //On supprime un pokémon de la base
        public Task<int> DeleteItemAsync(MyPokemon item)
        {
            return Database.DeleteAsync(item);
        }

        //
        async void OnSaveClicked(object sender, EventArgs e)
        {
            var todoItem = (MyPokemon)sender;
            PokePlupDatabase database = await PokePlupDatabase.Instance;
            await database.SaveItemAsync(todoItem);
        }

        //Méthode qui nous indique si une base existe dans notre appareil
        public Task<bool> isEmpty()
        {
            return Task.Run(() => 0 == Database.Table<MyPokemon>().ToListAsync().Result.Count);
        }
    }

   
}
