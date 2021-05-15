using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;

namespace GestionnaireSerie
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Serie> lesSeries;
        HttpClient client = new HttpClient();
        public MainPage()
        {
            InitializeComponent();
            lesSeries = new ObservableCollection<Serie>();
            //loadSerie();
            listeSerie.ItemsSource = lesSeries;
            listeSerie.ItemSelected += listeSerie_ItemSelected;
            write();

            WebRequest.DefaultWebProxy.Credentials = CredentialCache.DefaultNetworkCredentials;
        }

        private void listeSerie_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new infoSerie());
        }

        private void valider_Clicked(object sender, EventArgs e)
        {
            Serie s = new Serie(serie.Text);
            lesSeries.Add(s);
            //saveSerie();
        }

       /* public void saveSerie()
        {
            string toSaveText = "";
            foreach (Serie s in this.lesSeries)
            {
                toSaveText += s.getNomSerie() + "\n";
                //";" + s.getLesSaisons().Count +
            }
            DependencyService.Get<ISaveAndLoad>().SaveText("gestSerie.txt", toSaveText);
        }

        public void loadSerie()
        {
            string recupere = DependencyService.Get<ISaveAndLoad>().LoadText("gestSerie.txt");
            string[] lesLignesContact = recupere.Split(new[] { Environment.NewLine },
           StringSplitOptions.None);
            foreach (var item in lesLignesContact)
            {
                if (item.Length > 0)
                {
                    string[] laSerie = item.Split(';');
                    Serie s = new Serie(laSerie[0]);
                    lesSeries.Add(s);
                }
            }
        }*/

        public async void write()
        {
            var facture = new {IdSerie = 2, NomSerie = "La Sieste", Blob = 0 };
            var json = JsonConvert.SerializeObject(facture);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            client.DefaultRequestHeaders.ExpectContinue = false;

            var url = "https://172.19.0.39/write.json";
            var response = await client.PostAsync(url, data);

            var result = response.Content.ReadAsStringAsync().Result;
            var statusCode = response.StatusCode.ToString();
        }
    }
}
