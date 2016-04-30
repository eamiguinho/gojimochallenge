using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using GalaSoft.MvvmLight;

namespace GojimoChallenge.ViewModels.ViewModels.Qualifications
{
    public class BaseViewModel : ViewModelBase
    {
        protected Subject<string> getData = new Subject<string>();

        public IObservable<string> DataLoaded
        {
            get { return this.getData.AsObservable(); }
        }

        public virtual void LoadData()
        {
        }
    }
}