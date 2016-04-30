using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using GojimoChallenge.ViewModels.ViewModels.Subjects;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace GojimoChallenge.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SubjectListPage : Page
    {
        public SubjectListPage()
        {
            this.InitializeComponent();
            Loaded += SubjectListPage_Loaded;

        }

        private void SubjectListPage_Loaded(object sender, RoutedEventArgs e)
        {
            var viewModel = DataContext as SubjectsListViewModel;
            if (viewModel != null)
            {
                viewModel.LoadData();
                ApplicationView.GetForCurrentView().Title = viewModel.SelectedQualificationTitle;
            }
        }
    }
}
