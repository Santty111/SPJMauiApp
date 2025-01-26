using Newtonsoft.Json;
using SPJMauiApp.Models;
using SPJMauiApp.ViewModels;

namespace SPJMauiApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new CatalogoViewModel();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7188/api/");

            var response = client.GetAsync("Catalogo").Result;
            if (response.IsSuccessStatusCode)
            {
                var catalogos = response.Content.ReadAsStringAsync().Result;
                var catalogosList = JsonConvert.DeserializeObject<List<Catalogo>>(catalogos);

                // Concatenar la URL base con el path de la imagen
                foreach (var catalogo in catalogosList)
                {
                    catalogo.ImagePath = "https://localhost:7188" + catalogo.ImagePath;

                    // Establecer la visibilidad de la imagen como falsa inicialmente
                    catalogo.IsImageVisible = false;

                    Console.WriteLine("Image Path: " + catalogo.ImagePath);
                }

                // Asignamos la lista de catálogo a la fuente de elementos del ListView
                listView.ItemsSource = catalogosList;
            }
        }
    }
}
