using OBS.Models;
using OBS.Service;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OBS.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SinavSonuclari : ContentPage
    {
        public SinavSonuclari(YariYilDonem donem)
        {
            InitializeComponent();
            BindingContext = this;
            Title = donem.Adi;
            LoadData(donem);
            lstSinavSonuc.SeparatorColor = Color.Black;
            lstSinavSonuc.ItemSelected += LstSinavSonuc_ItemSelected;
          

        }

   

        private void LstSinavSonuc_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView listview = (ListView)sender;
            listview.SelectedItem = null;
        }

        private async void LoadData(YariYilDonem a)
        {

            LoadingPage.IsVisible = true;
            var manager = new SinavSonucService();

            var result = await manager.GetSinavSonuc(a);

            if (result.Result == true)
            {
                lstSinavSonuc.ItemsSource = result.Data;
            }
            else
            {
                await DisplayAlert("Hata", result.Message, "Tamam");
                await Navigation.PopAsync();
            }
            LoadingPage.IsVisible = false;
            
        }
    }
}