using GojimoChallenge.Contracts.Models;

namespace GojimoChallenge.ViewModels.DataModels
{
    public class QualificationDataModel
    {
        public QualificationDataModel(IQualification qualification)
        {
            Name = qualification.Name;
            Model = qualification;
        }

        public string Name { get; set; }
        public IQualification Model { get; set; }
    }
}