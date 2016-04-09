package md53a39796abd5bea6f2e82673b59664d68;


public class FormularioActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_MostrarRegistro:(Landroid/view/View;)V:__export__\n" +
			"";
		mono.android.Runtime.register ("EstudandoAndroid.FormularioActivity, EstudandoAndroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", FormularioActivity.class, __md_methods);
	}


	public FormularioActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == FormularioActivity.class)
			mono.android.TypeManager.Activate ("EstudandoAndroid.FormularioActivity, EstudandoAndroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void MostrarRegistro (android.view.View p0)
	{
		n_MostrarRegistro (p0);
	}

	private native void n_MostrarRegistro (android.view.View p0);

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
