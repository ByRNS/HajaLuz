
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace EstudandoAndroid
{
	[Activity (Label = "FormularioActivity", Theme = "@style/Theme.Custom")]			
	public class FormularioActivity : Activity
	{
		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.Formulario);

			// Create your application here
		}

		[Java.Interop.Export("MostrarRegistro")]
		public void MostrarRegistro(View view)
		{
			EditText txtNome = (EditText)FindViewById (Resource.Id.txtNome);
			EditText txtTelefone = (EditText)FindViewById (Resource.Id.txtTelefone);

			Toast
				.MakeText (this, string.Format ("Nome.: {0}\nTelefone.:{1}", txtNome.Text, txtTelefone.Text), ToastLength.Long)
				.Show();
		}
	}
}

