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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
           
            BindingContext = this;
            btnGirisYap.Clicked += BtnGirisYap_Clicked;
            Title = "Giriş Yap";

            btnNotHesapla.Clicked += BtnNotHesapla_Clicked;
            bgImage.Source = ImageSource.FromFile("back.png");
        }

        private void BtnNotHesapla_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private async void BtnGirisYap_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNo.Text) && string.IsNullOrEmpty(txtSifre.Text))
            {
                await DisplayAlert("Hata", "Numara ve şifre boş bırakılamaz", "Tamam");
            }
            else
            {
                LoadingView.IsVisible = true;
                var service = new StudentService();
                var result = await service.OturumAc(txtNo.Text, txtSifre.Text);

                if (result.Result == true)
                {
                    App.User = result.Data;
                    
                    Application.Current.MainPage = new NavigationPage(new AppMainPage());

                }
                else
                {
                    IsBusy = false;
                    await DisplayAlert("Hata", result.Message, "Tamam");
                }
               


            }
        }
    }
}