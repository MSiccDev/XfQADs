
using PackageInfo.UWP;
using Windows.ApplicationModel;
using Xamarin.Forms;

[assembly: Dependency(typeof(AppDataHelper))]
namespace PackageInfo.UWP
{
    public class AppDataHelper : IAppDataHelper
    {
        private Package _package;

        public AppDataHelper()
        {
            _package = Package.Current;
        }

        public string GetApplicationPackageName()
        {
            return _package.Id.FamilyName;
        }

        public string GetApplicationVersion()
        {
            return  $"{_package.Id.Version.Major}.{_package.Id.Version.Minor}.{_package.Id.Version.Build}.{_package.Id.Version.Revision}";
        }

        public string GetApplicationVersionName()
        {
            return $"{_package.Id.Version.Major}.{_package.Id.Version.Minor}.{_package.Id.Version.Build}.{_package.Id.Version.Revision}";
        }
    }
}
