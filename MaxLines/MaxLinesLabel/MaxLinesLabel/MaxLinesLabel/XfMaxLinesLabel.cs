using Xamarin.Forms;

namespace MaxLinesLabel
{
    public class XfMaxLinesLabel : Label
    {
        public XfMaxLinesLabel()
        {

        }

        public static BindableProperty MaxLinesProperty = BindableProperty.Create("MaxLines", typeof(int), typeof(XfMaxLinesLabel), int.MaxValue, BindingMode.Default);

        public int MaxLines
        {
            get => (int)GetValue(MaxLinesProperty);
            set => SetValue(MaxLinesProperty, value);
        }
    }
}
