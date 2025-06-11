namespace BookServices.Application.Commands
{
    public class CreateBookCommand
    {
        public string? Title { get; set; }
        public string? Author { get; set; }
        public decimal Price { get; set; }
    }
}
