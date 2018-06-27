using NUnit.Framework;
using System;
using algorithimdevspace;
namespace algorithimtest
{
	[TestFixture ()]
	public class Sample99
	{

		[Test ()]


		/*
Sample 13: Large number of columns

Input:

11111111111111111111
22222222222222222222

 

Output:
Yes
20
1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1 1
		*/


		public void TestCase99 ()
		{
			//Arrange
			MainClass.nodesOnpath =String.Empty;
			MainClass.TravelledFromOneEndofMatrixToNext = String.Empty;
			MainClass.RowGlobal = 2;
			MainClass.ColumnGlobal = 20;
			MainClass.sourcematrix = new int[2,20]{{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},{2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2}};


			//Act

			var result = MainClass.SplitMatrixintoSmallerPieces (MainClass.RowGlobal, MainClass.ColumnGlobal);
			MainClass.formatOutput (result);


			//Assert


			Assert.AreEqual(MainClass.minpathValue,"20");
			Assert.AreEqual (MainClass.nodesOnpath, "11111111111111111111");
			Assert.AreEqual (MainClass.TravelledFromOneEndofMatrixToNext, "Yes");	


		}





	}
}

