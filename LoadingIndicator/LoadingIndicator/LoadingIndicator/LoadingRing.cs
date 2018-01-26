using System;
using Xamarin.Forms;

namespace LoadingIndicator
{
    public class LoadingRing : ContentView
    {
        public readonly ProgressRingIndicator UwpProgressRing;
        public readonly ActivityIndicator ActivityIndicator;

        public LoadingRing()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.UWP:
                    this.UwpProgressRing = new ProgressRingIndicator();
                    this.UwpProgressRing.HorizontalOptions = LayoutOptions.FillAndExpand;
                    this.UwpProgressRing.VerticalOptions = LayoutOptions.FillAndExpand;
                    this.Content = this.UwpProgressRing;
                    break;
                default:
                    this.ActivityIndicator = new ActivityIndicator();
                    this.ActivityIndicator.HorizontalOptions = LayoutOptions.FillAndExpand;
                    this.ActivityIndicator.VerticalOptions = LayoutOptions.FillAndExpand;
                    this.Content = this.ActivityIndicator;
                    break;
            }

            SizeChanged += LoadingRing_SizeChanged;

        }

        private void LoadingRing_SizeChanged(object sender, EventArgs e)
        {
            switch (Device.RuntimePlatform)
            {
                case Device.UWP:
                    this.UwpProgressRing.HeightRequest = this.HeightRequest;
                    this.UwpProgressRing.WidthRequest = this.WidthRequest;
                    break;
                default:
                    this.ActivityIndicator.HeightRequest = this.HeightRequest;
                    this.ActivityIndicator.WidthRequest = this.WidthRequest;
                    break;
            }
        }

        public static readonly BindableProperty ColorProperty = BindableProperty.Create("Color", typeof(Color), typeof(LoadingRing), default(Color), BindingMode.Default, propertyChanged: OnColorPropertyChanged);

        private static void OnColorPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (bindable is LoadingRing current)
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.UWP:
                        if (current.UwpProgressRing != null) current.UwpProgressRing.Color = (Color)newvalue;
                        break;
                    default:
                        if (current.ActivityIndicator != null) current.ActivityIndicator.Color = (Color)newvalue;
                        break;
                }
            }
        }

        public Color Color
        {
            get => (Color)GetValue(ColorProperty);
            set => SetValue(ColorProperty, value);
        }

        public static readonly BindableProperty IsRunningProperty = BindableProperty.Create("IsRunning", typeof(bool), typeof(LoadingRing), default(bool), BindingMode.Default, propertyChanged: OnIsRunningChanged);

        private static void OnIsRunningChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (bindable is LoadingRing current)
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.UWP:
                        if (current.UwpProgressRing != null) current.UwpProgressRing.IsRunning = (bool)newvalue;
                        break;
                    default:
                        if (current.ActivityIndicator != null) current.ActivityIndicator.IsRunning = (bool)newvalue;
                        break;
                }
            }
        }

        public bool IsRunning
        {
            get => (bool)GetValue(IsRunningProperty);
            set => SetValue(IsRunningProperty, value);
        }

    }

}
