using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace AuroraBorealis.iOS
{
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
            Aurora.ComponentLoader.Init("MCfkgszBe12F8yhiN/pLhPUX+pzv1ZHPxLcH2iWGUtep8M+mknK1JsCWZ1dmAFmCT7Tcd7iit7AKqQ7y84W4GHtKr3VeVBMffF+HInITpRZ8imrmRJITNQ7vM//0/0Uqvs5SJw4zYHdnwKViCDmmZblB9as5RdbqDb6uKYWvBk0=");

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
