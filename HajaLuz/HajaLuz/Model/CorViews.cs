using Android.Graphics;
using Android.Widget;

namespace HajaLuz
{
	public class CorViews
	{
		public void MudarCor(Color corTexto, Color corBackground, ToggleButton tbtInterruptor, TextView txvByRns)
		{
			tbtInterruptor.SetTextColor(corTexto);
			tbtInterruptor.SetBackgroundColor(corBackground);

			if (!corTexto.Equals(corBackground))
				txvByRns.SetTextColor(corTexto);
			else
				txvByRns.SetTextColor(Color.Black);
		}
	}
}

