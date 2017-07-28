using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OBS.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppMainPage : ContentPage
    {
        public AppMainPage()
        {
            InitializeComponent();
            Title = "MEÜ OİBS";
            _username.Text = App.User.AdiSoyadi;
            _numara.Text = App.User.OgrenciNo;
            _sinif.Text = App.User.Sinifi;
            _bolum.Text = App.User.ProgramAdi;
        }
    }
}