using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Xilium.CefGlue.WindowsForms;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CefWebBrowser browser = null;
        public MainWindow()
        {
            InitializeComponent();

            IntializeChromeBrowser();
        }

        private void IntializeChromeBrowser()
        {

            System.Windows.Forms.Integration.WindowsFormsHost host = new System.Windows.Forms.Integration.WindowsFormsHost();

            browser = new CefWebBrowser();
            browser.Dock = System.Windows.Forms.DockStyle.Fill;
            host.Child = browser;            

            browser.StartUrl = "http://www.google.com";

            Grid1.Children.Add(host);
        }
    }
}
