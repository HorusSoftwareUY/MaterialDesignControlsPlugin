using System;
using System.Windows.Input;
using Plugin.MaterialDesignControls.Animations;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Implementations
{
    public class ContentViewButton : ContentView, ITouchAndPressEffectConsumer
    {
        #region Properties

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(ContentViewButton));

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(ContentViewButton), defaultValue: null);

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        public static readonly BindableProperty AnimationProperty =
            BindableProperty.Create(nameof(Animation), typeof(AnimationTypes), typeof(ContentViewButton), defaultValue: AnimationTypes.None);

        public AnimationTypes Animation
        {
            get => (AnimationTypes)GetValue(AnimationProperty);
            set => SetValue(AnimationProperty, value);
        }

        public static readonly BindableProperty AnimationParameterProperty =
            BindableProperty.Create(nameof(AnimationParameter), typeof(double?), typeof(ContentViewButton), defaultValue: null);

        public double? AnimationParameter
        {
            get => (double?)GetValue(AnimationParameterProperty);
            set => SetValue(AnimationParameterProperty, value);
        }

        public ICustomAnimation CustomAnimation { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        #endregion Properties

        #region Constructors

        public ContentViewButton()
        {
            Effects.Add(new TouchAndPressEffect());
        }

        #endregion Constructors

        #region Operations

        public void ConsumeEvent(EventType gestureType)
        {
            TouchAndPressAnimation.Animate(this, gestureType);
        }

        public void ExecuteAction()
        {
            if (IsEnabled && Command != null && Command.CanExecute(CommandParameter))
                Command.Execute(CommandParameter);
        }

        #endregion Operations
    }
}