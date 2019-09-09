namespace TaskManagerApi.Models
{
    public class Chore
    {
        public int Id { get; set; }
        public string Owner{ get; set; }
        public string Name { get; set; }
        public bool Completed { get; set; }
    }
}