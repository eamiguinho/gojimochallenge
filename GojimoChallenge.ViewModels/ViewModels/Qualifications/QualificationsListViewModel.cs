using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using Autofac;
using GojimoChallenge.Contracts.IoC;
using GojimoChallenge.Contracts.Services;
using GojimoChallenge.ViewModels.DataModels;

namespace GojimoChallenge.ViewModels.ViewModels.Qualifications
{
    public class QualificationsListViewModel : BaseViewModel
    {
    
         private ObservableCollection<QualificationDataModel> _qualifications;
        private QualificationDataModel _selectedItem;

        public QualificationsListViewModel()
        {
        }

        public ObservableCollection<QualificationDataModel> Qualifications
        {
            get
            {
                return _qualifications ?? (_qualifications = new ObservableCollection<QualificationDataModel>());
            }
        }

        public QualificationDataModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                Set(ref _selectedItem, value);
                if (value != null)
                {
                    var service = Ioc.Container.Resolve<IQualificationService>();
                    var navigationService = Ioc.Container.Resolve<INavigationService>();
                    service.SetCurrentQualification(value.Model);
                    navigationService.NavigateToSubject();
                }
            }
        }

        public override async void LoadData()
        {
            var service = Ioc.Container.Resolve<IQualificationService>();
            var result = await service.GetQualifications();
            if (result.IsOk)
            {
                foreach (var qualification in result.Data.Where(x=>x.Subjects != null && x.Subjects.Count > 0 ))
                {
                    Qualifications.Add(new QualificationDataModel(qualification));
                }
            }
            getData.OnNext(new NotifyDataResult
            {
                Result = result.Result,
                ErrorMessage = result.ErrorMessage
            });
        }
    }
}
