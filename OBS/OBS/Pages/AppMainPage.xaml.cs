using OBS.Service;
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


            var tgr_SinavSonuclari = new TapGestureRecognizer { NumberOfTapsRequired = 1 };
            tgr_SinavSonuclari.Tapped += Tgr_SinavSonuclari_Tapped;
            frameSinavSonuclari.GestureRecognizers.Add(tgr_SinavSonuclari);

            var tgr_dersprogrami = new TapGestureRecognizer { NumberOfTapsRequired = 1 };
            tgr_dersprogrami.Tapped += Tgr_dersprogrami_Tapped;
            dersprogrami.GestureRecognizers.Add(tgr_dersprogrami);

        }

        private async void Tgr_dersprogrami_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DersProgramiPage());
        }

        private async void Tgr_SinavSonuclari_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new YariYillar());
        }

        public void Logout(object sender,EventArgs e)
        {
            var service = new StudentService();
            service.Logout();
        }
    }
}