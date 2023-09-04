
/* Cambio no fusionado mediante combinación del proyecto 'todos_5834312 (net7.0-ios)'
Antes:
using System;
Después:
using SQLite;
using System;
*/

/* Cambio no fusionado mediante combinación del proyecto 'todos_5834312 (net7.0-maccatalyst)'
Antes:
using System;
Después:
using SQLite;
using System;
*/

/* Cambio no fusionado mediante combinación del proyecto 'todos_5834312 (net7.0-android)'
Antes:
using System;
Después:
using SQLite;
using System;
*/
using
/* Cambio no fusionado mediante combinación del proyecto 'todos_5834312 (net7.0-ios)'
Antes:
using SQLite;
using todos_5834312.Models;
Después:
using todos_5834312.Models;
*/

/* Cambio no fusionado mediante combinación del proyecto 'todos_5834312 (net7.0-maccatalyst)'
Antes:
using SQLite;
using todos_5834312.Models;
Después:
using todos_5834312.Models;
*/

/* Cambio no fusionado mediante combinación del proyecto 'todos_5834312 (net7.0-android)'
Antes:
using SQLite;
using todos_5834312.Models;
Después:
using todos_5834312.Models;
*/
SQLite;
using todos_5834312.Models;


namespace todos_5834312.Data
{
    public class TodoItemDatabase
    {

        SQLiteAsyncConnection Database;

        public TodoItemDatabase()
        {
        }

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Costants.DatabasePath, Costants.Flags);
            var result = await Database.CreateTableAsync<TodoItem>();
        }

        public async Task<List<TodoItem>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<TodoItem>().ToListAsync();
        }

        public async Task<List<TodoItem>> GetItemsNotDoneAsync()
        {
            await Init();
            return await Database.Table<TodoItem>().Where(t => t.Done).ToListAsync();

        }

        public async Task<TodoItem> GetItemAsync(int Id)
        {
            await Init();
            return await Database.Table<TodoItem>().Where(i => i.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<int> SaveItemAsync(TodoItem item)
        {
            await Init();
            if (item.Id != 0)
            {
                return await Database.UpdateAsync(item);
            }
            else
            {
                return await Database.InsertAsync(item);
            }
        }

        public async Task<int> DeleteItemAsync(TodoItem item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }
    }
}
