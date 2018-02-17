using Android.Content;
using Android.Media;
using Android.OS;

namespace HajaLuz
{
    public class Som
    {
        private SoundPool _soundPool;
        Context _context;

        public Som(Context context)
        {
            _soundPool = new SoundPool(3, Stream.Ring, 0);
            _context = context;
        }

        public void SomLiga()
        {
            PlayRingtone(Resource.Raw.switch_light_on);
            _soundPool.Play(_soundPool.Load(_context, Resource.Raw.switch_light_on, 1), 1, 1, 1, 0, 1);
        }

        public void SomDesliga()
        {
            PlayRingtone(Resource.Raw.switch_light_off);
            _soundPool.Play(_soundPool.Load(_context, Resource.Raw.switch_light_off, 1), 1, 1, 1, 0, 1);
        }

        private void PlayRingtone(int rawID)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.N)
            {
                var notification = Android.Net.Uri.Parse($"android.resource://{ _context.PackageName}/{rawID}");
                var ringtone = RingtoneManager.GetRingtone(_context, notification);
                ringtone.Play();
                return;
            }
        }
    }
}