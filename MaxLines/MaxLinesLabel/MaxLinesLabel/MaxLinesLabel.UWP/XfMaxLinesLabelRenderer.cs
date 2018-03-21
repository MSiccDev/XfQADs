using System.ComponentModel;
using MaxLinesLabel;
using MaxLinesLabel.UWP;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(XfMaxLinesLabel), typeof(XfMaxLinesLabelRenderer))]
namespace MaxLinesLabel.UWP
{
    public class XfMaxLinesLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (((XfMaxLinesLabel)e.NewElement).MaxLines == -1 || ((XfMaxLinesLabel)e.NewElement).MaxLines == int.MaxValue)
                return;

            this.Control.MaxLines = ((XfMaxLinesLabel)e.NewElement).MaxLines;
            this.Control.TextTrimming = Windows.UI.Xaml.TextTrimming.WordEllipsis;
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == XfMaxLinesLabel.MaxLinesProperty.PropertyName)
            {
                if (((XfMaxLinesLabel)this.Element).MaxLines == -1 || ((XfMaxLinesLabel)this.Element).MaxLines == int.MaxValue)
                    return;

                this.Control.MaxLines = ((XfMaxLinesLabel)this.Element).MaxLines;
                this.Control.TextTrimming = Windows.UI.Xaml.TextTrimming.WordEllipsis;
            }
        }
    }
}
