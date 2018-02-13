
using Foundation;
using PackageInfo.iOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(AppDataHelper))]
namespace PackageInfo.iOS
{
    public class AppDataHelper : IAppDataHelper
    {
        private readonly NSDictionary _infoDictionary;

        public AppDataHelper()
        {
            _infoDictionary = NSBundle.MainBundle.InfoDictionary;
        }


        public string GetApplicationPackageName()
        {
            return _infoDictionary[new NSString("CFBundleIdentifier")].ToString();
        }

        public string GetApplicationVersion()
        {
            var appVersionString = NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleShortVersionString").ToString();
            var appBuildNumber = NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleVersion").ToString();

            return $"{appVersionString}.{appBuildNumber}";
        }

        public string GetApplicationVersionName()
        {
            return NSBundle.MainBundle.ObjectForInfoDictionary("CFBundleShortVersionString").ToString();
        }
    }
}