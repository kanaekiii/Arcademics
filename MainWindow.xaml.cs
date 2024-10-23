using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using System;
using Windows.UI.ViewManagement;

namespace Arcademics
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            // Start the app in full-screen mode
            this.ExtendsContentIntoTitleBar = true;
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.FullScreen;

            // Handle NavigationView item selection
            MyNavigationView.SelectionChanged += NavigationView_SelectionChanged;
        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.SelectedItem is NavigationViewItem selectedItem)
            {
                string tag = selectedItem.Tag.ToString();

                // Navigate based on the tag
                switch (tag)
                {
                    case "Addition":
                        ContentFrame.Navigate(typeof(GamePage), "https://www.arcademics.com/games/alien");
                        break;
                    case "Subtraction":
                        ContentFrame.Navigate(typeof(GamePage), "https://www.arcademics.com/games/mission");
                        break;
                    case "Multiplication":
                        ContentFrame.Navigate(typeof(GamePage), "https://www.arcademics.com/games/grand-prix");
                        break;
                    case "Division":
                        ContentFrame.Navigate(typeof(GamePage), "https://www.arcademics.com/games/drag-race");
                        break;
                }
            }
        }

        private void Grid_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            // Block the Escape key
            if (e.Key == Windows.System.VirtualKey.Escape)
            {
                e.Handled = true;
            }
        }
    }
}
