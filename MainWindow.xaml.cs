using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using CssSimpleWpfApplication.Controls;
using CssSimpleWpfApplication.Converters;
using CssSimpleWpfApplication.Dialogs;
using CssSimpleWpfApplication.Model;

namespace CssSimpleAplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rand = new();

        private CssClassesToolControl? _toolcontent = new CssClassesToolControl(780, 780);

        #region ctor
        public MainWindow()
        {
            InitializeComponent();


            DataContext = this;


            Top.Children.Add(_toolcontent);
            Closing +=MainWindow_Closing;
        }

        #endregion

        public string LastStyleChosen = string.Empty;

        public void FillLastStyleChosen()
        {
            if (_toolcontent != null)
            {
                _toolcontent.FillLastChosen();
                LastStyleChosen = _toolcontent.LastChosen;
            }
        }

       
        void MainWindow_Closing(object? sender, CancelEventArgs e)
        {
          //  _toolcontent = null;
            e.Cancel = false;


            foreach(Window ww in _registeredwindows)
            {
                try
                {
                    ww.Close();

                }
                catch(Exception ee)
                {
                    string ggr = ee.Message;

                    continue;
                }
            }

            //if (RealClose == false)
            //{
            //    e.Cancel = true;
            //    this.Visibility = Visibility.Collapsed;
            //}
            //else
            //{

            //}

        }

        private static List<Window> _registeredwindows = new List<Window>();

        public static void RegisterWindows(Window ww)
        {
            _registeredwindows.Add(ww);
        }

        // define an event handler
        public event PropertyChangedEventHandler PropertyChanged;

        #region properties

        // sqlite dc Context property



        //public static CssModel Context
        //{
        //    get
        //    {
        //        if (_context == null)
        //        {
        //            try
        //            {
        //                _context = new CssModel();
        //                _context.Database.EnsureCreated();

        //            }
        //            catch (Exception e)
        //            {
        //                System.Windows.MessageBox.Show(e.Message, "No DataBase Found", MessageBoxButton.OK);

        //                throw;
        //            }
        //        }
        //        return _context;
        //    }
        //}


        #endregion

    }
}
