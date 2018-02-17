using Android;
using Android.App;
using Android.Content.PM;
using Android.Content.Res;
using Android.Hardware;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Widget;
using System;

namespace HajaLuz
{
    [Activity(
        MainLauncher = true,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        LinearLayout _linearLayout;
        ToggleButton _tbtInterruptor;
        Flash _flash;
        Background background;
        Camera _camera;
        Som _som;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            _linearLayout = FindViewById<LinearLayout>(Resource.Id.lnlBackground);
            _tbtInterruptor = FindViewById<ToggleButton>(Resource.Id.tbtInterruptor);
            _tbtInterruptor.Click += LigaDesliga;

            if (Build.VERSION.SdkInt < BuildVersionCodes.Lollipop)
                _camera = Camera.Open();

            _flash = new Flash(PackageManager, this, _camera);
            background = new Background(Resources, _linearLayout, _tbtInterruptor);

            _som = new Som(this);
        }

        private void LigaDesliga(object sender, EventArgs e)
        {
            // Se não possui permissão
            if (ContextCompat.CheckSelfPermission(this, PackageManager.FeatureCamera)
                != PackageManager.CheckPermission(PackageManager.FeatureCamera, PackageName))
            {
                // Solicita a permissão
                ActivityCompat.RequestPermissions(this, new String[] { Manifest.Permission.Camera }, 0);
            }
            else
            {
                var toggleDoSender = (ToggleButton)sender;

                if (toggleDoSender.Checked)
                {
                    _som.SomLiga();

                    if (_flash.Liga())
                        background.ImagemInterruptorLigado();
                    else
                    {
                        var strDesligar = Resources.GetString(Resource.String.desligar);
                        background.MudarCor(strDesligar);
                    }
                }
                else
                {
                    _som.SomDesliga();

                    _flash.Desliga();
                    background.ImagemInterruptorDesligado();
                }
            }
        }
    }
}