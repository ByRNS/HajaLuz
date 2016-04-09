package md53a39796abd5bea6f2e82673b59664d68;


public class MainActivity
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_MetodoContador:(Landroid/view/View;)V:__export__\n" +
			"n_AbrirFormulario:(Landroid/view/View;)V:__export__\n" +
			"";
		mono.android.Runtime.register ("EstudandoAndroid.MainActivity, EstudandoAndroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MainActivity.class, __md_methods);
	}


	public MainActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MainActivity.class)
			mono.android.TypeManager.Activate ("EstudandoAndroid.MainActivity, EstudandoAndroid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void MetodoContador (android.view.View p0)
	{
		n_MetodoContador (p0);
	}

	private native void n_MetodoContador (android.view.View p0);


	public void AbrirFormulario (android.view.View p0)
	{
		n_AbrirFormulario (p0);
	}

	private native void n_AbrirFormulario (android.view.View p0);

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
