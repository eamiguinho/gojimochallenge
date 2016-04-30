using Autofac;
using GojimoChallenge.Contracts.IoC;
using GojimoChallenge.Contracts.Models;

namespace GojimoChallenge.Contracts.Dto.Factories
{
    public class SubjectDtoFactory
    {
        public static ISubject Create(SubjectDto subjectDto)
        {
            var subject = Ioc.Container.Resolve<ISubject>();
            subject.Id = subjectDto.Id;
            subject.Colour = subjectDto.Colour;
            subject.Link = subjectDto.Link;
            subject.Title = subjectDto.Title;
            return subject;
        }

        public static SubjectDto GetDto(ISubject subject)
        {
            var subjectDto = new SubjectDto();
            subjectDto.Colour = subject.Colour;
            subjectDto.Id = subject.Id;
            subjectDto.Link = subject.Link;
            subjectDto.Title = subject.Title;
            return subjectDto;
        }
    }
}