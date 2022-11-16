using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TallerSemana6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VentanaIngreso : ContentPage
    {
        private const string URL = "http://172.17.240.1/simov/post.php";
        public VentanaIngreso()
        {
            InitializeComponent();
        }

        private void btnInsertar_Clicked(object sender, EventArgs e)
        {
            try { 
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();
                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("estado", txtEstado.Text);
               
                cliente.UploadValues(URL, "POST", parametros);
                DisplayAlert("Correcto", "Dato ingresado con éxito", "aceptar");
            }
            catch(Exception ex)
            {
                DisplayAlert("Alerta", ex.Message, "aceptar");
            }
        }

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}