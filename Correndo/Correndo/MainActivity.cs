using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content.PM;
using Android.Views;
using Android.Content;
using Android.Transitions;
using Android.Util;
using Android.Runtime;
using Java.Lang;
using Android.Animation;
using Android.Views.Animations;
using System;

namespace Correndo
{
	[Activity (Label = "Correndo", MainLauncher = true, Icon = "@mipmap/icon", ScreenOrientation=ScreenOrientation.Landscape)]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
		}

		[Java.Interop.Export ("Correr")]
		public void Correr(View view)
		{
			LinearLayout linear = (LinearLayout)FindViewById (Resource.Id.vgpLinear);
			ImageView imgBoneco1 = (ImageView)FindViewById (Resource.Id.imgBoneco1);
			ImageView imgBoneco2 = (ImageView)FindViewById (Resource.Id.imgBoneco2);
			//float x = imgBoneco1.GetX ();
			Animation anim = AnimationUtils.LoadAnimation (this, Resource.Animation.move);
				
			Animation an1 = new TranslateAnimation (0, new Random().Next(200), 0, 0);
			an1 = AnimationUtils.LoadAnimation (this, Resource.Animation.move);

			imgBoneco1.StartAnimation (an1);
			imgBoneco2.StartAnimation (an1);

			//imgBoneco1.StartAnimation (anim);

			//for (int i = 0; i < ani; i++) 
			//{		
				//imgBoneco1.SetX (x += 5);				
				//System.Threading.Tasks.Task.Delay (500);
			//}
		}
	}
}


