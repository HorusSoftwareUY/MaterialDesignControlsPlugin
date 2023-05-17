﻿using System;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Implementations
{
    [Obsolete("CustomEntry is deprecated, please use CustomEntry of Material 3 instead.")]
    public class CustomEntry : Entry
    {
        public static readonly BindableProperty IsCodeProperty =
            BindableProperty.Create(nameof(IsCode), typeof(bool), typeof(CustomEntry), defaultValue: false);

        public bool IsCode
        {
            get { return (bool)GetValue(IsCodeProperty); }
            set { SetValue(IsCodeProperty, value); }
        }
    }
}