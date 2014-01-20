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
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;
using WpfToolsTarget;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
				

namespace PPTargetTools.Pages
{
    /// <summary>
    /// Interaction logic for ConfigDesktop.xaml
    /// </summary>
    /// 

    public partial class ConfigDesktop : Window
    {
        public string filepath;
        public string nametarget;

        public ConfigDesktop(string file)
        {
            InitializeComponent();
            loadData(file);
        }
        public void loadData(string file)
        {
            try
            {
                XDocument doc = XDocument.Load(file);
                foreach (var dm in doc.Descendants("General"))
                {
                    txtTitle.Text = dm.Element("Title").Value;
                    txtSplashScreen.Text = dm.Element("SplashScreen").Value;
                    txtAppIcon.Text = dm.Element("AppIcon").Value;
                    txtDefault.Text = dm.Element("DefaultPageShowOneColumn").Value;
                }
                foreach (var dm in doc.Descendants("Home"))
                {
                    txtTitleCoverFontColor.Text = dm.Element("TitleCoverFontColor").Value;
                    txtLogoIcon.Text = dm.Element("LogoIcon").Value;
                    txtLogoWidth.Text = dm.Element("LogoWidth").Value;
                    txtLogoHeight.Text = dm.Element("LogoHeight").Value;
                }
                foreach (var dm in doc.Descendants("CustomSocialSetup"))
                {
                    txtSHKMyAppName.Text = dm.Element("SHKMyAppName").Value;
                    txtSHKMyAppURL.Text = dm.Element("SHKMyAppURL").Value;
                    txtSHKTwitterConsumerKey.Text = dm.Element("SHKTwitterConsumerKey").Value;
                    txtSHKTwitterSecret.Text = dm.Element("SHKTwitterSecret").Value;
                    txtSHKTwitterCallbackUrl.Text = dm.Element("SHKTwitterCallbackUrl").Value;
                    txtSHKFacebookSecret.Text = dm.Element("SHKFacebookSecret").Value;
                    txtFacebookExtendedPermission.Text = dm.Element("FacebookExtendedPermission").Value;
                    txtFacebookPictureApp.Text = dm.Element("FacebookPictureApp").Value;
                    txtFacebookRedirectURI.Text = dm.Element("FacebookRedirectURI").Value;
                    txtFacebookType.Text = dm.Element("FacebookType").Value;
                    txtFacebookDisplay.Text = dm.Element("FacebookDisplay").Value;
                    txtFacebookAppName.Text = dm.Element("FacebookAppName").Value;
                    txtFacebookAppURL.Text = dm.Element("FacebookAppURL").Value;
                }
            }
            catch (Exception)
            {
                
                throw;
            }
           
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            
            // Set filter for file extension and default file extension
            dlg.Filter = "PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|All|*.*";

            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                txtSplashScreen.Text = filename;
                
               
                BitmapImage logo = new BitmapImage();
                logo.BeginInit();
                logo.UriSource = new Uri(filename);
                logo.EndInit(); // Getting exception here
                imgSplashScreen.Source = logo;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension
            dlg.Filter = "PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|All|*.*";

            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                txtAppIcon.Text = filename;
                BitmapImage logo = new BitmapImage();
                logo.BeginInit();
                logo.UriSource = new Uri(filename);
                logo.EndInit(); // Getting exception here
                imgAppIcon.Source = logo;
               
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension
            dlg.Filter = "PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|All|*.*";

            // Display OpenFileDialog by calling ShowDialog method
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox
            if (result == true)
            {
                // Open document
                string filename = dlg.FileName;
                txtLogoIcon.Text = filename;
                BitmapImage logo = new BitmapImage();
                logo.BeginInit();
                logo.UriSource = new Uri(filename);
                logo.EndInit(); // Getting exception here
                imgLogoIcon.Source = logo;
               
            }
        }
        public void SaveData(string file)
        {
            XDocument doc = XDocument.Load(file);

            foreach (var dm in doc.Descendants("General"))
            {
                dm.Element("Title").Value = txtTitle.Text;
                dm.Element("SplashScreen").Value = txtSplashScreen.Text;
                dm.Element("AppIcon").Value = txtAppIcon.Text;
                dm.Element("DefaultPageShowOneColumn").Value = txtDefault.Text;
            }
            foreach (var dm in doc.Descendants("Home"))
            {
                dm.Element("TitleCoverFontColor").Value = txtTitleCoverFontColor.Text;
                dm.Element("LogoIcon").Value = txtLogoIcon.Text;
                dm.Element("LogoWidth").Value = txtLogoWidth.Text;
                dm.Element("LogoHeight").Value = txtLogoHeight.Text;
            }
            foreach (var dm in doc.Descendants("CustomSocialSetup"))
            {
                dm.Element("SHKMyAppName").Value = txtSHKMyAppName.Text;
                dm.Element("SHKMyAppURL").Value = txtSHKMyAppURL.Text;
                dm.Element("SHKTwitterConsumerKey").Value = txtSHKTwitterConsumerKey.Text;
                dm.Element("SHKTwitterSecret").Value = txtSHKTwitterSecret.Text;
                dm.Element("SHKTwitterCallbackUrl").Value = txtSHKTwitterCallbackUrl.Text;
                dm.Element("SHKFacebookSecret").Value = txtSHKFacebookSecret.Text;
                dm.Element("FacebookExtendedPermission").Value = txtFacebookExtendedPermission.Text;
                dm.Element("FacebookPictureApp").Value = txtFacebookPictureApp.Text;
                dm.Element("FacebookRedirectURI").Value = txtFacebookRedirectURI.Text;
                dm.Element("FacebookType").Value = txtFacebookType.Text;
                dm.Element("FacebookDisplay").Value = txtFacebookDisplay.Text;
                dm.Element("FacebookAppName").Value = txtFacebookAppName.Text;
                dm.Element("FacebookAppURL").Value = txtFacebookAppURL.Text;
            }
            doc.Save(file);
            System.Windows.MessageBox.Show("Save config file successfully.", "Save Config", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            SaveData(filepath);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            loadData(filepath);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    public class ConvertColor : IValueConverter
    {
       
        public object Convert(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            try
            {
                if (value != null && !string.IsNullOrEmpty(value.ToString()))
                {
                    SolidColorBrush mySolidColorBrush = new SolidColorBrush();
                    mySolidColorBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom(value));
                    return mySolidColorBrush;
                }
            }
            catch (Exception ex) { }
            return null;

        }

        public object ConvertBack(object value, Type targetType,
            object parameter, CultureInfo culture)
        {
            return null;
        }
    }
 
}


           