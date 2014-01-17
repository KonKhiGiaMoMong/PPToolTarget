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
    /// Interaction logic for EditStyleControl.xaml
    /// </summary>
    public partial class EditStyleControl : UserControl
    {
        public EditStyleControl(StyleObject objStyle)
        {
            InitializeComponent();

            hpl.Tag = objStyle;
            hpl.Inlines.Add(objStyle.ToString());

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (btnEdit.Content.ToString().Trim().Equals("Edit"))
            {
                txtValue.Visibility = Visibility.Visible;
                btnEdit.Content = "Save";
                btnCancel.Visibility = Visibility.Visible;
            }
            else if (btnEdit.Content.ToString().Trim().Equals("Save"))
            {
                txtValue.Visibility = Visibility.Collapsed;
                
                btnEdit.Content = "Edit";
                btnEdit.Visibility = Visibility.Collapsed;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            txtValue.Visibility = Visibility.Collapsed;
            btnCancel.Visibility = Visibility.Collapsed;
            btnEdit.Content = "Edit";
        }
    }
}
