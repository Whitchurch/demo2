using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;

namespace shortestPathAlgor.ViewModels.MatrixUIs
{
    class ViewModel_NbyN:_ViewModel_Base
    {
        #region "Properties"
        private int propertyNumberOfRows = 0;
        public int PropertyNumberOfRows
        {
            set { SetProperty(ref propertyNumberOfRows, value); }
            get { return propertyNumberOfRows; }
        }

        private int propertyNumberOfColumns = 0;
        public int PropertyNumberOfColumns
        {
            set { SetProperty(ref propertyNumberOfColumns, value); }
            get { return propertyNumberOfColumns; }
        }

        private int propertyMaximumWeightForPathAllowed = 0;
        public int PropertyMaximumWeightForPathAllowed
        {
            set { SetProperty(ref propertyMaximumWeightForPathAllowed, value); }
            get { return propertyMaximumWeightForPathAllowed; }
        }

        private String propertyMatrixValues = String.Empty;
        public String PropertyMatrixValues
        {
            set { SetProperty(ref propertyMatrixValues, value); }
            get { return propertyMatrixValues; }
        }

        private string minPathValue = String.Empty;
        public string MinPathValue
        {
            set { SetProperty(ref minPathValue, value); }
            get { return minPathValue; }
        }

        private string nodesOnpath = String.Empty;
        public string NodesOnpath
        {
            set { SetProperty(ref nodesOnpath, value); }
            get { return nodesOnpath; }
        }

        private string travelledFromOneEndofMatrixToNext = String.Empty;
        public string TravelledFromOneEndofMatrixToNext
        {
            set { SetProperty(ref travelledFromOneEndofMatrixToNext, value); }
            get { return travelledFromOneEndofMatrixToNext; }
        }
        #endregion



        private ICommand backCommand;
        public ICommand BackCommand
        {
            get
            {
                return backCommand ?? (backCommand = new Command(() => App.Current.MainPage = new Views.MainMenu.Page_MainMenu()));

            }
        }

        private ICommand calculate4by4Command;
        public ICommand Calculate4by4Command
        {
            get
            {
                return calculate4by4Command ?? (calculate4by4Command = new Command(() =>
                {
                    String inputStream = PropertyMatrixValues;
                    int[,] sourceMatrix = new int[PropertyNumberOfRows, PropertyNumberOfColumns];
                    String[] rowSplit = inputStream.Split(',');

                    for (int i = 0; i < PropertyNumberOfRows; i++)
                    {
                        String[] tempStorage = rowSplit[i].Split(' ');

                        for (int j = 0; j < PropertyNumberOfColumns; j++)
                        {
                            sourceMatrix[i, j] = Int32.Parse(tempStorage[j].ToString());
                        }
                    }
                    //int[,]sourceMatrix = new int[4, 4] { { 3, 4, 1 }, { 6, 1, 8 }, { 5, 9, 3 } };
                    Models.ResultFromrun r1 = Helpers.shortestPathHelperFunctions.Main(PropertyNumberOfRows, PropertyNumberOfColumns, sourceMatrix, PropertyMaximumWeightForPathAllowed);
                    MinPathValue = "Minimum path value: " + r1.minpathValue;
                    NodesOnpath = "Nodes on path: " + r1.nodesOnpath;
                    TravelledFromOneEndofMatrixToNext = "Was Matrix colmpleted traversed: " + r1.TravelledFromOneEndofMatrixToNext;
                }));

            }
        }


        public ViewModel_NbyN()
        {

        }
    }
}
