using Android.App;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Text;
using TallerSemana6;

[assembly: Xamarin.Forms.Dependency(typeof(MensajeAndroid))]
namespace TallerSemana6
{
    
    public class MensajeAndroid : Mensaje
    {
        public void LongAlert(string mensaje)
        {
            Toast.MakeText(Application.Context,mensaje, ToastLength.Long).Show();
        }

        public void ShortAlert(string mensaje)
        {
            Toast.MakeText(Application.Context, mensaje, ToastLength.Short).Show();
        }
    }
}
