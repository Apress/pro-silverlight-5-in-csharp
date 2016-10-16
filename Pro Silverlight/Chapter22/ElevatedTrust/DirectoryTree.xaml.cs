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
    public partial class DirectoryTree : UserControl
    {
        public DirectoryTree()
        {
            InitializeComponent();
            
            DirectoryInfo rootDir = new DirectoryInfo(@"c:\");
            AddItem(rootDir, treeFileSystem.Items);            
        }
        
        private void AddItem(DirectoryInfo dir, ItemCollection collection)
        {
            TreeViewItem item = new TreeViewItem();
            item.Tag = dir;
            item.Header = dir.Name;

            // This placeholder string is never shown,
            // because the node begins in collapsed state.
            item.Items.Add("*");
            item.Expanded += item_Expanded;
            item.Selected += item_Selected;
            
            collection.Add(item);
        }
               
        private void item_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)sender;

            // Perform a refresh every time item is expanded.
            // Optionally, you could perform this only the first
            // time, when the placeholder is found (less refreshes),
            // or every time an item is selected (more refreshes).
            item.Items.Clear();
            
            DirectoryInfo dir = (DirectoryInfo)item.Tag;
            
            try
            {
                foreach (DirectoryInfo subDir in dir.EnumerateDirectories())
                {
                    AddItem(subDir, item.Items);
                }
            }
            catch
            {
                // An exception could be thrown in this code if you don't
                // have sufficient security permissions for a file or directory.
                // You can catch and then ignore this exception.
            }
        }

        private void item_Selected(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)sender;
            DirectoryInfo dir = (DirectoryInfo)item.Tag;

            try
            {
                // Convert this directly to an array to get an exception to be thrown immediately,
                // if there is an access problem.
                lstFiles.ItemsSource = dir.EnumerateFiles().ToArray();
            }
            catch
            {
                // An exception could be thrown in this code if you don't
                // have sufficient security permissions for a file or directory.
                // You can catch and then ignore this exception.
            }
        }     
    }
}
