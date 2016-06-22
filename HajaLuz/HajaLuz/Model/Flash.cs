using Android.Content.PM;
using Android.Hardware;

namespace HajaLuz
{
	public class Flash
	{
		PackageManager packageManager;
		Camera camera;

		public bool HasFlash
		{
			get
			{
				return packageManager.HasSystemFeature(PackageManager.FeatureCameraFlash);
			}
		}

		public bool Liga()
		{
			if (HasFlash)
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
			if (camera != null && HasFlash.Equals(true))
			{
				camera.StopPreview();
				camera.Release();
				camera = null;
			}
		}
	}
}

