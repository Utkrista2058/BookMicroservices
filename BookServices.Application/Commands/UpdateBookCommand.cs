namespace BookServices.Application.Commands
{
    public class UpdateBookCommand
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public decimal Price { get; set; }
    }
}
