using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Huawei.Hms.Aaid;
using Huawei.Agconnect.Config;

namespace MLKit.Droid
{
    [Activity(Label = "MLKit", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            InitializeHMSToken();

            LoadApplication(new App());
        }

        private static readonly string TAG = "android_MainActivity";
        private void InitializeHMSToken()
        {
            System.Threading.Thread thread = new System.Threading.Thread(() =>
            {
                string appid = AGConnectServicesConfig.FromContext(this).GetString("client/app_id");
                string token = HmsInstanceId.GetInstance(this).GetToken(appid, "HCM");
            });
            thread.Start();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}