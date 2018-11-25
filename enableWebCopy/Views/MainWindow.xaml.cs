using System;
using System.Windows;
using System.Windows.Controls;
using enableWebCopy.ViewModels;
using System.Diagnostics;

namespace enableWebCopy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Log outputLogs = new Log();
        private WebDownloader webToPatch = new WebDownloader();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = outputLogs;
        }

        private void startPatching(object sender, RoutedEventArgs e)
        {
            string PageSource = string.Empty;
            PageSource = webToPatch.getWebPageSource();
            WebPatching PatchWeb = new WebPatching(patchingType.ReplaceAllMatches, Properties.Resources.PatchDefinitions, outputLogs, "FullLog");
            PageSource = PatchWeb.PatchByReplaceAllMatches(PageSource, outputLogs, "FullLog");
            SaveToFolder.SaveFileToFolder(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), webToPatch.GetName(), PageSource, outputLogs, "FullLog");
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\" + webToPatch.GetName());
        }

        private void urlBoxChanged(object sender, TextChangedEventArgs e)
        {
            webToPatch.SetURL(urlBox.Text);
        }
    }
}
