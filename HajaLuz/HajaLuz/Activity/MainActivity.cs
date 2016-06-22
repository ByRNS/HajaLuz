using Android.App;
using Android.Widget;
using Android.OS;
using System;
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
		Flash flash;
		readonly Color colorWhite = Color.White;
		Color colorGreenBackground;
		Color colorBlackBackground;

		TextView txvByRns;
		ToggleButton tbtInterruptor;
		
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);

			colorGreenBackground = Resources.GetColor(Resource.Color.GreenBackground);
			colorBlackBackground = Resources.GetColor(Resource.Color.BlackBackground);

			flash = new Flash();

			tbtInterruptor = FindViewById<ToggleButton>(Resource.Id.tbtInterruptor);
			tbtInterruptor.Click += LigaDesliga;

			txvByRns = FindViewById<TextView>(Resource.Id.txvByRns);
		}

		protected override void OnStop()
		{
			base.OnStop();

			tbtInterruptor.Checked = false;
			tbtInterruptor.CallOnClick();
		}

		public void LigaDesliga(object sender, EventArgs e)
		{
			bool flashLigado = flash.Liga();
			var corViews = new CorViews();

			var toggleDoSender = (ToggleButton) sender;

			if (toggleDoSender.Checked)
			{
				if (flashLigado)
				{
					corViews.MudarCor(Color.Black, colorGreenBackground, tbtInterruptor, txvByRns);
				}
				else
					corViews.MudarCor(colorWhite, colorWhite, tbtInterruptor, txvByRns);
			}
			else
			{
				corViews.MudarCor(colorWhite, colorBlackBackground, tbtInterruptor, txvByRns);
			}
		}
	}
#pragma warning restore CS0618 // Classe Camera e obsoleta para API 21 acima
}