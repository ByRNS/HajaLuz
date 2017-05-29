using Android.Content.PM;
using Android.Hardware;

namespace HajaLuz
{
    public class Flash
    {
        PackageManager _packageManager;
        Camera _camera;

        public Flash(PackageManager packageManager)
        {
            _packageManager = packageManager;
        }

        public bool TemFlash { get { return _packageManager.HasSystemFeature(PackageManager.FeatureCameraFlash); } }

        public bool Liga()
        {
            if (TemFlash)
            {
                _camera = Camera.Open();

                var parametros = _camera.GetParameters();
                parametros.FlashMode = Camera.Parameters.FlashModeTorch;

                _camera.SetParameters(parametros);
                _camera.StartPreview();

                return true;
            }
            return false;
        }

        public void Desliga()
        {
            if (_camera != null && TemFlash.Equals(true))
            {
                _camera.StopPreview();
                _camera.Release();
                _camera = null;
            }
        }
    }
}