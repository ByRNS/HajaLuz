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
		ToggleButton tbtInterruptor;

		Color corBackground;
		Color corTexto;
		
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);

			tbtInterruptor = FindViewById<ToggleButton>(Resource.Id.tbtInterruptor);
			tbtInterruptor.Click += LigaDesliga;

			txvByRns = FindViewById<TextView>(Resource.Id.txvByRns);
		}

		protected override void OnStop()
		{
			base.OnStop();

			if (camera != null)
			{
				Desliga();
				tbtInterruptor.Checked = false;
			}
		}

		public void LigaDesliga(object sender, EventArgs e)
		{
			var toggleDoSender = (ToggleButton) sender;

			if (toggleDoSender.Checked)
			{
				Liga();
			}
			else
			{
				Desliga();
			}
		}

		private void MudarCor(Color texto, Color backgroud, ToggleButton toggleButton)
		{
			toggleButton.SetTextColor(texto);
			toggleButton.SetBackgroundColor(backgroud);
			txvByRns.SetTextColor(texto);
		}

		private void Liga()
		{
			camera = AH.Camera.Open();
			parametros = camera.GetParameters();
			parametros.FlashMode = AH.Camera.Parameters.FlashModeTorch;
			camera.SetParameters(parametros);
			camera.StartPreview();

			corTexto = Color.Black;
			corBackground = Resources.GetColor(Resource.Color.GreenBackground);
			MudarCor(corTexto, corBackground, tbtInterruptor);
		}
		private void Desliga()
		{
			camera.StopPreview();
			camera.Release();
			camera = null;

			corTexto = Color.White;
			corBackground = Resources.GetColor(Resource.Color.BlackBackground);
			MudarCor(corTexto, corBackground, tbtInterruptor);
		}
	}
#pragma warning restore CS0618 // Classe Camera e obsoleta para API 21 acima
}