using OBS.API;
using OBS.Models;
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
    public partial class YariYillar : ContentPage
    {
        public YariYillar()
        {
            InitializeComponent();
            Title = "Dönemler";
            LoadData();
            BindingContext = this;

            lstYariYillar.ItemSelected += LstYariYillar_ItemSelected;
            lstYariYillar.ItemSelected += LstYariYillar_ItemSelected1;
        }

        private void LstYariYillar_ItemSelected1(object sender, SelectedItemChangedEventArgs e)
        {
            ListView listview = (ListView)sender;
            listview.SelectedItem = null;
        }

        private async void LstYariYillar_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            YariYilDonem selected = e.SelectedItem as YariYilDonem;

            await Navigation.PushAsync(new SinavSonuclari(selected));
           
        }

      
       

        private async void LoadData()
        {
            LoadingPage.IsVisible = true;
            YariyilService manager = new YariyilService();
            var response = await manager.GetYariyillar();

            if (response.Result == true && response.Data != null)
            {
                lstYariYillar.ItemsSource = response.Data.YariYillar;
            }
            else
            {
                await DisplayAlert("Hata", response.Message, "Tamam");
                await Navigation.PopAsync();
            }
            LoadingPage.IsVisible = false;
        }

    }
}