﻿using NUnit.Framework;
using System;
using algorithimdevspace;
namespace algorithimtest
{
	[TestFixture ()]
	public class Sample11
	{

		[Test ()]


		/*
Sample 10: (Negative values)

Input:

 

51 51
0 51
51 51
5 5

Expected output:

 

Yes
10
4 4


		*/


		public void TestCase11 ()
		{
			//Arrange
			MainClass.nodesOnpath =String.Empty;
			MainClass.TravelledFromOneEndofMatrixToNext = String.Empty;
			MainClass.RowGlobal = 4;
			MainClass.ColumnGlobal = 2;
			MainClass.sourcematrix = new int[4,2]{{51,51},{0,51},{51,51},{5,5}};


			//Act

			var result = MainClass.SplitMatrixintoSmallerPieces (MainClass.RowGlobal, MainClass.ColumnGlobal);
			MainClass.formatOutput (result);


			//Assert


			Assert.AreEqual(MainClass.minpathValue,"10");
			Assert.AreEqual (MainClass.nodesOnpath, "44");
			Assert.AreEqual (MainClass.TravelledFromOneEndofMatrixToNext, "Yes");	


		}





	}
}

