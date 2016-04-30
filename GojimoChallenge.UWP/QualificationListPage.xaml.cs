using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using GojimoChallenge.ViewModels.ViewModels.Qualifications;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GojimoChallenge.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class QualificationListPage : Page
    {
        public QualificationListPage()
        {
            this.InitializeComponent();
            Loaded += QualificationListPage_Loaded;
            ApplicationView.GetForCurrentView().Title = "Qualifications";

        }

        private void QualificationListPage_Loaded(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as QualificationsListViewModel;
            if (viewModel != null) viewModel.LoadData();
         
        }
    }
}
