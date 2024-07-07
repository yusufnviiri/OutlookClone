using OutlookClone.Models;
using System.Collections.ObjectModel;
using System.Net.Http.Json;

namespace OutlookClone
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        HttpClient client;
        private string contentUri = "https://thesimpsonsquoteapi.glitch.me/quotes?count=20";

        public ObservableCollection<Simpson> Simpsons { get; set; } = new();

        protected override async void OnAppearing()
        {
            LoadingIndicator.IsVisible = true;
            base.OnAppearing();
            var httpClient = new HttpClient();
            var jsonResponse = await  httpClient.GetFromJsonAsync<List<Simpson>>(contentUri);
            jsonResponse.ForEach(s => Simpsons.Add(s));
            LoadingIndicator.IsVisible = false;

        }




        public MainPage()
        {
            InitializeComponent();
            MessageCollection.ItemsSource = Simpsons;

        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            //if (count == 1)
            //    CounterBtn.Text = $"Clicked {count} time";
            //else
            //    CounterBtn.Text = $"Clicked {count} times";

            //SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
