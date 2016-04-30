using System;
using System.Linq;
using System.Text;
using GojimoChallenge.Contracts.Models;

namespace GojimoChallenge.Models
{
    public class Subject : ISubject
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Colour { get; set; }
    }
}
