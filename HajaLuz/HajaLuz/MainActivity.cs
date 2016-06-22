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
		TextView txvByRns;
		ToggleButton tbtInterruptor;
		
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

			//if (camera != null)
				//DesligarFlash();

			tbtInterruptor.Checked = false;
			tbtInterruptor.CallOnClick();
		}

		public void LigaDesliga(object sender, EventArgs e)
		{
			var temFlash = PackageManager.HasSystemFeature(PackageManager.FeatureCameraFlash);
			var toggleDoSender = (ToggleButton) sender;
			var corBranca = Color.White;
			Color _corBackground;
			Color _corTexto;

			if (toggleDoSender.Checked)
			{
				if (temFlash)
				{
					LigarFlash();
					
					_corTexto = Color.Black;
					_corBackground = Resources.GetColor(Resource.Color.GreenBackground);
					MudarCorViews(_corTexto, _corBackground, tbtInterruptor);
				}
				else
					MudarCorViews(corBranca, corBranca, tbtInterruptor);
			}
			else
			{
				if (camera != null && temFlash.Equals(true))
					DesligarFlash();

				_corTexto = Color.White;
				_corBackground = Resources.GetColor(Resource.Color.BlackBackground);
				MudarCorViews(_corTexto, _corBackground, tbtInterruptor);
			}
		}

		private void MudarCorViews(Color corTexto, Color corBackground, ToggleButton toggleButton)
		{
			toggleButton.SetTextColor(corTexto);
			toggleButton.SetBackgroundColor(corBackground);
			txvByRns.SetTextColor(corTexto);
		}

		private void LigarFlash()
		{
			camera = AH.Camera.Open();
			
			var parametros = camera.GetParameters();
			parametros.FlashMode = AH.Camera.Parameters.FlashModeTorch;
			
			camera.SetParameters(parametros);
			camera.StartPreview();
		}

		private void DesligarFlash()
		{
			camera.StopPreview();
			camera.Release();
			camera = null;
		}
	}
#pragma warning restore CS0618 // Classe Camera e obsoleta para API 21 acima
}