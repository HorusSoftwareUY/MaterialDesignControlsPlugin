using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Animations
{
    public class TransitionTitleAnimation
    {
        double _placeholderFontSize;
        double _titleFontSize;
        public Color _textTitleColor;
        public Color _textPlaceholderColor;

        int _topMargin = -25;

        private Label _materialLabel;
        public int _translateX = 12;

        public TransitionTitleAnimation(Label materialLabel, double placeHolderFontSize, double titleFontSize, Color textTitleColor, Color textPlaceholderColor)
        {
            _materialLabel = materialLabel;
            _placeholderFontSize = placeHolderFontSize;
            _titleFontSize = titleFontSize;
            _textTitleColor = textTitleColor;
            _textPlaceholderColor = textPlaceholderColor;
        }

        public Task SizeTo(double fontSize)
        {
            var taskCompletionSource = new TaskCompletionSource<bool>();

            // setup information for animation
            Action<double> callback = input => { _materialLabel.FontSize = input; };
            double startingHeight = _materialLabel.FontSize;
            double endingHeight = fontSize;
            uint rate = 5;
            uint length = 100;
            Easing easing = Easing.Linear;

            // now start animation with all the setup information
            _materialLabel.Animate("invis", callback, startingHeight, endingHeight, rate, length, easing, (v, c) => taskCompletionSource.SetResult(c));

            return taskCompletionSource.Task;
        }

        public async Task TransitionToPlaceholder( bool animated)
        {
            _materialLabel.FontSize = _placeholderFontSize;
            _materialLabel.TextColor = _textPlaceholderColor;
            _materialLabel.BackgroundColor = Color.Transparent;

            if (animated)
            {
                var t1 = _materialLabel.TranslateTo(_translateX, 0, 100);
                var t2 = SizeTo( _placeholderFontSize);
                await Task.WhenAll(t1, t2);
            }
            else
            {
                _materialLabel.TranslationX = _translateX;
                _materialLabel.TranslationY = 0;
            }

        }

        public async Task TransitionToTitle(bool animated)
        {
            _materialLabel.FontSize = _titleFontSize;
            _materialLabel.TextColor = _textTitleColor;
            //background color custom

            if (animated)
            {
                var t1 = _materialLabel.TranslateTo(5, _topMargin, 100);
                var t2 = SizeTo( _titleFontSize);
                await Task.WhenAll(t1, t2);
            }
            else
            {
                _materialLabel.TranslationX = 5;
                _materialLabel.TranslationY = _topMargin;
            }

        }
    }
}
