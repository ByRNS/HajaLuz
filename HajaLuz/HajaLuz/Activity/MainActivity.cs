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
		Flash flash;

		LinearLayout linearLayout;
		ToggleButton tbtInterruptor;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);

			flash = new Flash(PackageManager);

			linearLayout = FindViewById<LinearLayout>(Resource.Id.lnlBackground);
			tbtInterruptor = FindViewById<ToggleButton>(Resource.Id.tbtInterruptor);
			tbtInterruptor.Click += LigaDesliga;
		}

		protected override void OnStop()
		{
			base.OnStop();

			tbtInterruptor.Checked = false;
			tbtInterruptor.CallOnClick();
		}

		public void LigaDesliga(object sender, EventArgs e)
		{
			var background = new Background(Resources, linearLayout, tbtInterruptor);
			var toggleDoSender = (ToggleButton)sender;

			if (toggleDoSender.Checked)
			{
				if (flash.Liga())
					background.ImagemInterruptorLigado();
				else {
					var strDesligar = Resources.GetString(Resource.String.desligar);
					background.MudarCor(strDesligar);
				}
			}
			else
			{
				flash.Desliga();
				background.ImagemInterruptorDesligado();
			}
		}
	}
}