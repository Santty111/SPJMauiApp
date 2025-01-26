using Newtonsoft.Json;
using SPJMauiApp.Models;

namespace SPJMauiApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7171/api/");

            var response = client.GetAsync("Catalogo").Result;
            if (response.IsSuccessStatusCode) {
                var catalogos = response.Content.ReadAsStringAsync().Result;
                var catalogosList = JsonConvert.DeserializeObject<List<Catalogo>>(catalogos);
                listView.ItemsSource = catalogosList;



            }
     }
  }
}
