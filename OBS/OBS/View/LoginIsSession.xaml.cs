using OBS.Pages;
using OBS.Service;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OBS.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginIsSession : ContentView
    {
        public LoginIsSession()
        {
            InitializeComponent();

            var studentManager = new StudentService();
            studentManager.GetUser();


            btnGirisYap.Text = App.User.AdiSoyadi + Environment.NewLine + "Devam Et";
            btnGirisYap.Clicked += delegate
            {
                Application.Current.MainPage = new NavigationPage(new AppMainPage());
            };
        }
    }
}