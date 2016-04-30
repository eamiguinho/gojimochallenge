using Android.App;
using Android.Content;
using Android.Support.V7.App;
using Autofac;
using GojimoChallenge.Android.Services;
using GojimoChallenge.Contracts.IoC;
using GojimoChallenge.Contracts.Services;
using GojimoChallenge.DataServices.Implementation;
using GojimoChallenge.Models;
using GojimoChallenge.Services.Implementation;

namespace GojimoChallenge.Android.Activities
{
    [Activity(Theme = "@style/MyTheme.Splash", Icon = "@drawable/ic_launcher", Label= "Gojimo Challenge", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {

        protected override void OnResume()
        {
            base.OnResume();
            IocModelsRegister.Register();
            IocServicesRegister.Register();
            IocDataServicesRegister.Register();
            Ioc.Instance.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            StartActivity(new Intent(Application.Context, typeof(QualificationListActivity)));
        }
    }
}