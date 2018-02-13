
using Android.Content;
using Android.Content.PM;
using PackageInfo.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(AppDataHelper))]
namespace PackageInfo.Droid
{
    public class AppDataHelper : IAppDataHelper
    {
        private readonly Context _context;
        private readonly PackageManager _packageManager;
        public AppDataHelper()
        {
            _context = Android.App.Application.Context;
            _packageManager = _context.PackageManager;
        }

        public string GetApplicationPackageName()
        {
            return _context.PackageName;
        }

        public string GetApplicationVersion()
        {
            return _packageManager.GetPackageInfo(_context.PackageName, 0).VersionCode.ToString();
        }

        public string GetApplicationVersionName()
        {
            return _packageManager.GetPackageInfo(_context.PackageName, 0).VersionName;
        }
    }
}