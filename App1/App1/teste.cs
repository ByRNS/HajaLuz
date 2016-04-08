
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

namespace App1
{
	[Activity (Label = "teste")]			
	public class teste : Activity
	{
		TextView text;
		Button btnSalvar;
		EditText nome;
		EditText senha;
		RadioGroup radioGroup;
		TextView tvLista;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.teste);

			// Create your application here
			text = (TextView)FindViewById(Resource.Id.text);
			text.Text = "Activity 2 Iniciada";  

			nome = (EditText)FindViewById (Resource.Id.edNome);
			senha = (EditText)FindViewById (Resource.Id.edSenha);
			radioGroup = (RadioGroup) FindViewById(Resource.Id.radioGroup1);
			tvLista = (TextView)FindViewById (Resource.Id.tvLista);
			tvLista.Text = "";

			btnSalvar = (Button)FindViewById (Resource.Id.btnGravar);

			btnSalvar.Click += delegate 
			{
				if((!String.IsNullOrWhiteSpace(nome.Text) && !String.IsNullOrWhiteSpace(senha.Text))) 
					MostraDadosDigitados (nome.Text, senha.Text, radioGroup);
				else
					Toast.MakeText (this, "Nome ou senha não informado!", ToastLength.Long).Show ();  
			};
        }

		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			MenuInflater mi = new MenuInflater (this);
			mi.Inflate (Resource.Menu.menu1, menu);
			return true;
		}

		public void MostraDadosDigitados(string pNome, string pSenha, RadioGroup pRadioGroup)
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
			senha.Text = "";
			radioGroup.Check (radioMasc.Id);
			nome.RequestFocus ();

			//Toast.MakeText (this, strOutput, ToastLength.Long).Show ();
			tvLista.Text += strOutput + "----------\n";
		}
	}
}

