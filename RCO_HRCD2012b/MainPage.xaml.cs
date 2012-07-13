using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Controls.Map;

namespace RCO_HRCD2012b
{
    public partial class MainPage : UserControl
    {
        //from example sets data context
        //private ShapefileViewModel Model
        //{
        //    get
        //    {
        //        return this.Resources["DataContext"] as ShapefileViewModel;
        //    }
        //}


        public MainPage()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(MainPage_Loaded);

           

        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            myReader.Source = new Uri("DataSources/Geospatial/WRIA2012_WGS84s25.shp", UriKind.Relative);
            myReader.DataSource = new Uri("DataSources/Geospatial/WRIA2012_WGS84s25.dbf", UriKind.Relative);
            myReader.ReadCompleted += new ReadShapesCompletedEventHandler(myReader_ReadCompleted);

            wriaReader.Source = new Uri("DataSources/Geospatial/EightSOS2012_WGS84s10.shp", UriKind.Relative);
            wriaReader.DataSource = new Uri("DataSources/Geospatial/EightSOS2012_WGS84s10.dbf", UriKind.Relative);
           // myReader.ReadCompleted += new ReadShapesCompletedEventHandler(myReader_ReadCompleted);




        }

        void myReader_ReadCompleted(object sender, ReadShapesCompletedEventArgs eventArgs)
        {
            
        }




        private void MapShapeReader_PreviewReadCompleted(object sender, PreviewReadShapesCompletedEventArgs eventArgs)
        {
            //if (eventArgs.Error == null)
            //{
            //    LocationRect bestView = this.InformationLayer.GetBestView(eventArgs.Items);
            //    this.radMap1.SetView(bestView);
            //}
        }

    }
}
