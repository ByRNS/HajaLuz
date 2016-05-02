using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System;
using Android.Content;

namespace EstudandoAndroid
{
	[Activity (Label = "Estudando Android", MainLauncher = true, Icon = "@mipmap/icon1")]
	public class MainActivity : Activity
	{
		int count1 = 1, 
			count2 = 1, 
			count3 = 1;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// CLICK POR DELEGATE
			Button btnDelegate = FindViewById<Button> (Resource.Id.btnClickDelegate);

            btnDelegate.Click += delegate
            {
                btnDelegate.Text = string.Format("{0}º click por delegate", count1++);
                UsandoToast("Cor do texto do botão clicado" + btnDelegate.SolidColor);
            };

            // CLICK POR EVENT
            Button btnEvent = (Button)FindViewById (Resource.Id.btnClickEvent);
			btnEvent.Click += (object sender, EventArgs e) => {
				btnEvent.Text = string.Format ("{0}º click por event", count2++);
				UsandoToast("Cor do texto do botão clicado" + btnEvent.SolidColor);
			};
		}

		// CLICK POR ONCLICK
		// NESTE MODO A DLL Mono.Android.Export.dll DEVERÁ SER REFERENCIADA AO PROJETO
		// TAMBÉM E OBRIGATÓRIO PASSAR UM PARAMETRO DO TIPO View NO METODO CHAMADO PELO BOTÃO
		[Java.Interop.Export("MetodoContador")] // Metodo é exportado para o botão especificado
		public void MetodoContador(View view)
		{
			Button btnOn = (Button) FindViewById (Resource.Id.btnOnClick);
			btnOn.Text = string.Format ("{0}º click por OnClick", count3++);
			UsandoToast("Cor do texto do botão clicado" + btnOn.SolidColor);
		}

		// USANDO TOAST
		public void UsandoToast(string msg)
		{
			Toast
				.MakeText (this, msg, ToastLength.Long)
				.Show();
		}

		// CHAMA ACTIVITY DE FORMULARIO
		[Java.Interop.Export("AbrirFormulario")]
		public void AbrirFormulario(View view)
		{
			Intent iti = new Intent(this, typeof(FormularioActivity));
			StartActivity (iti);				
		}
	}
}


