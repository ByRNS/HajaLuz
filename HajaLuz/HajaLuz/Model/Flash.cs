using Android.Content;
using Android.Content.PM;
using Android.Hardware;
using Android.Hardware.Camera2;
using Android.OS;
using System.Linq;

namespace HajaLuz
{
    public class Flash
    {
        PackageManager _packageManager;
        Camera _camera;
        CameraManager _cameraManager;
        string _cameraID;

        public Flash(PackageManager packageManager, Context context, Camera camera)
        {
            _packageManager = packageManager;
            Inicializacao(context);
            _camera = camera;
        }

        private void Inicializacao(Context context)
        {
            try
            {
                _cameraManager = context.GetSystemService(Context.CameraService) as CameraManager;
                _cameraID = _cameraManager?.GetCameraIdList()?.FirstOrDefault();
            }
            catch (CameraAccessException e)
            {
                Android.Util.Log.Debug("#CAMERA#", e.Message);
            }
        }

        public bool TemFlash { get => _packageManager.HasSystemFeature(PackageManager.FeatureCameraFlash); }

        public bool Liga()
        {
            if (TemFlash)
            {
                if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                    _cameraManager?.SetTorchMode(_cameraID, true);
                else
                {
                    _camera.Reconnect();
                    SetFlashMode(Camera.Parameters.FlashModeTorch);
                    _camera.StartPreview();
                }

                return true;
            }

            return false;
        }

        public void Desliga()
        {
            if (_cameraManager != null && TemFlash.Equals(true))
                _cameraManager.SetTorchMode(_cameraID, false);
            else if (_camera != null && TemFlash.Equals(true))
            {
                SetFlashMode(Camera.Parameters.FlashModeOff);
                _camera.StopPreview();
            }
        }

        private void SetFlashMode(string flashMode)
        {
            var parametros = _camera.GetParameters();
            parametros.FlashMode = flashMode;
            _camera.SetParameters(parametros);
        }
    }
}