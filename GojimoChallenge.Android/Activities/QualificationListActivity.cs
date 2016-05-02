using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using GojimoChallenge.Android.Adapters;
using GojimoChallenge.ViewModels.ViewModels.Qualifications;
using AlertDialog = Android.Support.V7.App.AlertDialog;
using Result = GojimoChallenge.Contracts.Results.Result;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace GojimoChallenge.Android.Activities
{
    [Activity(Label = "Qualifications", Theme = "@style/AppTheme.NoActionBar")]
    public class QualificationListActivity : AppCompatActivity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.qualification_list_layout);

            // Get our button from the layout resource,
            // and attach an event to it
            VModel = new QualificationsListViewModel();
            VModel.DataLoaded.Subscribe(this.OnDataLoaded);
            VModel.LoadData();
            Toolbar rToolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(rToolbar);

        }

        public QualificationsListViewModel VModel { get; set; }


        private void OnDataLoaded(NotifyDataResult e)
        {
            ProgressBar pBar = FindViewById<ProgressBar>(Resource.Id.progressBar);
            pBar.Visibility = ViewStates.Gone;
            if (e.Result == Result.Ok)
            {
                RecyclerView rView = FindViewById<RecyclerView>(Resource.Id.my_recycler_view);
                var layout = new LinearLayoutManager(this);
                rView.SetLayoutManager(layout);
                rView.HasFixedSize = true;
                var mAdapter = new QualificationAdapter(VModel.Qualifications);
                mAdapter.ItemClick.Subscribe(this.OnItemClick);
                rView.SetAdapter(mAdapter);
            }
            else
            {
                AlertDialog.Builder builder = new AlertDialog.Builder(this);
                builder.SetTitle("An error ocorred");
                builder.SetMessage(e.ErrorMessage);
                builder.SetNeutralButton("OK", (sender, args) => { });
                builder.Show();
            }
        }

        void OnItemClick(int position)
        {
            VModel.SelectedItem = VModel.Qualifications[position];
        }
    }
}

