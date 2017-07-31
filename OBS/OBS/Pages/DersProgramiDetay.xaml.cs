using OBS.Models;
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
    public partial class DersProgramiDetay : ContentPage
    {
        public DersProgramiDetay(List<ProgramModel> liste, string title)
        {
            InitializeComponent();
            Title = title;
            lstProgram.ItemsSource = liste;

            lstProgram.ItemSelected += LstProgram_ItemSelected;
        }

        private void LstProgram_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView listview = (ListView)sender;
            listview.SelectedItem = null;
        }
    }
}