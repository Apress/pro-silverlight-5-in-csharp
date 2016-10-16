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
using System.ServiceModel;
using System.Windows.Browser;
using DataControls.DataService;
using StoreDbDataClasses;

namespace DataControls
{
    public partial class PivotViewerTest : UserControl
    {
        public PivotViewerTest()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {           
            EndpointAddress address = new EndpointAddress(
                "http://localhost:" +
               HtmlPage.Document.DocumentUri.Port + "/DataControls.Web/StoreDb.svc");
            StoreDbClient client = new StoreDbClient();
            client.Endpoint.Address = address;

            client.GetProductsCompleted += client_GetProductsCompleted;
            client.GetProductsAsync();            
        }

        private void client_GetProductsCompleted(object sender, GetProductsCompletedEventArgs e)
        {
            try
            {
                pivotViewer.ItemsSource = e.Result;
            }
            catch (Exception err)
            {
                MessageBox.Show("Failed to contact service.");
            }
        }

        private void pivotViewer_ItemDoubleClick(object sender, System.Windows.Controls.Pivot.PivotViewerItemDoubleClickEventArgs e)
        {
            Product product = ((Product)e.Item);
            MessageBox.Show("You clicked " + product.ModelName + ".");
        }
        
    }
}
