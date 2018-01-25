using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LoadingIndicator
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();

	        this.ShowLoadingButton.Clicked += OnShowLoadingButtonClicked;
	    }

	    private void OnShowLoadingButtonClicked(object sender, EventArgs eventArgs)
	    {
	        this.LoadingRing.IsRunning = !this.LoadingRing.IsRunning;

	        this.ShowLoadingButton.Text = this.LoadingRing.IsRunning ? "Hide Loading Ring" : "Show Loading Ring";
	    }
    }
}