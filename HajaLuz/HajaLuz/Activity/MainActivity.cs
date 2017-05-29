using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Content.PM;
using Android.Content.Res;

namespace HajaLuz
{
    [Activity(
        MainLauncher = true,
        ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        Flash _flash;
        LinearLayout _linearLayout;
        ToggleButton _tbtInterruptor;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            _flash = new Flash(PackageManager);

            _linearLayout = FindViewById<LinearLayout>(Resource.Id.lnlBackground);
            _tbtInterruptor = FindViewById<ToggleButton>(Resource.Id.tbtInterruptor);
            _tbtInterruptor.Click += LigaDesliga;
        }

        protected override void OnStop()
        {
            base.OnStop();

            _tbtInterruptor.Checked = false;
            _tbtInterruptor.CallOnClick();
        }

        private void LigaDesliga(object sender, EventArgs e)
        {
            var background = new Background(Resources, _linearLayout, _tbtInterruptor);
            var toggleDoSender = (ToggleButton)sender;

            if (toggleDoSender.Checked)
            {
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
                _flash.Desliga();
                background.ImagemInterruptorDesligado();
            }
        }
    }
}