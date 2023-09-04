using System.Collections.ObjectModel;
using todos_5834312.Data;
using todos_5834312.Models;

namespace todos_5834312.Views;

public partial class TodoListPage : ContentPage
{

    TodoItemDatabase database;
    public ObservableCollection<TodoItem> Items { get; set; } = new();

    public TodoListPage(TodoItemDatabase todoItemDatabase)
    {
        InitializeComponet();
        database = todoItemDatabase;
        BindingContext = this;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        var items = await database.GetItemsAsync();
        MainThread.BeginInvokeOnMainThread(() =>
        {
            items.Clear();
            foreach (var item in items)
                Items.Add(item);
        });

    }

    async void OnItemAdded(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(TodoItemPage), true, new Dictionary<string, object>
        {
            ["Item"] = new TodoItem()
        });
    }

}