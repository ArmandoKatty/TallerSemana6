using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TallerSemana6
{
    public partial class MainPage : ContentPage
    {
        private const string URL = "http://192.168.1.197/simov/post.php";
        private readonly HttpClient client = new HttpClient();
        private ObservableCollection<Datos> _post;
        public MainPage()
        {
            InitializeComponent();
            GetData();
        }

        private async void GetData()
        {
            var content = await client.GetStringAsync(URL);
            List<Datos> post = JsonConvert.DeserializeObject<List<Datos>>(content);
            _post= new ObservableCollection<Datos>(post);
            MyListView.ItemsSource = _post;

        }

        private async void btnIrIngreso_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VentanaIngreso());
            //DependencyService.Get<Mensaje>().ShortAlert("mensaje de prueba");
        }

       

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
           Datos post = _post[0];
           await client.DeleteAsync($"{URL}?codigo={post.codigo}");
           _post.Remove(post);
            await DisplayAlert("Correcto", "Dato eliminado con éxito", "aceptar");
            await Navigation.PushAsync(new MainPage());
        }

        private async void btnModificar_Clicked(object sender, EventArgs e)
        {
            Datos post = _post[0];
            post.codigo = _post[0].codigo;
            post.nombre = _post[0].nombre;
            post.estado = _post[0].estado;
            await client.PutAsync($"{URL}?codigo={post.codigo}&nombre={post.nombre}&estado={post.estado}", null);
            await DisplayAlert("Correcto", "Dato actualizado con éxito", "aceptar");
            await Navigation.PushAsync(new MainPage());
        }
    }
}
