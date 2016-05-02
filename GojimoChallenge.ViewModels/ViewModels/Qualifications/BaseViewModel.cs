using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using GalaSoft.MvvmLight;
using GojimoChallenge.Contracts.Results;

namespace GojimoChallenge.ViewModels.ViewModels.Qualifications
{
    public class BaseViewModel : ViewModelBase
    {
        protected Subject<NotifyDataResult> getData = new Subject<NotifyDataResult>();

        public IObservable<NotifyDataResult> DataLoaded
        {
            get { return this.getData.AsObservable(); }
        }

        public virtual void LoadData()
        {
        }
    }

    public class NotifyDataResult
    {
        public Result Result { get; set; }
        public string ErrorMessage { get; set; }
    }
}