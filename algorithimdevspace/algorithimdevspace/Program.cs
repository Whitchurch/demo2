using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;


namespace algorithimdevspace
{
	public class MainClass
	{
		

		//Input probes for testing the program
		public static int [,]sourcematrix;
		public static int ColumnGlobal = 0;
		public static int RowGlobal = 0;
		public static int MaximumAllowedPathWeight = 0;
		public const string ErrorMessage = "Invalid Matrix";

		//Output probes for getting the test results
		public static string minpathValue = String.Empty;
		public static string nodesOnpath = String.Empty;
		public static string TravelledFromOneEndofMatrixToNext = String.Empty;

		public static int[] limits;
		public static pathData[] CacheSubMatrixResults;
		public static pathData CombineCachedPathData;
		public  static int turns = 0;
		public static pathData minValue;

		public static void Main (string[] args)
		{

			//minValue = null;

			//  Step1: Enter the Rows in the matrix
			Console.WriteLine("Enter the number of rows:");
			int rows = Convert.ToInt32(Console.ReadLine ());
			RowGlobal = rows;




			//Step2: Enter the Columns in the matrix
			Console.WriteLine ("Enter the number of columns");
			int columns = Convert.ToInt32(Console.ReadLine ());
			ColumnGlobal = columns;

			//Step2.a: Enter maximum allowed path weight 
			Console.WriteLine("Enter maximum allowed path weight:");
			int mxAllowedPathWeight = Convert.ToInt32(Console.ReadLine ());
			MaximumAllowedPathWeight = mxAllowedPathWeight;

			bool validInput = GenerateUserInputFromRows (rows,columns);
			if (validInput == false) {
				Console.WriteLine (ErrorMessage);


			}



			//Step3: Generate the matrix..If number or empty matrix do not proceed further with processing.
			/*bool validInput = GenerateUserInput (rows,columns);
			if (validInput == false) {
				Console.WriteLine (ErrorMessage);


			}*/ 


	
			pathData minValue = MainClass.SplitMatrixintoSmallerPieces (rows,columns);

					



				//Only do this computation if user specified a Maxiumem allowed value for path data
				if (MaximumAllowedPathWeight > 0) {
					//Step5: Limit path value to stop it if it exceeds a maximum allowed path weight

					minValue = CheckAndStopIfPathWeightLimitExceeded (minValue, MaximumAllowedPathWeight);	

				}



				//Step5: Display the results, in the required format
				formatOutput (minValue);
			



				
		}



	





		#region "Helper Functions"



		//Logic to backtrack on min path data, and limit it to the point where it does not exceed a user entered limit; Limit = 50, 20 etc etc
		public static pathData CheckAndStopIfPathWeightLimitExceeded(pathData MinValue, int WeighLimit)
		{

			pathData minValue = MinValue;

			int sMinValue = minValue.minValue;
			String sReplace = minValue.rows.Replace (",", String.Empty);
			char[] s1RowTaken = sReplace.ToCharArray ();

			int CurrentColumn = ColumnGlobal - 1;
			int CurrentRow = s1RowTaken.Length - 1;
			int RowDataToRemove = 0;

			while (sMinValue > WeighLimit) 
			{


				sMinValue -= sourcematrix [Int32.Parse(s1RowTaken[CurrentRow].ToString()), CurrentColumn];



				if (CurrentRow != 0)
					CurrentRow--;
				if(CurrentColumn!=0)
					CurrentColumn--;

				RowDataToRemove++;


			}

			//Console.WriteLine (sMinValue);
			//Console.WriteLine ("Rows backtracked:" + CurrentColumn);

			int RowDataToPreserve = s1RowTaken.Length - RowDataToRemove;
			char[] s1RowTakenTillLimitAttained = new char[RowDataToPreserve];
			for (int i = 0; i < RowDataToPreserve; i++) {
				s1RowTakenTillLimitAttained [i] = s1RowTaken [i];
			}

			String sRowTakenTillLimit = new String (s1RowTakenTillLimitAttained);

			minValue.minValue = sMinValue;
			minValue.rows = sRowTakenTillLimit;
			minValue.columns = (minValue.columns.Length - CurrentColumn).ToString();

			return minValue;
				
		}


		//Display the results in the required format
		public static void formatOutput(pathData minValue)
		{
		

			pathData result = minValue;


			Console.WriteLine (result.minValue);
			minpathValue = result.minValue.ToString();



			String sReplace = result.rows.Replace (",", String.Empty);
			char[] s1 = sReplace.ToCharArray ();


			//No need to reverse, since i now travel left -> right
			/*Array.Reverse (s1);*/

			foreach (var item in s1) 
			{
				nodesOnpath += (Int32.Parse (item.ToString ()) + 1).ToString ();
				Console.Write(Int32.Parse (item.ToString ()) + 1);
			}




			Console.WriteLine(" ");

			if (s1.Length == ColumnGlobal) {
				Console.WriteLine ("Yes");
				TravelledFromOneEndofMatrixToNext = "Yes";			
			} else 
			{
				Console.WriteLine ("No");
				TravelledFromOneEndofMatrixToNext = "No";	
			}
		}




		//Generate all possible paths runs. Each run has (weightedCost, nodes in the path)
		public static pathData GenerateSmallestPossiblePaths(int rows, int columns)
		{
			pathData[] RunContext = new pathData[rows];
			var listOfRunContenxt = new List<pathData> ();


			
				if (turns == 0) {
					columns = 0;
				} else 
				{
					//no change ... keep the n-1 column
				}

			


			for (int i = 0; i < rows; i++) 
			{
				//Call shortest path algorithim
				RunContext[i] = MainClass.cost (i,columns);
				listOfRunContenxt.Add (RunContext [i]);


			}

			//This part is to get the least costly path from all the runs
			pathData minValue = new pathData (RunContext[0].minValue,RunContext[0].rows.ToString(),RunContext[0].columns.ToString());
			foreach (var item in listOfRunContenxt) 
			{

				if (item.minValue < minValue.minValue) {
					minValue.minValue = item.minValue;
					minValue.rows = item.rows;
					minValue.columns = item.columns;
				}
			}

			if (turns == 0) 
			{
				return minValue;
			} 

			else {
			
				minValue.minValue -=sourcematrix[rows-1,columns]; //remove overlapping element to neutralize the double counting that happens. as the same element gets counted twice when overlapping occurs to maintain continuity.

				var rowArray = minValue.rows.Split (',');
				var columnArray = minValue.columns.Split (',');

				rowArray = rowArray.Skip(1).ToArray(); 
				columnArray = columnArray.Skip(1).ToArray(); 

				minValue.rows = String.Empty;
				minValue.columns = String.Empty;

				for (int i = 0; i < rowArray.Length; i++) 
				{
					minValue.rows += rowArray[i].ToString () + ",";
				}

				for (int i = 0; i < columnArray.Length; i++) 
				{
					minValue.columns += columnArray[i].ToString () + ",";
				}

				String s1 = minValue.rows.Remove(minValue.rows.Length - 1);
				String s2 = minValue.columns.Remove(minValue.columns.Length - 1);
				minValue.rows = s1;
				minValue.columns = s2;

				return minValue;
			}

		}



		//Construct the input matrix - method2: entering one row at a time ex:- 1234, 2345, 2345, 6789 for a 4x4 matrix..
		public static bool GenerateUserInputFromRows(int rows,int columns)
		{
			try
			{
			Console.WriteLine ("Entering one row at a time ex:- 1234, 2345, 2345, 6789 for a 4x4 matrix.. ");
			String inputStream = Console.ReadLine ();
			MainClass.sourcematrix = new int[rows,columns];
			String[] rowSplit = inputStream.Split (',');

			for (int i = 0; i < rows; i++) 
			{
                    String[] tempStorage = rowSplit[i].Split(' ');

				for (int j = 0; j < columns; j++) {
					MainClass.sourcematrix [i, j] = Int32.Parse (tempStorage [j].ToString());
				}
			}
				return true;
			}
			catch(Exception ex) {
				return false;
			}
		}


		//Construct the input matrix - method1: entering one element at a time
		public static bool GenerateUserInput(int rows, int columns)
		{
			try
			{
			MainClass.sourcematrix = new int[rows,columns];

			for (int i = 0; i < rows; i++)
			{

				for (int j = 0; j < columns; j++) 
				{
					Console.WriteLine ("Enter element at location ["+i+"] ["+j+"]");
					MainClass.sourcematrix [i,j] = Convert.ToInt32(Console.ReadLine());


				}

			}
				return true;
			}
			catch(System.Exception ex) {

				return false;
			}


		}






		//The shortest path algorithim
		public static pathData cost(int i, int j)
		{
			

			

				//If we are a cell i in the leftmost column return the value in that cell, as there are no other columns to the left of us to look at.
				if (j == limits[turns]-1) 
				{
				var p1 = new pathData (MainClass.sourcematrix [i, j],i.ToString(),j.ToString());	
					return p1;

					//return MainClass.sourcematrix [i, 0];
				}
				//If we are in any other column other than the last column. Look at cells in the next column to the left of our column. That are on the top, left and bottom, to find the min weighted one
				int rightPosX = i % RowGlobal;
				int rightPosY = j + 1;
			    pathData right = cost (rightPosX, rightPosY);

				int upPosX = (i - 1 + RowGlobal) % RowGlobal;
				int upPosY = j+1;
				pathData up = cost (upPosX, upPosY);

				int downPosX = (i + 1) % RowGlobal;
				int downPosY = j + 1;
				pathData down = cost (downPosX, downPosY);


				var listOfCosts = new List<pathData>{right,up,down};
				pathData minValue = new pathData (right.minValue,right.rows.ToString(),right.columns.ToString());
				foreach (var item in listOfCosts) 
				{



					if (item.minValue < minValue.minValue) {
						minValue.minValue = item.minValue;
						minValue.rows = item.rows;
						minValue.columns = item.columns;
					}
				}
				

				minValue.minValue = MainClass.sourcematrix[i,j]+minValue.minValue;
				minValue.rows = i.ToString () + "," + minValue.rows.ToString ();
				minValue.columns = j.ToString () + "," + minValue.columns.ToString ();
						
		



			return minValue;


		}


		public static  pathData SplitMatrixintoSmallerPieces(int rows,int columns)
		{
			//Check if matrix columns are too big, we don't care about rows because, we are traversing left to right. Only column depth matters...
			int MatrixColumnCount = MainClass.sourcematrix.GetLength(1);

			if (MatrixColumnCount > 10) { // I choose 10 because the algorithim was working ok till this point, so i chose it as maximum bound for the column
				//How many sets of size 10 matrix
				int setsOfTen = MatrixColumnCount / 10;
				int nonSetOfTen = MatrixColumnCount % 10;

				//Generate limit for the sets
				limits = new int[setsOfTen+1];
				for (int i = 0; i < setsOfTen; i++) {
					limits [i] = (i + 1) * 10;
				}
				if (nonSetOfTen != 0) {
					limits [setsOfTen] = (10 * setsOfTen) + 3;
				}

				turns = 0;
				int previousTurn = 0;
				CacheSubMatrixResults = new pathData[setsOfTen+1];

				while (turns < setsOfTen) {
					//Run against these generated limits
					if (turns == 0) { //We need to start chaining results from the previous matrix after the first turn, to maintain continuity...

						CacheSubMatrixResults [turns] = GenerateSmallestPossiblePaths (rows, limits [turns]);	
					} else {

						String previousRow = CacheSubMatrixResults [previousTurn].rows;
						String previousColumn = CacheSubMatrixResults [previousTurn].columns;

						var rowArray = previousRow.Split (',');
						var columnArray = previousColumn.Split (',');


						int Pr1 = Int32.Parse (rowArray [rowArray.Length - 1]) + 1;
						int Pc1 = Int32.Parse (columnArray [columnArray.Length - 1]);
						//String s1Temp = previousRow.Replace (",", string.Empty);
						//String s2Temp = previousColumn.Replace (",", string.Empty);

						//String Pr1 = s1Temp.Substring (s1Temp.Length - 1);
						//String Pc1 = s2Temp.Substring (s1Temp.Length - 1);

						CacheSubMatrixResults [turns] = GenerateSmallestPossiblePaths (Pr1,Pc1);
					}


					if (CombineCachedPathData == null) {
						CombineCachedPathData = new pathData (CacheSubMatrixResults [turns].minValue, CacheSubMatrixResults [turns].rows, CacheSubMatrixResults [turns].columns);
					} else {
						CombineCachedPathData.minValue += CacheSubMatrixResults [turns].minValue;
						CombineCachedPathData.rows += CacheSubMatrixResults [turns].rows;
						CombineCachedPathData.columns += CacheSubMatrixResults [turns].columns;
					}

					previousTurn = turns;
					turns++;

				}
				//Account for non-set of 10 or the remainder matrices that dont have 10 columns
				if (nonSetOfTen != 0) 
				{
					String previousRow = CombineCachedPathData.rows;
					String previousColumn = CombineCachedPathData.columns;


					var rowArray = previousRow.Split (',');
					var columnArray = previousColumn.Split (',');


					int Pr1 = Int32.Parse (rowArray [rowArray.Length - 1]) + 1;
					int Pc1 = Int32.Parse (columnArray [columnArray.Length - 1]);



					CacheSubMatrixResults [turns] = GenerateSmallestPossiblePaths (Pr1,Pc1);
					CombineCachedPathData.minValue += CacheSubMatrixResults [turns].minValue;
					CombineCachedPathData.rows += CacheSubMatrixResults [turns].rows;
					CombineCachedPathData.columns += CacheSubMatrixResults [turns].columns;
				}

				//Step4: Generate all possible paths  and then return the smallest value path.
				minValue = CombineCachedPathData;




			} else {
				turns = 0;
				limits = new int[1];
				limits[0] = ColumnGlobal;

				//Step4: Generate all possible paths  and then return the smallest value path.
				minValue = GenerateSmallestPossiblePaths (rows, limits[turns]);

			}

			return minValue;
		}

		#endregion

	}
}
