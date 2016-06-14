using Android.App;
using Android.Widget;
using Android.OS;
using System;
using AH = Android.Hardware;
using Android.Content.PM;
using Android.Graphics;
using Android.Content.Res;

namespace HajaLuz
{
#pragma warning disable CS0618 // Classe Camera e obsoleta para API 21 acima
	[Activity(
		MainLauncher = true, 
		ScreenOrientation = ScreenOrientation.Portrait)]
	public class MainActivity : Activity
	{
		AH.Camera camera;
		AH.Camera.Parameters parametros;
		TextView txvByRns;
		
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);

			ToggleButton tbtInterruptor = FindViewById<ToggleButton>(Resource.Id.tbtInterruptor);
			tbtInterruptor.Click += LigaDesliga;

			txvByRns = FindViewById<TextView>(Resource.Id.txvByRns);
		}

		public void LigaDesliga(object sender, EventArgs e)
		{
			var toggleDoSender = sender as ToggleButton;
			Color corBackground;
			Color corTexto;

			if (toggleDoSender.Checked)
			{
				corTexto = Color.Black;
				corBackground = Resources.GetColor(Resource.Color.GreenBackground);

				MudarCor(corTexto, corBackground, toggleDoSender);

				camera = AH.Camera.Open();
				parametros = camera.GetParameters();
				
				parametros.FlashMode = AH.Camera.Parameters.FlashModeTorch;
				camera.SetParameters(parametros);
				camera.StartPreview();
			}
			else
			{
				corTexto = Color.White;
				corBackground = Resources.GetColor(Resource.Color.BlackBackground);

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
			txvByRns.SetTextColor(texto);
		}
	}
#pragma warning restore CS0618 // Classe Camera e obsoleta para API 21 acima
}