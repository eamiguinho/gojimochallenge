using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using GojimoChallenge.Android.Activities;
using GojimoChallenge.Contracts.Services;

namespace GojimoChallenge.Android.Services
{
    public class NavigationService :INavigationService
    {
        public void NavigateToSubject()
        {
            Intent intent = new Intent(Application.Context, typeof(SubjectListActivity));
            intent.AddFlags(ActivityFlags.NewTask);
            Application.Context.StartActivity(intent);
        }
    }
}