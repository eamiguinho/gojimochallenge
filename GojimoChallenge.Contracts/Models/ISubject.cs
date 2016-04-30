namespace GojimoChallenge.Contracts.Models
{
    public interface ISubject
    {
        string Id { get; set; }
        string Title { get; set; }
        string Link { get; set; }
        string Colour { get; set; }
    }
}