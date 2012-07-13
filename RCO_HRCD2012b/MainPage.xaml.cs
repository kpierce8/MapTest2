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
            waView.Visibility = Visibility.Visible;
            wria15.Visibility = Visibility.Collapsed;
           

        }

        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            myReader.Source = new Uri("DataSources/Geospatial/WRIA2012_WGS84s25.shp", UriKind.Relative);
            myReader.DataSource = new Uri("DataSources/Geospatial/WRIA2012_WGS84s25.dbf", UriKind.Relative);
            myReader.ReadCompleted += new ReadShapesCompletedEventHandler(myReader_ReadCompleted);

            wriaReader.Source = new Uri("DataSources/Geospatial/EightSOS2012_WGS84s10.shp", UriKind.Relative);
            wriaReader.DataSource = new Uri("DataSources/Geospatial/EightSOS2012_WGS84s10.dbf", UriKind.Relative);
           // myReader.ReadCompleted += new ReadShapesCompletedEventHandler(myReader_ReadCompleted);
            wriaReader.PreviewReadCompleted += new PreviewReadShapesCompletedEventHandler(wriaReader_PreviewReadCompleted);


            myWria15Reader.Source = new Uri("DataSources/Geospatial/WRIA15/wria15_outline_W84.shp", UriKind.Relative);
            myWria15Reader.DataSource = new Uri("DataSources/Geospatial/WRIA15/wria15_outline_W84.dbf", UriKind.Relative);
            myWria15Reader.ReadCompleted += new ReadShapesCompletedEventHandler(myReader_ReadCompleted);

            changesReader.Source = new Uri("DataSources/Geospatial/WRIA15/wria15_09changes_W84.shp", UriKind.Relative);
            changesReader.DataSource = new Uri("DataSources/Geospatial/WRIA15/wria15_09changes_W84.dbf", UriKind.Relative);
            // myReader.ReadCompleted += new ReadShapesCompletedEventHandler(myReader_ReadCompleted);
            changesReader.PreviewReadCompleted += new PreviewReadShapesCompletedEventHandler(changesReader_PreviewReadCompleted);

        }

        void changesReader_PreviewReadCompleted(object sender, PreviewReadShapesCompletedEventArgs eventArgs)
        {
            foreach (var poly in eventArgs.Items)
            {
                if (poly is MapShape)
                {
                    (poly as MapShape).MouseLeftButtonDown += new MouseButtonEventHandler(wrias_MouseLeftButtonDown);
                    (poly as MapShape).MouseEnter +=new MouseEventHandler(changes_MouseEnter);
                    (poly as MapShape).MouseLeave += new MouseEventHandler(changes_MouseLeave);
                }
            }
        }

        void changes_MouseLeave(object sender, MouseEventArgs e)
        {
            titleBlock.Text = "";
            acreage.Text = "";
        }

        void changes_MouseEnter(object sender, MouseEventArgs e)
        {
            titleBlock.Text = (sender as MapShape).ExtendedData.GetValue("PolyID").ToString();
            acreage.Text = (sender as MapShape).ExtendedData.GetValue("Acres").ToString();
        }






        void wriaReader_PreviewReadCompleted(object sender, PreviewReadShapesCompletedEventArgs eventArgs)
        {
            foreach (var poly in eventArgs.Items) 
            {
                if (poly is MapShape) 
                {
                    (poly as MapShape).MouseLeftButtonDown += new MouseButtonEventHandler(wrias_MouseLeftButtonDown);
                    (poly as MapShape).MouseEnter += new MouseEventHandler(wrias_MouseEnter);
                    (poly as MapShape).MouseLeave += new MouseEventHandler(wrias_MouseLeave);
                }
            }
        }

        void wrias_MouseEnter(object sender, MouseEventArgs e)
        {
            wriaNameBlock.Text = (sender as MapShape).ExtendedData.GetValue("WRIA_NM").ToString();
        }

        void wrias_MouseLeave(object sender, MouseEventArgs e)
        {
            wriaNameBlock.Text = "";
        }



        void wrias_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            


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

        private void goWria_Click(object sender, RoutedEventArgs e)
        {
            waView.Visibility = Visibility.Collapsed;
            wria15.Visibility = Visibility.Visible;
        }

        private void goWA_Click(object sender, RoutedEventArgs e)
        {
            waView.Visibility = Visibility.Visible;
            wria15.Visibility = Visibility.Collapsed;
        }


        
    }
}
