using Android.Content.Res;
using Android.Graphics;
using Android.Widget;

namespace HajaLuz
{
	public class Background
	{
		readonly Resources resources;
		readonly LinearLayout linearLayout;
		readonly ToggleButton tbtInterruptor;

		public Background(Resources resources, LinearLayout linearLayout, ToggleButton tbtInterruptor)
		{
			this.resources = resources;
			this.linearLayout = linearLayout;
			this.tbtInterruptor = tbtInterruptor;
		}

		public void MudarCor(string desligar)
		{
			linearLayout.SetBackgroundColor(Color.White);
			tbtInterruptor.Text = desligar;
			tbtInterruptor.SetBackgroundColor(Color.White);
		}

		public void ImagemInterruptorLigado()
		{
			linearLayout.Background = resources.GetDrawable(Resource.Drawable.capa_interruptor_ligado);
			tbtInterruptor.Background = resources.GetDrawable(Resource.Drawable.interruptor_ligado);
		}

		public void ImagemInterruptorDesligado()
		{
			linearLayout.Background = resources.GetDrawable(Resource.Drawable.capa_interruptor_desligado);
			tbtInterruptor.Background = resources.GetDrawable(Resource.Drawable.interruptor_desligado);
			tbtInterruptor.Text = "";
		}
	}
}