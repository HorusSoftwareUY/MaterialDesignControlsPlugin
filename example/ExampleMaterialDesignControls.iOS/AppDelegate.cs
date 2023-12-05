﻿using System;
using System.Collections.Generic;
using System.Linq;
using FFImageLoading.Forms.Platform;
using Foundation;
using Plugin.MaterialDesignControls;
using UIKit;

namespace ExampleMaterialDesignControls.iOS
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

            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();

            Plugin.MaterialDesignControls.iOS.Renderer.Init();

            // MaterialBottomSheet requires the use of a background color in the TabBar
            UITabBar.Appearance.BackgroundColor = UIColor.White;

            LoadApplication(new App());

            CachedImageRenderer.Init();

            return base.FinishedLaunching(app, options);
        }
    }
}
