using System.ComponentModel;
using Android.Content;
using Android.Text;
using MaxLinesLabel;
using MaxLinesLabel.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(XfMaxLinesLabel), typeof(XfMaxLinesLabelRenderer))]
namespace MaxLinesLabel.Droid
{
    class XfMaxLinesLabelRenderer : LabelRenderer
    {
        public XfMaxLinesLabelRenderer(Context context) : base(context)
        {
        }


        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (((XfMaxLinesLabel)e.NewElement).MaxLines == -1 || ((XfMaxLinesLabel)e.NewElement).MaxLines == int.MaxValue)
                return;
            this.Control.SetMaxLines(((XfMaxLinesLabel)e.NewElement).MaxLines);
            this.Control.Ellipsize = TextUtils.TruncateAt.End;
        }


        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == XfMaxLinesLabel.MaxLinesProperty.PropertyName)
            {
                if (((XfMaxLinesLabel)this.Element).MaxLines == -1 || ((XfMaxLinesLabel)this.Element).MaxLines == int.MaxValue)
                    return;
                this.Control.SetMaxLines(((XfMaxLinesLabel)this.Element).MaxLines);
                this.Control.Ellipsize = TextUtils.TruncateAt.End;
            }
        }
    }
}