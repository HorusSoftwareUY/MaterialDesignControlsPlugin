using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Animations
{

    public class TransitionTitleAnimation
    {
        double _placeholderFontSize;
        double _titleFontSize;
        Color _textTitleColor;
        Color _textPlaceholderColor;


        int _topMargin = -35;

        private Label _materialLabel;

        public TransitionTitleAnimation(Label materialLabel, double placeHolderFontSize, double titleFontSize, Color textTitleColor, Color textPlaceholderColor)
        {
            _materialLabel = materialLabel;
            _placeholderFontSize = placeHolderFontSize;
            _titleFontSize = titleFontSize;
            _textTitleColor = textTitleColor;
            _textPlaceholderColor = textPlaceholderColor;
        }

        public async Task Animate(bool animated)
        {
            if (animated)
            {
                var t1 = _materialLabel.TranslateTo(0, _topMargin, 100);
                var t2 = SizeTo(_titleFontSize);
                await Task.WhenAll(t1, t2);
            }
            else
            {
                _materialLabel.TranslationX = 0;
                _materialLabel.TranslationY = _topMargin;
            }
            _materialLabel.FontSize = _titleFontSize;
            _materialLabel.TextColor = _textTitleColor;
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
            if (animated)
            {
                var t1 = _materialLabel.TranslateTo(12, 0, 100);
                var t2 = SizeTo( _placeholderFontSize);
                await Task.WhenAll(t1, t2);
            }
            else
            {
                _materialLabel.TranslationX = 12;
                _materialLabel.TranslationY = 0;
            }
            _materialLabel.FontSize = _placeholderFontSize;
            _materialLabel.TextColor = _textPlaceholderColor;
        }

        public async Task TransitionToTitle( bool animated)
        {
            if (animated)
            {
                var t1 = _materialLabel.TranslateTo(0, _topMargin, 100);
                var t2 = SizeTo( _titleFontSize);
                await Task.WhenAll(t1, t2);
            }
            else
            {
                _materialLabel.TranslationX = 0;
                _materialLabel.TranslationY = _topMargin;
            }
            _materialLabel.FontSize = _titleFontSize;
            _materialLabel.TextColor = _textTitleColor;
        }
    }
}
