using Android.Content.Res;
using Android.Graphics;
using Android.Support.V4.Content.Res;
using Android.Util;
using Android.Widget;

namespace HajaLuz
{
    public class Background
    {
        readonly Resources _resources;
        readonly LinearLayout _linearLayout;
        readonly ToggleButton _tbtInterruptor;

        public Background(Resources resources, LinearLayout linearLayout, ToggleButton tbtInterruptor)
        {
            _resources = resources;
            _linearLayout = linearLayout;
            _tbtInterruptor = tbtInterruptor;
        }

        public void MudarCor(string desligar)
        {
            _linearLayout.SetBackgroundColor(Color.White);
            _tbtInterruptor.Text = desligar;
            _tbtInterruptor.SetTextSize(ComplexUnitType.Dip, 25f);
            _tbtInterruptor.SetBackgroundColor(Color.White);
        }

        public void ImagemInterruptorLigado()
        {
            _linearLayout.Background = ResourcesCompat.GetDrawable(_resources, Resource.Drawable.capa_interruptor_ligado, null);
            _tbtInterruptor.Background = ResourcesCompat.GetDrawable(_resources, Resource.Drawable.interruptor_ligado, null);
        }

        public void ImagemInterruptorDesligado()
        {
            _linearLayout.Background = ResourcesCompat.GetDrawable(_resources, Resource.Drawable.capa_interruptor_desligado, null);
            _tbtInterruptor.Background = ResourcesCompat.GetDrawable(_resources, Resource.Drawable.interruptor_desligado, null);
            _tbtInterruptor.Text = "";
        }
    }
}