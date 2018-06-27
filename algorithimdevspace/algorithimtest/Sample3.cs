using NUnit.Framework;
using System;
using algorithimdevspace;
namespace algorithimtest
{
	[TestFixture ()]
	public class Sample3
	{

		[Test ()]


		/*
Sample 3: (5X3 matrix with limit of 50)

Input:

19 10 19 10 19

21 23 20 19 12

20 12 20 11 10

 

Output:

No

48

[1 1 1]
		*/


		public void TestCase3 ()
		{
			//Arrange
			MainClass.nodesOnpath =String.Empty;
			MainClass.TravelledFromOneEndofMatrixToNext = String.Empty;
			MainClass.RowGlobal = 3;
			MainClass.ColumnGlobal = 5;
			MainClass.MaximumAllowedPathWeight = 50;
			MainClass.sourcematrix = new int[3,5]{{19,10,19,10,19},{21,23,20,19,12},{20,12,20,11,10}};


			//Act

			var result = MainClass.SplitMatrixintoSmallerPieces (MainClass.RowGlobal, MainClass.ColumnGlobal);
			MainClass.CheckAndStopIfPathWeightLimitExceeded (result, MainClass.MaximumAllowedPathWeight);
			MainClass.formatOutput (result);


			//Assert


			Assert.AreEqual("48",MainClass.minpathValue);
			Assert.AreEqual ("111",MainClass.nodesOnpath );
			Assert.AreEqual ( "No",MainClass.TravelledFromOneEndofMatrixToNext);	


		}





	}
}

