
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
		Button btnSalvar;
		EditText nome;
		EditText telefone;
		RadioGroup radioGroup;
		TextView tvLista;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.Formulario);

			// Create your application here
		}

		[Java.Interop.Export("MostrarRegistro")]
		public void MostrarRegistro(View view)
		{
			nome = (EditText)FindViewById (Resource.Id.txtNome);
			telefone = (EditText)FindViewById (Resource.Id.txtTelefone);
			radioGroup = (RadioGroup) FindViewById(Resource.Id.radioGroup1);
			tvLista = (TextView)FindViewById (Resource.Id.tvLista);
			tvLista.Text = "";

			btnSalvar = (Button)FindViewById (Resource.Id.btnSalvar);
			btnSalvar.Click += delegate 
			{
				if((!String.IsNullOrWhiteSpace(nome.Text) && !String.IsNullOrWhiteSpace(telefone.Text))) 
					MostraDadosDigitados (nome.Text, telefone.Text, radioGroup);
				else
					Toast.MakeText (this, "Nome ou telefone não informado!", ToastLength.Long).Show ();  
			};
		}

		private void MostraDadosDigitados(string pNome, string pSenha, RadioGroup pRadioGroup)
		{
			string sexo = "";
			var radioMasc = (RadioButton)FindViewById (Resource.Id.rbMasculino);

			var t = (pRadioGroup.CheckedRadioButtonId == radioMasc.Id) 
				? sexo = "Masculino" 
				: sexo = "Feminino";

			string strOutput = String.Format ("Nome.: {0}" +
				"\nSenha.: {1}" +
				"\nSexo.: {2}\n", pNome, pSenha, sexo);
			nome.Text = "";
			telefone.Text = "";
			radioGroup.Check (radioMasc.Id);
			nome.RequestFocus ();

			tvLista.Text += strOutput + "----------\n";
		}
	}
}

