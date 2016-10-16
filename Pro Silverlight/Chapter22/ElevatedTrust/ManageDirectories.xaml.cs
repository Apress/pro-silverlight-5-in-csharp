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
using System.IO;

namespace ElevatedTrust
{
    public partial class ManageDirectories : UserControl
    {
        public ManageDirectories()
        {
            InitializeComponent();
        }

        private void cmdCreate_Click(object sender, RoutedEventArgs e)
        {
            // (Of course, a real-world version of this method needs error handling to catch directories that can't be created.)

            string dir = txtDir.Text;

            Directory.CreateDirectory(dir);
            string file = txtFile.Text;

            // Use the System.IO.Path class to safely combine file paths, without worrying about
            // extra backslashes. You must fully qualify the path name to avoid referring to 
            // System.Windows.Shapes.Path.            
            string filePath = System.IO.Path.Combine(dir, file);
            File.WriteAllText(filePath, "This is a test file in a new directory!");

            MessageBox.Show("Successfully created.");
        }

        private void cmdDelete_Click(object sender, RoutedEventArgs e)
        {
            // (Of course, a real-world version of this method needs error handling to catch directories that can't be deleted.)

            string dir = txtDir.Text;
            if (!Directory.Exists(dir))
            {
                MessageBox.Show("There is no such directory.");
            }
            else
            {
                Directory.Delete(dir, true);
                MessageBox.Show("Successfully deleted.");
            }            
        }
    }
}
