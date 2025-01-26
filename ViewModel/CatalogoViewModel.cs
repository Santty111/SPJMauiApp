using SPJMauiApp.Models;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace SPJMauiApp.ViewModels
{
    public class CatalogoViewModel : BindableObject
    {
        private ObservableCollection<Catalogo> _catalogos;
        public ObservableCollection<Catalogo> Catalogos
        {
            get => _catalogos;
            set
            {
                _catalogos = value;
                OnPropertyChanged();
            }
        }

        public Command LoadCatalogosCommand { get; }
        public Command<Catalogo> ShowImageCommand { get; }

        public CatalogoViewModel()
        {
            LoadCatalogosCommand = new Command(async () => await LoadCatalogos());
            ShowImageCommand = new Command<Catalogo>(ShowImage);
        }

        private async Task LoadCatalogos()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7188/api/");

            var response = await client.GetAsync("Catalogo");
            if (response.IsSuccessStatusCode)
            {
                var catalogosJson = await response.Content.ReadAsStringAsync();
                var catalogosList = JsonConvert.DeserializeObject<List<Catalogo>>(catalogosJson);

                // Concatenamos la URL base con el path de la imagen
                foreach (var catalogo in catalogosList)
                {
                    catalogo.ImagePath = "https://localhost:7188" + catalogo.ImagePath;
                    catalogo.IsImageVisible = false; // Inicializamos la visibilidad de la imagen como false
                }

                Catalogos = new ObservableCollection<Catalogo>(catalogosList);
            }
        }

        private void ShowImage(Catalogo catalogo)
        {
            catalogo.IsImageVisible = !catalogo.IsImageVisible; // Alternar visibilidad
            OnPropertyChanged(nameof(Catalogos)); // Notificar que los datos han cambiado
        }
    }
}
