using System;
using Android.Content.PM;
using Android.Hardware;

namespace HajaLuz
{
	public class Flash
	{
		PackageManager packageManager = (PackageManager)new Object();
		Camera camera;

		public bool TemFlash
		{
			get
			{
				return packageManager.HasSystemFeature(PackageManager.FeatureCameraFlash);
			}
		}

		public bool Liga()
		{
			if (TemFlash)
			{
				camera = Camera.Open();
				
				var parametros = camera.GetParameters();
				parametros.FlashMode = Camera.Parameters.FlashModeTorch;
				
				camera.SetParameters(parametros);
				camera.StartPreview();

				return true;
			}
			return false;
		}

		public void Desliga()
		{
			if (camera != null && TemFlash.Equals(true))
			{
				camera.StopPreview();
				camera.Release();
				camera = null;
			}
		}
	}
}

