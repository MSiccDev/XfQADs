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
                _progressRing.IsActive = this.Element.IsRunning;
                _progressRing.Visibility = this.Element.IsRunning ? Visibility.Visible : Visibility.Collapsed;
                var xfColor = this.Element.Color;
                _progressRing.Foreground = xfColor.ToUwpSolidColorBrush();

                SetNativeControl(_progressRing);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == nameof(ProgressRingIndicator.Color))
            {
                _progressRing.Foreground = this.Element.Color.ToUwpSolidColorBrush();
            }

            if (e.PropertyName == nameof(ProgressRingIndicator.IsRunning))
            {
                _progressRing.IsActive = this.Element.IsRunning;
                _progressRing.Visibility = this.Element.IsRunning ? Visibility.Visible : Visibility.Collapsed;
            }

            if (e.PropertyName == nameof(ProgressRingIndicator.WidthRequest))
            {
                _progressRing.Width = this.Element.WidthRequest > 0 ? this.Element.WidthRequest : 20;
                UpdateNativeControl();
            }

            if (e.PropertyName == nameof(ProgressRingIndicator.HeightRequest))
            {
                _progressRing.Height = this.Element.HeightRequest > 0 ? this.Element.HeightRequest : 20;
                UpdateNativeControl();
            }
        }
    }
}
