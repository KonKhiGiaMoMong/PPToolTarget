using PPTargetTools.DataObject;
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

namespace PPTargetTools.Controls
{
    /// <summary>
    /// Interaction logic for ExpanderControl.xaml
    /// </summary>
    public partial class ExpanderControl : UserControl
    {
        public ExpanderControl()
        {
            InitializeComponent();
        }

        

        public ExpanderControl(string str, StyleObject[] arrStyles)
        {
            InitializeComponent();
            //this.Margin = new Thickness(5, 0, 0, 0);
            expanderControl.Header = str;
            lbStyles.Items.Clear();
            foreach (StyleObject item in arrStyles)
            {
                //Label lb = new Label();
                //lb.BorderThickness = new Thickness(8, 0, 0, 0);
                //Hyperlink hpl = new Hyperlink();
                //hpl.TextDecorations = null;
                //hpl.Name = str + item.ToString();
                //hpl.Tag = item;
                ////hpl.TargetName = item.value;
                //hpl.Inlines.Add(item.ToString());
                //hpl.Click += hpl_Click;
                //lb.Content = hpl;
                //lbStyles.Items.Add(lb);
                EditStyleControl editControl = new EditStyleControl(item);
                lbStyles.Items.Add(editControl);
            }
        }

        void hpl_Click(object sender, RoutedEventArgs e)
        {
            Hyperlink hpl = sender as Hyperlink;
            MessageBox.Show(hpl.Tag.ToString());
        }

        public event RoutedEventHandler HyperLinkClick;

        void ClickHandler(object sender, RoutedEventHandler e) { 
            
        }
    }
}
