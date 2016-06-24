using System;
using System.Threading.Tasks;
using Android.Content.PM;
using Android.Hardware;

namespace HajaLuz
{
	class Flash
	{
		PackageManager packageManager;
		Camera camera;

		public Flash(PackageManager packageManager)
		{
			this.packageManager = packageManager;
		}

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

