using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Hardware;

namespace HajaLuz
{
#pragma warning disable CS0618 // Type or member is obsolete
	[Activity(Label = "Haja Luz!", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		ToggleButton tbtInterruptor;
		Camera camera;
		Camera.Parameters parametros;
		
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);

			tbtInterruptor = FindViewById<ToggleButton>(Resource.Id.tbtInterruptor);

			tbtInterruptor.Click += Interruptor;
		}

		public void Interruptor(object sender, EventArgs e)
		{
			var t = sender as ToggleButton;

			if (t.Checked)
			{
				camera = Camera.Open();
				parametros = camera.GetParameters();
				
				parametros.FlashMode = Camera.Parameters.FlashModeTorch;
				camera.SetParameters(parametros);
				camera.StartPreview();
			}
			else
			{
				camera.StopPreview();
				camera.Release();
				camera = null;
			}
		}
	}
#pragma warning restore CS0618 // Type or member is obsolete
}


