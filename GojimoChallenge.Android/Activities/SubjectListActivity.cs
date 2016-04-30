using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using GojimoChallenge.Android.Adapters;
using GojimoChallenge.ViewModels.ViewModels.Subjects;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace GojimoChallenge.Android.Activities
{
    [Activity(Label = "Subjects", Theme = "@style/AppTheme.NoActionBar")]
    public class SubjectListActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.subject_list_layout);
            VModel = new SubjectsListViewModel();
            VModel.DataLoaded.Subscribe(this.OnDataLoaded);
            VModel.LoadData();
            Toolbar rToolbar = FindViewById<Toolbar>(Resource.Id.subject_layout_toolbar);
            SetSupportActionBar(rToolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.Title = VModel.SelectedQualificationTitle;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            
                OnBackPressed();
            
            return base.OnOptionsItemSelected(item);
        }

        private void OnDataLoaded(string e)
        {
            RecyclerView rView = FindViewById<RecyclerView>(Resource.Id.subject_layout_recyclerView);
            ProgressBar pBar = FindViewById<ProgressBar>(Resource.Id.subject_layout_progressBar);
            pBar.Visibility = ViewStates.Gone;
            var layout = new LinearLayoutManager(this);
            rView.SetLayoutManager(layout);
            rView.HasFixedSize = true;
            var mAdapter = new SubjectAdapter(VModel.Subjects);
            rView.SetAdapter(mAdapter);
        }

        public SubjectsListViewModel VModel { get; set; }
    }
}