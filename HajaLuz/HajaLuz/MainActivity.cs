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
#pragma warning disable CS0618 // Classe Camera e obsoleta
	[Activity(
		MainLauncher = true, 
		ScreenOrientation = ScreenOrientation.Portrait)]
	public class MainActivity : Activity
	{
		ToggleButton tbtInterruptor;
		AH.Camera camera;
		AH.Camera.Parameters parametros;
		
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
				corTexto = new Color(0, 0, 0);
				corBackground = new Color(108, 211, 146);

				camera = AH.Camera.Open();
				parametros = camera.GetParameters();
				
				parametros.FlashMode = AH.Camera.Parameters.FlashModeTorch;
				camera.SetParameters(parametros);
				camera.StartPreview();

				toggleDoSender.SetTextColor(corTexto);
				toggleDoSender.SetBackgroundColor(corBackground);
			}
			else
			{
				corTexto = new Color(255, 255, 255);
				corBackground = new Color(0, 0, 0);

				camera.StopPreview();
				camera.Release();
				camera = null;

				toggleDoSender.SetTextColor(corTexto);
				toggleDoSender.SetBackgroundColor(corBackground);
			}
		}
	}
#pragma warning restore CS0618 // Classe Camera e obsoleta
}


