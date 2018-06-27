using NUnit.Framework;
using System;
using algorithimdevspace;
namespace algorithimtest
{
	[TestFixture ()]
	public class Sample9
	{

		[Test ()]


		/*
Sample 9: (One value >50)

Input:

60 3 3 6

6 3 7 9

5 6 8 3

 

Output:

Yes

14

[3,2 1 3]
		*/


		public void TestCase9 ()
		{
			//Arrange
			MainClass.nodesOnpath =String.Empty;
			MainClass.TravelledFromOneEndofMatrixToNext = String.Empty;
			MainClass.RowGlobal = 3;
			MainClass.ColumnGlobal = 4;
			MainClass.MaximumAllowedPathWeight = 50;
			MainClass.sourcematrix = new int[3,4]{{60,3,3,6},{6,3,7,9},{5,6,8,3}};


			//Act

			var result = MainClass.SplitMatrixintoSmallerPieces (MainClass.RowGlobal, MainClass.ColumnGlobal);
			MainClass.CheckAndStopIfPathWeightLimitExceeded (result, MainClass.MaximumAllowedPathWeight);
			MainClass.formatOutput (result);


			//Assert


			Assert.AreEqual("14",MainClass.minpathValue);
			Assert.AreEqual ("3213",MainClass.nodesOnpath );
			Assert.AreEqual ( "Yes",MainClass.TravelledFromOneEndofMatrixToNext);	


		}





	}
}

