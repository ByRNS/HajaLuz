using System;
using NUnit.Framework;

namespace EstudandoAndroid
{
	[TestFixture]
	public class Test
	{
		public Test ()
		{
		}

		[Test]
		public void MetodoTeste()
		{
			int a = 2;
			int b = 4;

			Assert (a, b);
				
		}			
	}
}

