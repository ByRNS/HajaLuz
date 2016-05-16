using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using System;
using Android.Content;
using Android.Graphics;

namespace EstudandoAndroid
{
	[Activity (Label = "Estudando Android", MainLauncher = true, Icon = "@mipmap/icon1")]
	public class MainActivity : Activity
	{
		int count1 = 1, 
			count2 = 1, 
			count3 = 1;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// BOTÃO DESTROY
			Button btnDestroy = FindViewById<Button> (Resource.Id.btnDestroy);
			btnDestroy.Click += delegate {
				OnDestroy();
			};

			// CLICK POR DELEGATE
			Button btnDelegate = FindViewById<Button> (Resource.Id.btnClickDelegate);
            btnDelegate.Click += delegate {
                btnDelegate.Text = string.Format("{0}º click por delegate", count1++);
				UsandoToast("BOTÃO DELEGATE");
            };

            // CLICK POR EVENT
            Button btnEvent = (Button)FindViewById (Resource.Id.btnClickEvent);
			btnEvent.Click += (object sender, EventArgs e) => {
				btnEvent.Text = string.Format ("{0}º click por event", count2++);
				UsandoToast("BOTÃO EVENT");
			};
		}

		// CLICK POR ONCLICK
		// NESTE MODO A DLL Mono.Android.Export.dll DEVERÁ SER REFERENCIADA AO PROJETO
		// TAMBÉM E OBRIGATÓRIO PASSAR UM PARAMETRO DO TIPO View NO METODO CHAMADO PELO BOTÃO
		[Java.Interop.Export("MetodoContador")] // Metodo é exportado para o botão especificado
		public void MetodoContador(View view)
		{
			Button btnOn = (Button) FindViewById (Resource.Id.btnOnClick);
			btnOn.Text = string.Format ("{0}º click por OnClick", count3++);
			UsandoToast("BOTÃO ONCLICK");
		}

		/// <summary>
		/// Usandos the toast.
		/// </summary>
		/// <returns>The toast.</returns>
		/// <param name="msg">Message.</param>
		public void UsandoToast(string msg)
		{
			Toast
				.MakeText (this, msg, ToastLength.Long)
				.Show();
		}

		// CHAMA ACTIVITY DE FORMULARIO
		[Java.Interop.Export("AbrirFormulario")]
		public void AbrirFormulario(View view)
		{
			Intent iti = new Intent(this, typeof(FormularioActivity));
			StartActivity (iti);				
		}

		protected override void OnDestroy ()
		{
			OnDestroy();
		}

		/// <summary>
		/// Chamado quando o usuário clica no botão BACK
		/// </summary>
		public override void OnBackPressed()
		{
			UsandoToast ("BOTÃO BACK PRESSIONADO");

			AlertDialog.Builder builder = new AlertDialog.Builder(this);
			builder.SetTitle("Error");
			builder.SetMessage("Can't connect to the database.");
			builder.SetCancelable(false);
			builder.SetPositiveButton("OK", delegate { Finish(); });
			builder.Show();
		}

		/// <param name="menu">O menu de opções em que coloca os seus itens.</param>
		/// <summary>
		/// Inicializar o conteúdo do menu de opções padrão da Activity's.
		/// </summary>
		/// <returns>To be added.</returns>
		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			MenuInflater mi = new MenuInflater (this);
			mi.Inflate (Resource.Menu.optionMenu, menu);
			return true;
		}

		/// <param name="featureId">The panel that the menu is in.</param>
		/// <param name="item">The menu item that was selected.</param>
		/// <summary>
		/// Gera o evento item de menu selecionado.
		/// </summary>
		public override bool OnMenuItemSelected (int featureId, IMenuItem item)
		{
			switch (item.ItemId) 
			{
			case Resource.Id.item1:
				UsandoToast ("Item 1 ");
				break;
			case Resource.Id.item2:
				UsandoToast ("Item 2");
				break;
			default:
				break;
			}
			return true;
		}
	}
}


