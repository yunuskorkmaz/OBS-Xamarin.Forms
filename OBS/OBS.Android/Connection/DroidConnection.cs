using OBS.Interface;
using SQLite.Net;
using System.IO;
using SQLite.Net.Platform.XamarinAndroid;
using OBS.Droid.Connection;

[assembly: Xamarin.Forms.Dependency(typeof(DroidConnection))]
namespace OBS.Droid.Connection
{
    public class DroidConnection : IConnect
    {
        public SQLiteConnection GetConnection()
        {
            var filename = "APP.db";
            var documentspath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentspath, filename);
            var platform = new SQLitePlatformAndroid();
            var connection = new SQLiteConnection(platform, path);
            return connection;
        }
    }
}