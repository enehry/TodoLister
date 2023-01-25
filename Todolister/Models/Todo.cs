namespace Todolister.Models
{
    public class Todo
    {
        public  int Id { get; set; }
        public  string Title { get; set; } = null!;
        public  string Description { get; set; } = null!;
        public DateTime DateCreated { get; set; } = DateTime.Now;

        public string DateCreatedString => DateCreated.ToString("dd/MM/yyyy");
    }
}
