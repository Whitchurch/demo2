using NUnit.Framework;
using System;
using algorithimdevspace;
namespace algorithimtest
{
	[TestFixture ()]
	public class Sample12
	{

		[Test ()]


		/*
Sample 12: 

Input:

 

51 51 51
0 51 51
51 51 51
5 5 51

Expected output:

 

No

10
4 4
		*/


		public void TestCase12 ()
		{
			//Arrange
			MainClass.nodesOnpath =String.Empty;
			MainClass.TravelledFromOneEndofMatrixToNext = String.Empty;
			MainClass.RowGlobal = 4;
			MainClass.ColumnGlobal = 3;
			MainClass.MaximumAllowedPathWeight = 50;
			MainClass.sourcematrix = new int[4,3]{{51,51,51},{0,51,51},{51,51,51},{5,5,51}};


			//Act

			var result = MainClass.SplitMatrixintoSmallerPieces (MainClass.RowGlobal, MainClass.ColumnGlobal);
			MainClass.CheckAndStopIfPathWeightLimitExceeded (result, MainClass.MaximumAllowedPathWeight);
			MainClass.formatOutput (result);


			//Assert


			Assert.AreEqual("10",MainClass.minpathValue);
			Assert.AreEqual ("44",MainClass.nodesOnpath );
			Assert.AreEqual ( "No",MainClass.TravelledFromOneEndofMatrixToNext);	


		}





	}
}

