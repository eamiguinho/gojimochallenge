using GojimoChallenge.Contracts.Models;

namespace GojimoChallenge.ViewModels.DataModels
{
    public class SubjectDataModel
    {
        public SubjectDataModel(ISubject subject)
        {
            Title = subject.Title;
            Model = subject;
            Colour = subject.Colour;
        }

        public string Colour { get; set; }

        public string Title { get; set; }
        public ISubject Model { get; set; }
    }
}