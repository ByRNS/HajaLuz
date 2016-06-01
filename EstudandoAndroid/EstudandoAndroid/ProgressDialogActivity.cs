
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
	[Activity]
	public class ProgressDialogActivity : Activity
	{
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.ProgressDialog);

			// Create your application here
			Button btnIndeterminado = FindViewById<Button>(Resource.Id.btnProgressInd);
			Button btnDeterminado = FindViewById<Button>(Resource.Id.btnProgressDet);

			btnIndeterminado.Click += delegate {
				ProgressDialog pd = ProgressDialog.Show(
					this,
					"Titulo",
					"Mensagem de Progresso...",
					true,
					true);
			};

			btnDeterminado.Click += delegate
			{
				ProgressDialog pd = new ProgressDialog(this);

				pd.SetTitle("Titulo");
				pd.SetMessage("Mensagem de Progresso...");
				pd.SetCancelable(true);
				pd.Max = 800;
				pd.SetButton(
					(int)DialogButtonType.Negative,
					"Abortar",
					(s, e) => { });
				pd.SetButton(
					(int)DialogButtonType.Neutral,
					"Pausar",
					(s, e) => { });
				pd.SetButton(
					(int)DialogButtonType.Positive,
					"Continuar",
					(s, e) => { });
				
				pd.SetProgressStyle(ProgressDialogStyle.Horizontal);
				pd.IncrementProgressBy(300);

				pd.Show();
			};
		}
	}
}

