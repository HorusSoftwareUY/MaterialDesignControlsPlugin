using System;
using System.ComponentModel;
using Plugin.MaterialDesignControls.Material3;
using Plugin.MaterialDesignControls.Material3.iOS;
using Plugin.MaterialDesignControls.Utils;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MaterialBottomSheet), typeof(MaterialBottomSheetRenderer))]
namespace Plugin.MaterialDesignControls.Material3.iOS
{
	public class MaterialBottomSheetRenderer : ViewRenderer<MaterialBottomSheet, UIView>
    {
        private UITabBarController _uiTabBarController;

        public static new void Init() { }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == nameof(Element.IsOpened) && _uiTabBarController != null)
            {
                if (Element.IsOpened)
                    HideTabBar();
                else
                    ShowTabBar();
            }
        }

        public void HideTabBar()
        {
            var animation = new Animation(v => _uiTabBarController.TabBar.Alpha = (nfloat)v, 1, 0);
            animation.Commit(Element, $"{nameof(MaterialBottomSheet)}HideTabBar", 16, (uint)Element.AnimationDuration, Easing.Linear, (v, c) => _uiTabBarController.TabBar.Alpha = 0, () => false);
        }

        public void ShowTabBar()
        {
            var animation = new Animation(v => _uiTabBarController.TabBar.Alpha = (nfloat)v, 0, 1);
            animation.Commit(Element, $"{nameof(MaterialBottomSheet)}ShowTabBar", 16, (uint)Element.AnimationDuration, Easing.Linear, (v, c) => _uiTabBarController.TabBar.Alpha = 1, () => false);
        }

        private UITabBarController FindFirstTabBarController()
        {
            try
            {
                var keyWindow = UIApplication.SharedApplication.KeyWindow;
                var rootViewController = keyWindow.RootViewController;
                return FindTabBarController(rootViewController);
            }
            catch (Exception ex)
            {
                LoggerHelper.Log(ex);
                return null;
            }
        }

        private UITabBarController FindTabBarController(UIViewController viewController)
        {
            try
            {
                if (viewController is UITabBarController tabBarController)
                    return tabBarController;

                if (viewController.PresentedViewController != null)
                    return FindTabBarController(viewController.PresentedViewController);

                if (viewController is UINavigationController navigationController)
                {
                    var visibleViewController = navigationController.VisibleViewController;
                    if (visibleViewController != null)
                        return FindTabBarController(visibleViewController);
                }

                foreach (var childViewController in viewController.ChildViewControllers)
                    return FindTabBarController(childViewController);

                return null;
            }
            catch (Exception ex)
            {
                LoggerHelper.Log(ex);
                return null;
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<MaterialBottomSheet> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                var safeAreaBottom = 0.0;
                var tabBarHeight = 0.0;

                _uiTabBarController = FindFirstTabBarController();
                if (_uiTabBarController != null && _uiTabBarController.TabBar != null)
                    tabBarHeight = _uiTabBarController.TabBar.Frame.Size.Height;

                var insets = UIApplication.SharedApplication.Windows[0].SafeAreaInsets;
                if (insets != null)
                    safeAreaBottom += insets.Bottom;

                if (safeAreaBottom > 0 || tabBarHeight > 0)
                    Element.SetBottomSafeArea(safeAreaBottom, tabBarHeight);
            }
        }
    }
}