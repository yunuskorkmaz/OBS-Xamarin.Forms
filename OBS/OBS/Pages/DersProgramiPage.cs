using OBS.Service;
using OBS.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OBS.Pages
{
    public class DersProgramiPage : TabbedPage
    {
        public DersProgramiPage()
        {
            Title = "Ders Programı";
            LoadData();
        }

        private async void LoadData()
        {
            var loading = new ContentPage()
            {
                Content = new Loading() { IsVisible = true }
            };
            
            Children.Add(loading);

            var service = new ProgramService();

            var result = await service.GetProgram();
            if (result.Result == true)
            {
                var liste = result.Data;
                Children.Add(new DersProgramiDetay(liste.Where(a => a.Gun == "1").ToList(), "Pzt"));
                Children.Add(new DersProgramiDetay(liste.Where(a => a.Gun == "2").ToList(), "Sal"));
                Children.Add(new DersProgramiDetay(liste.Where(a => a.Gun == "3").ToList(), "Çar"));
                Children.Add(new DersProgramiDetay(liste.Where(a => a.Gun == "4").ToList(), "Per"));
                Children.Add(new DersProgramiDetay(liste.Where(a => a.Gun == "5").ToList(), "Cum"));

                Children.Remove(loading);
                this.CurrentPage = this.Children[((int)DateTime.Now.DayOfWeek)-1];
            }
            else
            {
               
                await DisplayAlert("Hata", result.Message, "Tamam");
                await Navigation.PopAsync();
            }
        }
    }
}
