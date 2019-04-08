using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Firebase;
using Android.Content;
using Android.Gms.Auth.Api.SignIn;
using Xamarin.Forms;

namespace SMove.Droid
{
    [Activity(Label = "SMove", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static FirebaseApp app;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            InitFirebaseAuth();
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            global::Xamarin.FormsMaps.Init(this, savedInstanceState);
            LoadApplication(new App());

           
        }

        private void InitFirebaseAuth()
        {
            var options = new FirebaseOptions.Builder().SetApplicationId("1:745578531830:android:4d9d31a6b1d50461").SetApiKey("AIzaSyBGpZDTgASgMdr1e2jAud2sSxYuDYLMLAA").SetDatabaseUrl("https://smove-1552199852284.firebaseio.com/").Build();

            if (app == null)
                app = FirebaseApp.InitializeApp(this, options, "SMove");
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == FirebaseAuthService.REQ_AUTH && resultCode == Result.Ok)
            {
                GoogleSignInAccount sg = (GoogleSignInAccount)data.GetParcelableExtra("result");
                MessagingCenter.Send(FirebaseAuthService.KEY_AUTH, FirebaseAuthService.KEY_AUTH, sg.IdToken);
            }
        }
    }
}