using System.Collections.Generic;

namespace GojimoChallenge.Contracts.Models
{
    public interface IQualification
    {
        string Id { get; set; }
        string Name { get; set; }
        List<ISubject> Subjects { get; set; }
        string CreatedAt { get; set; }
        string UpdatedAt { get; set; }
        string Link { get; set; }
    }
}