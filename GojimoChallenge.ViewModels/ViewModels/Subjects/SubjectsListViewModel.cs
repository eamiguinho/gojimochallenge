using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using GalaSoft.MvvmLight;
using GojimoChallenge.Contracts.IoC;
using GojimoChallenge.Contracts.Services;
using GojimoChallenge.ViewModels.DataModels;
using GojimoChallenge.ViewModels.ViewModels.Qualifications;

namespace GojimoChallenge.ViewModels.ViewModels.Subjects
{
    public class SubjectsListViewModel : BaseViewModel
    {
        private ObservableCollection<SubjectDataModel> _subjects;
        private string _selectedQualificationTitle;

        public SubjectsListViewModel()
        {
        }

        public ObservableCollection<SubjectDataModel> Subjects
        {
            get
            {
                return _subjects ?? (_subjects = new ObservableCollection<SubjectDataModel>());
            }
        }


        public void LoadData()
        {
            var service = Ioc.Container.Resolve<IQualificationService>();
            var result = service.GetCurrentQualificiation();
            SelectedQualificationTitle = string.Format("{0} Subjects",result.Name);
            foreach (var subjects in result.Subjects)
            {
                Subjects.Add(new SubjectDataModel(subjects));
            }
            getData.OnNext("");
        }

        public string SelectedQualificationTitle
        {
            get { return _selectedQualificationTitle; }
            set { Set(ref _selectedQualificationTitle, value); }
        }
    }
}
