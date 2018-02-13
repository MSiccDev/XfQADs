using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PackageInfo
{
	public partial class MainPage : ContentPage
	{
        private IAppDataHelper _appDataHelper;

		public MainPage()
		{
			InitializeComponent();

            _appDataHelper = DependencyService.Get<IAppDataHelper>();

        }


        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.VersionLabel.Text = $"Version: {_appDataHelper.GetApplicationVersion()}";
            this.VersionNameLabel.Text = $"VersionName: {_appDataHelper.GetApplicationVersionName()}";
            this.PackageIdLabel.Text = $"Package Identity: {_appDataHelper.GetApplicationPackageName()}";
        }
    }
}
