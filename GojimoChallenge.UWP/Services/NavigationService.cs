using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using GojimoChallenge.Contracts.Services;

namespace GojimoChallenge.UWP.Services
{
    public class NavigationService : INavigationService
    {
        public void NavigateToSubject()
        {
            var frame =  Window.Current.Content as Frame;
            if (frame != null) frame.Navigate(typeof (SubjectListPage));
        }
    }
}
