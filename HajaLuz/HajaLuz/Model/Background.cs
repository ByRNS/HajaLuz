using Android.Content.Res;
using Android.Graphics;
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
            _tbtInterruptor.SetBackgroundColor(Color.White);
        }

        public void ImagemInterruptorLigado()
        {
            _linearLayout.Background = _resources.GetDrawable(Resource.Drawable.capa_interruptor_ligado);
            _tbtInterruptor.Background = _resources.GetDrawable(Resource.Drawable.interruptor_ligado);
        }

        public void ImagemInterruptorDesligado()
        {
            _linearLayout.Background = _resources.GetDrawable(Resource.Drawable.capa_interruptor_desligado);
            _tbtInterruptor.Background = _resources.GetDrawable(Resource.Drawable.interruptor_desligado);
            _tbtInterruptor.Text = "";
        }
    }
}