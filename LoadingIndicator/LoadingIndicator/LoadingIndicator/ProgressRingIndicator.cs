using System;
using Xamarin.Forms;

namespace LoadingIndicator
{
    public class ProgressRingIndicator : View
    {
        public ProgressRingIndicator()
        {
            if (Device.RuntimePlatform != Device.UWP)
            {
                throw new NotSupportedException($"{nameof(ProgressRingIndicator)} is just for UWP, use {nameof(ActivityIndicator)} on {Device.RuntimePlatform}");
            }
        }

        public static readonly BindableProperty ColorProperty = BindableProperty.Create("Color", typeof(Color), typeof(ProgressRingIndicator), default(Color), BindingMode.Default);

        public Color Color
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        public static readonly BindableProperty IsRunningProperty = BindableProperty.Create("IsRunning", typeof(bool), typeof(ProgressRingIndicator), default(bool), BindingMode.Default);

        public bool IsRunning
        {
            get => (bool)GetValue(IsRunningProperty);
            set => SetValue(IsRunningProperty, value);
        }
    }

}
