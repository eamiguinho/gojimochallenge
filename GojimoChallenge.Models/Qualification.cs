using System.Collections.Generic;
using GojimoChallenge.Contracts.Models;

namespace GojimoChallenge.Models
{
    public class Qualification : IQualification
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<ISubject> Subjects { get; set; }
        public List<object> DefaultProducts { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public string Link { get; set; }
    }
}