using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using LoadingIndicator;
using LoadingIndicator.UWP;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(ProgressRingIndicator), typeof(ProgressRingIndicatorRenderer))]

namespace LoadingIndicator.UWP
{
    public class ProgressRingIndicatorRenderer : ViewRenderer<ProgressRingIndicator, ProgressRing>
    {
        private ProgressRing _progressRing;

        protected override void OnElementChanged(ElementChangedEventArgs<ProgressRingIndicator> e)
        {
            base.OnElementChanged(e);

            if (this.Control != null) return;

            _progressRing = new ProgressRing();

            if (e.NewElement != null)
            {
                _progressRing.IsActive = e.NewElement.IsRunning;
                _progressRing.Visibility = e.NewElement.IsRunning ? Visibility.Visible : Visibility.Collapsed;
                var xfColor = e.NewElement.Color;
                _progressRing.Foreground = xfColor.ToUwpSolidColorBrush();

                _progressRing.Height = e.NewElement.HeightRequest > 0 ? e.NewElement.HeightRequest : 20;
                _progressRing.Width = e.NewElement.WidthRequest > 0 ? e.NewElement.WidthRequest : 20;

                SetNativeControl(_progressRing);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == nameof(ProgressRingIndicator.Color))
            {
                _progressRing.Foreground = Element.Color.ToUwpSolidColorBrush();
            }

            if (e.PropertyName == nameof(ProgressRingIndicator.IsRunning))
            {
                _progressRing.IsActive = Element.IsRunning;
                _progressRing.Visibility = Element.IsRunning ? Visibility.Visible : Visibility.Collapsed;
            }

            if (e.PropertyName == nameof(ProgressRingIndicator.WidthRequest))
            {
                _progressRing.Width = Element.WidthRequest > 0 ? Element.WidthRequest : 20;
                UpdateNativeControl();
            }

            if (e.PropertyName == nameof(ProgressRingIndicator.HeightRequest))
            {
                _progressRing.Height = Element.HeightRequest > 0 ? Element.HeightRequest : 20;
                UpdateNativeControl();
            }
        }
    }

}
