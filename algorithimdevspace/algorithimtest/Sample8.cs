using NUnit.Framework;
using System;
using algorithimdevspace;
namespace algorithimtest
{
	[TestFixture ()]
	public class Sample8
	{

		[Test ()]


		/*
Sample 8: (Starting with >50)

Input:

69 10 19 10 19

51 23 20 19 12

60 12 20 11 10

 

Output:

No

0

[]
		*/


		public void TestCase8 ()
		{
			//Arrange
			MainClass.nodesOnpath =String.Empty;
			MainClass.TravelledFromOneEndofMatrixToNext = String.Empty;
			MainClass.RowGlobal = 3;
			MainClass.ColumnGlobal = 5;
			MainClass.MaximumAllowedPathWeight = 50;
			MainClass.sourcematrix = new int[3,5]{{69,10,19,10,19},{51,23,20,19,12},{60,12,20,11,10}};


			//Act

			var result = MainClass.SplitMatrixintoSmallerPieces (MainClass.RowGlobal, MainClass.ColumnGlobal);
			MainClass.CheckAndStopIfPathWeightLimitExceeded (result, MainClass.MaximumAllowedPathWeight);
			MainClass.formatOutput (result);


			//Assert


			Assert.AreEqual("0",MainClass.minpathValue);
			Assert.AreEqual ("",MainClass.nodesOnpath );
			Assert.AreEqual ( "No",MainClass.TravelledFromOneEndofMatrixToNext);	


		}





	}
}

