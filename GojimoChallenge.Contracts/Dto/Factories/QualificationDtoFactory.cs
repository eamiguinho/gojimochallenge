using System.Linq;
using Autofac;
using GojimoChallenge.Contracts.IoC;
using GojimoChallenge.Contracts.Models;

namespace GojimoChallenge.Contracts.Dto.Factories
{
    public class QualificationDtoFactory
    {
        public static IQualification Create(QualificationDto qualificationDto)
        {
            var qualification = Ioc.Container.Resolve<IQualification>();
            qualification.CreatedAt = qualificationDto.CreatedAt;
            qualification.Id = qualificationDto.Id;
            qualification.Name = qualificationDto.Name;
            qualification.UpdatedAt = qualificationDto.UpdatedAt;
            qualification.Subjects = qualificationDto.Subjects.Select(SubjectDtoFactory.Create).ToList();
            return qualification;
        }

        public static QualificationDto GetDto(IQualification qualification)
        {
            var qualificationDto = new QualificationDto();
            qualificationDto.Id = qualification.Id;
            qualificationDto.CreatedAt = qualification.CreatedAt;
            qualificationDto.Link = qualification.Link;
            qualificationDto.Name = qualification.Name;
            qualificationDto.UpdatedAt = qualification.UpdatedAt;
            qualificationDto.Subjects = qualification.Subjects.Select(SubjectDtoFactory.GetDto).ToList();
            return qualificationDto;

        }
    }
}