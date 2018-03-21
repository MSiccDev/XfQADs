using System.ComponentModel;
using MaxLinesLabel;
using MaxLinesLabel.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(XfMaxLinesLabel), typeof(XfMaxLinesLabelRenderer))]
namespace MaxLinesLabel.iOS
{
    public class XfMaxLinesLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (((XfMaxLinesLabel)e.NewElement).MaxLines == -1 || ((XfMaxLinesLabel)e.NewElement).MaxLines == int.MaxValue)
                return;

            this.Control.Lines = ((XfMaxLinesLabel)e.NewElement).MaxLines;
            this.Control.LineBreakMode = UILineBreakMode.TailTruncation;
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == XfMaxLinesLabel.MaxLinesProperty.PropertyName)
            {
                if (((XfMaxLinesLabel)this.Element).MaxLines == -1 || ((XfMaxLinesLabel)this.Element).MaxLines == int.MaxValue)
                    return;

                this.Control.Lines = ((XfMaxLinesLabel)this.Element).MaxLines;
                this.Control.LineBreakMode = UILineBreakMode.TailTruncation;
            }
        }
    }
}