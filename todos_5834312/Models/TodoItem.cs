using SQLite;

namespace todos_5834312.Models
{
    public class TodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Notes { get; set; }
        public bool Done { get; set; }
    }
}
