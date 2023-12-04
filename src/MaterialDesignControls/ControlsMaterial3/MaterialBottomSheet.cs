using System;
using Xamarin.Forms;
using System.Threading.Tasks;
using Plugin.MaterialDesignControls.Styles;
using Plugin.MaterialDesignControls.Utils;
using System.Runtime.CompilerServices;

namespace Plugin.MaterialDesignControls.Material3
{
	public class MaterialBottomSheet : ContentView
    {
        #region Attributes and Properties

        private const double _hidingThreshold = 0.4;

        private double _currentPosition = 0;

        private double _bottomSafeArea = 0;

        private double _tabBarHeight = 0;

        private BoxView _scrimBoxView;

        private ContentView _containerView;

        private MaterialCard _sheetView;

        private Grid _sheetViewLayout;

        private BoxView _dragHandleView;

        private double ContainerHeightWithBottomSafeArea => ContainerHeight + _bottomSafeArea;

        private double TranslationYClosed => ContainerHeight + ((_bottomSafeArea + _tabBarHeight) * 2);

        private double OpenPosition
        {
            get
            {
                if (Device.RuntimePlatform == Device.Android)
                    return 20;
                else
                    return _bottomSafeArea + _tabBarHeight;
            }
        }

        #endregion Attributes and Properties

        #region Bindable properties

        public static BindableProperty ContainerHeightProperty =
            BindableProperty.Create(nameof(ContainerHeight), typeof(double), typeof(MaterialBottomSheet), defaultValue: default(double), defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnSheetHeightChanged);

        public double ContainerHeight
        {
            get { return (double)GetValue(ContainerHeightProperty); }
            set { SetValue(ContainerHeightProperty, value); OnPropertyChanged(); }
        }

        public static BindableProperty ContainerContentProperty =
            BindableProperty.Create(nameof(ContainerContent), typeof(View), typeof(MaterialBottomSheet), defaultValue: default(View), defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnSheetContentChanged);

        public View ContainerContent
        {
            get { return (View)GetValue(ContainerContentProperty); }
            set { SetValue(ContainerContentProperty, value); OnPropertyChanged(); }
        }

        public static readonly BindableProperty ScrimColorProperty =
            BindableProperty.Create(nameof(ScrimColor), typeof(Color), typeof(MaterialBottomSheet), defaultValue: MaterialColor.Scrim);

        public Color ScrimColor
        {
            get { return (Color)GetValue(ScrimColorProperty); }
            set { SetValue(ScrimColorProperty, value); }
        }

        public static BindableProperty ScrimOpacityProperty =
            BindableProperty.Create(nameof(ScrimOpacity), typeof(double), typeof(MaterialBottomSheet), defaultValue: 0.4);

        public double ScrimOpacity
        {
            get { return (double)GetValue(ScrimOpacityProperty); }
            set { SetValue(ScrimOpacityProperty, value); }
        }

        public static readonly new BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialBottomSheet), defaultValue: MaterialColor.SurfaceContainerLow);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(double), typeof(MaterialBottomSheet), defaultValue: 28.0);

        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly BindableProperty DragHandleColorProperty =
            BindableProperty.Create(nameof(DragHandleColor), typeof(Color), typeof(MaterialBottomSheet), defaultValue: MaterialColor.OnSurfaceVariant);

        public Color DragHandleColor
        {
            get { return (Color)GetValue(DragHandleColorProperty); }
            set { SetValue(DragHandleColorProperty, value); }
        }

        public static readonly BindableProperty DragHandleIsVisibleProperty =
            BindableProperty.Create(nameof(DragHandleIsVisible), typeof(bool), typeof(MaterialBottomSheet), defaultValue: true);

        public bool DragHandleIsVisible
        {
            get { return (bool)GetValue(DragHandleIsVisibleProperty); }
            set { SetValue(DragHandleIsVisibleProperty, value); }
        }

        public static readonly BindableProperty DragHandleWidthProperty =
            BindableProperty.Create(nameof(DragHandleWidth), typeof(double), typeof(MaterialBottomSheet), defaultValue: 40.0);

        public double DragHandleWidth
        {
            get { return (double)GetValue(DragHandleWidthProperty); }
            set { SetValue(DragHandleWidthProperty, value); }
        }

        public static readonly BindableProperty DragHandleHeightProperty =
            BindableProperty.Create(nameof(DragHandleHeight), typeof(double), typeof(MaterialBottomSheet), defaultValue: 5.0);

        public double DragHandleHeight
        {
            get { return (double)GetValue(DragHandleHeightProperty); }
            set { SetValue(DragHandleHeightProperty, value); }
        }

        public static readonly BindableProperty IsOpenedProperty =
            BindableProperty.Create(nameof(IsOpened), typeof(bool), typeof(MaterialBottomSheet), defaultValue: false, defaultBindingMode: BindingMode.OneWayToSource);

        public bool IsOpened
        {
            get { return (bool)GetValue(IsOpenedProperty); }
            set { SetValue(IsOpenedProperty, value); }
        }

        public static readonly BindableProperty AnimationDurationProperty =
            BindableProperty.Create(nameof(AnimationDuration), typeof(int), typeof(MaterialBottomSheet), defaultValue: 250);

        public int AnimationDuration
        {
            get { return (int)GetValue(AnimationDurationProperty); }
            set { SetValue(AnimationDurationProperty, value); }
        }

        #endregion Bindable properties

        #region Constructors

        public MaterialBottomSheet()
        {
            var mainLayout = new Grid();

            _scrimBoxView = new BoxView
            {
                Color = ScrimColor,
                Opacity = 0,
                InputTransparent = true
            };

            var scrimTapGestureRecognizer = new TapGestureRecognizer();
            scrimTapGestureRecognizer.Tapped += async (s, e) => await Close();
            _scrimBoxView.GestureRecognizers.Add(scrimTapGestureRecognizer);

            mainLayout.Children.Add(_scrimBoxView);

            _containerView = new ContentView
            {
                VerticalOptions = LayoutOptions.End,
                HeightRequest = ContainerHeightWithBottomSafeArea
            };

            var containerTapGestureRecognizer = new PanGestureRecognizer();
            containerTapGestureRecognizer.PanUpdated += Container_PanUpdated;
            _containerView.GestureRecognizers.Add(containerTapGestureRecognizer);

            _sheetView = new MaterialCard
            {
                VerticalOptions = LayoutOptions.End,
                HasShadow = false,
                BackgroundColor = BackgroundColor,
                CornerRadius = new CornerRadius(CornerRadius, CornerRadius, 0, 0),
                Content = ContainerContent,
                HeightRequest = ContainerHeightWithBottomSafeArea,
                Padding = new Thickness(0)
            };

            // Remove MaterialCard effects to avoid a pan gesture lose
            _sheetView.Effects.Clear();

            _sheetViewLayout = new Grid
            {
                RowSpacing = 0
            };
            _sheetViewLayout.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            _sheetViewLayout.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });

            _dragHandleView = new BoxView
            {
                Color = DragHandleColor,
                CornerRadius = DragHandleHeight / 2,
                HeightRequest = DragHandleHeight,
                WidthRequest = DragHandleWidth,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(22),
                VerticalOptions = LayoutOptions.Start,
                IsVisible = DragHandleIsVisible
            };

            _sheetViewLayout.Children.Add(_dragHandleView, 0, 0);

            _sheetView.Content = _sheetViewLayout;

            _containerView.Content = _sheetView;

            mainLayout.Children.Add(_containerView);

            Content = mainLayout;
            InputTransparent = true;
        }

        #endregion Constructors

        #region Methods

        private static void OnSheetHeightChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialBottomSheet)bindable;
            control._containerView.HeightRequest = control.ContainerHeightWithBottomSafeArea;
            control._sheetView.HeightRequest = control.ContainerHeightWithBottomSafeArea;
        }

        private static void OnSheetContentChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialBottomSheet)bindable;

            if (control._sheetViewLayout.Children.Count > 1)
            {
                control._sheetViewLayout.Children.Clear();
                control._sheetViewLayout.Children.Add(control._dragHandleView, 0, 0);
            }

            control._sheetViewLayout.Children.Add((View)newValue, 0, 1);
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            switch (propertyName)
            {
                case nameof(ScrimColor):
                    _scrimBoxView.Color = ScrimColor;
                    break;
                case nameof(BackgroundColor):
                    _sheetView.BackgroundColor = BackgroundColor;
                    break;
                case nameof(CornerRadius):
                    _sheetView.CornerRadius = new CornerRadius(CornerRadius, CornerRadius, 0, 0);
                    break;
                case nameof(DragHandleWidth):
                    _dragHandleView.WidthRequest = DragHandleWidth;
                    break;
                case nameof(DragHandleHeight):
                    _dragHandleView.HeightRequest = DragHandleHeight;
                    _dragHandleView.CornerRadius = DragHandleHeight / 2;
                    break;
                case nameof(DragHandleColor):
                    _dragHandleView.Color = DragHandleColor;
                    break;
                case nameof(DragHandleIsVisible):
                    _dragHandleView.IsVisible = DragHandleIsVisible;
                    break;
                default:
                    base.OnPropertyChanged(propertyName);
                    break;
            }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            _containerView.Content.TranslationY = TranslationYClosed;
        }

        public async void Container_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            try
            {
                if (e.StatusType == GestureStatus.Running)
                {
                    _currentPosition = e.TotalY;
                    if (e.TotalY > 0)
                        _containerView.Content.TranslationY = OpenPosition + e.TotalY;
                }
                else if (e.StatusType == GestureStatus.Completed)
                {
                    var threshold = ContainerHeightWithBottomSafeArea * _hidingThreshold;
                    if (_currentPosition < threshold)
                        await Open();
                    else
                        await Close();
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.Log(ex);
            }
        }

        public async Task Open()
        {
            try
            {
                await Task.WhenAll
                (
                    _scrimBoxView.FadeTo(ScrimOpacity, length: (uint)AnimationDuration),
                    _sheetView.TranslateTo(0, OpenPosition, length: (uint)AnimationDuration, easing: Easing.SinIn)
                );

                IsOpened = true;

                InputTransparent = _scrimBoxView.InputTransparent = false;
            }
            catch (Exception ex)
            {
                LoggerHelper.Log(ex);
            }
        }

        public async Task Close()
        {
            try
            {
                await Task.WhenAll
                (
                    _scrimBoxView.FadeTo(0, length: (uint)AnimationDuration),
                    _containerView.Content.TranslateTo(x: 0, y: TranslationYClosed, length: (uint)AnimationDuration, easing: Easing.SinIn)
                );

                IsOpened = false;

                InputTransparent = _scrimBoxView.InputTransparent = true;
            }
            catch (Exception ex)
            {
                LoggerHelper.Log(ex);
            }
        }

        public void SetBottomSafeArea(double bottomSafeArea, double tabBarHeight)
        {
            _bottomSafeArea = bottomSafeArea;
            _tabBarHeight = tabBarHeight;
            _containerView.Content.TranslationY = TranslationYClosed;
            _containerView.HeightRequest = ContainerHeightWithBottomSafeArea;
            _sheetView.HeightRequest = ContainerHeightWithBottomSafeArea;
        }

        #endregion Methods
    }
}