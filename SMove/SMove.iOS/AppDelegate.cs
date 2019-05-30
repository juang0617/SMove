namespace SMove.iOS
{

    using Foundation;
    using ImageCircle.Forms.Plugin.iOS;
    using System;
    using System.IO;
    using UIKit;

    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            global::Xamarin.FormsMaps.Init();
            ImageCircleRenderer.Init();
            //LoadApplication(new App());

            //Set DB root
            string dbName = "SMove.db3";
            string dbBinder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "..", "Library", "Databases");
            string dbRoot = Path.Combine(dbBinder, dbName);

            //Inicialized builder
            LoadApplication(new App(dbRoot));


            return base.FinishedLaunching(app, options);
        }

    }
}
