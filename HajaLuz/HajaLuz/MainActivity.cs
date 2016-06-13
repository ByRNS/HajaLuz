using Android.App;
using Android.Widget;
using Android.OS;
using System;
using AH = Android.Hardware;
using Android.Content.PM;
using Android.Graphics;
using Android.Views;

namespace HajaLuz
{
#pragma warning disable CS0618 // Classe Camera e obsoleta
	[Activity(
		MainLauncher = true, 
		ScreenOrientation = ScreenOrientation.Portrait)]
	public class MainActivity : Activity
	{
		ToggleButton tbtInterruptor;
		AH.Camera camera;
		AH.Camera.Parameters parametros;
		Color black = new Color(0, 0, 0);
		
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);

			tbtInterruptor = FindViewById<ToggleButton>(Resource.Id.tbtInterruptor);

			tbtInterruptor.Click += Interruptor;
		}

		public void Interruptor(object sender, EventArgs e)
		{
			var toggleDoSender = sender as ToggleButton;
			Color corBackground;
			Color corTexto;

			if (toggleDoSender.Checked)
			{
				corTexto = black;
				corBackground = new Color(108, 211, 146);
				MudarCor(corTexto, corBackground, toggleDoSender);

				camera = AH.Camera.Open();
				parametros = camera.GetParameters();
				
				parametros.FlashMode = AH.Camera.Parameters.FlashModeTorch;
				camera.SetParameters(parametros);
				camera.StartPreview();
			}
			else
			{
				corTexto = new Color(255, 255, 255);
				corBackground = black;
				MudarCor(corTexto, corBackground, toggleDoSender);

				camera.StopPreview();
				camera.Release();
				camera = null;
			}
		}

		private void MudarCor(Color texto, Color backgroud, ToggleButton toggleButton)
		{
			toggleButton.SetTextColor(texto);
			toggleButton.SetBackgroundColor(backgroud);
		}
	}
#pragma warning restore CS0618 // Classe Camera e obsoleta
}


