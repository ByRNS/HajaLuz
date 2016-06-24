using Android.App;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Widget;

namespace HajaLuz
{
	public class Background
	{
		Resources resources;

		public Background(Resources resources)
		{
			this.resources = resources;
		}

		public void MudarCor(LinearLayout linearLayout, ToggleButton tbtInterruptor)
		{
			linearLayout.SetBackgroundColor(Color.White);

			tbtInterruptor.SetTextColor(Color.White);
			tbtInterruptor.SetBackgroundColor(Color.White);
		}

		public void ImagemInterruptorLigado(LinearLayout linearLayout, ToggleButton tbtInterruptor)
		{
			linearLayout.Background = resources.GetDrawable(Resource.Drawable.capa_interruptor_ligado);
			tbtInterruptor.Background = resources.GetDrawable(Resource.Drawable.interruptor_ligado);
		}

		public void ImagemInterruptorDesligado(LinearLayout linearLayout, ToggleButton tbtInterruptor)
		{
			linearLayout.Background = resources.GetDrawable(Resource.Drawable.capa_interruptor_desligado);
			tbtInterruptor.Background = resources.GetDrawable(Resource.Drawable.interruptor_desligado);
		}
	}
}

