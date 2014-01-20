using PPTargetTools.Controls;
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
using System.Windows.Shapes;
using System.Xml.Linq;

namespace PPTargetTools.Pages
{
    /// <summary>
    /// Interaction logic for ConfigModernUI.xaml
    /// </summary>
    public partial class ConfigModernUI : Window
    {
        private string _pathFile;
        private XDocument doc;
        private BrushConverter bc = new BrushConverter();
        private string color = "";
        private bool changed = false;

        public ConfigModernUI()
        {
            InitializeComponent();
        }

        public ConfigModernUI(string path, string target)
        {
            InitializeComponent();

            lblTarget.Content = (target + " (config)").ToUpper();
            _pathFile = path;

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure ?", "Save", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                Save();
                HideImages();
                LoadData();
                changed = false;
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SetDefault()
        {
            tblButtonCancelBackground.Background = Brushes.White;
            tblButtonCancelForeground.Background = Brushes.White;

            tblButtonCancelLoginBackground.Background = Brushes.White;
            tblButtonCancelLoginForeground.Background = Brushes.White;

            tblButtonDeleteBackground.Background = Brushes.White;
            tblButtonDeleteForeground.Background = Brushes.White;

            tblButtonDownloadBackground.Background = Brushes.White;
            tblButtonDownloadForeground.Background = Brushes.White;

            tblButtonLoginBackground.Background = Brushes.White;
            tblButtonLoginForeground.Background = Brushes.White;

            tblButtonReadBackground.Background = Brushes.White;
            tblButtonReadForeground.Background = Brushes.White;

            tblButtonRefreshBackground.Background = Brushes.White;
            tblButtonRefreshForeground.Background = Brushes.White;

            tblButtonUpdateBackground.Background = Brushes.White;
            tblButtonUpdateForeground.Background = Brushes.White;

            tblTitleCoverBackground.Background = Brushes.White;
            tblTitleCoverForeground.Background = Brushes.White;

            tblTitleLoginForeground.Background = Brushes.White;

            txtButtonCancelBackground.Text = String.Empty;
            txtButtonCancelForeground.Text = String.Empty;

            txtButtonCancelLoginBackground.Text = String.Empty;
            txtButtonCancelLoginForeground.Text = String.Empty;

            txtButtonDeleteBackground.Text = String.Empty;
            txtButtonDeleteForeground.Text = String.Empty;

            txtButtonDownloadBackground.Text = String.Empty;
            txtButtonDownloadForeground.Text = String.Empty;

            txtButtonLoginBackground.Text = String.Empty;
            txtButtonLoginForeground.Text = String.Empty;

            txtButtonReadBackground.Text = String.Empty;
            txtButtonReadForeground.Text = String.Empty;

            txtButtonRefreshBackground.Text = String.Empty;
            txtButtonRefreshForeground.Text = String.Empty;

            txtButtonUpdateBackground.Text = String.Empty;
            txtButtonUpdateForeground.Text = String.Empty;

            txtCustomMyAppName.Text = String.Empty;
            txtCustomMyAppURL.Text = String.Empty;
            txtCustomSHKFacebookKey.Text = String.Empty;
            txtCustomSHKFacebookSecret.Text = String.Empty;
            txtCustomSHKTwiterCallbackURL.Text = String.Empty;
            txtCustomSHKTwiterKey.Text = String.Empty;
            txtCustomSHKTwiterSecret.Text = String.Empty;
            txtTitleCoverBackground.Text = String.Empty;
            txtTitleCoverForeColor.Text = String.Empty;
            txtTitleLoginForeground.Text = String.Empty;
        }

        private void LoadData()
        {
            try
            {
                doc = XDocument.Load(_pathFile);

                #region "Title"
                // Load TitleCover
                foreach (var dm in doc.Descendants("TitleCover"))
                {
                    txtTitleCoverBackground.Text = dm.Element("BackgroundColor").Value;
                    color = "";
                    color = dm.Element("BackgroundColor").Value;
                    try
                    {
                        tblTitleCoverBackground.Background = (Brush)bc.ConvertFrom(color);
                    }
                    catch (Exception)
                    {
                    }

                    txtTitleCoverForeColor.Text = dm.Element("Foreground").Value;
                    color = "";
                    color = dm.Element("Foreground").Value;
                    try
                    {
                        tblTitleCoverForeground.Background = (Brush)bc.ConvertFrom(color);
                    }
                    catch (Exception)
                    {
                    }
                }
                // Load TitleLogin
                foreach (var dm in doc.Descendants("TitleLogin"))
                {
                    //txtTitleCoverFontSize.Text = dm.Element("FontSize").Value;
                    //txtTitleCoverFontStyle.Text = dm.Element("FontStyle").Value;
                    txtTitleLoginForeground.Text = dm.Element("Foreground").Value;
                    color = "";
                    color = dm.Element("Foreground").Value;
                    try
                    {
                        tblTitleLoginForeground.Background = (Brush)bc.ConvertFrom(color);
                    }
                    catch (Exception)
                    {
                    }
                }
                #endregion

                #region "Custom Facebook, Twiter"
                //Facebook and Twiter 
                foreach (var dm in doc.Descendants("CustomSocialSetup"))
                {
                    //Twiter
                    txtCustomSHKTwiterKey.Text = dm.Element("SHKTwitterConsumerKey").Value;
                    txtCustomSHKTwiterSecret.Text = dm.Element("SHKTwitterSecret").Value;
                    txtCustomSHKTwiterCallbackURL.Text = dm.Element("SHKTwitterCallbackUrl").Value;
                    //Facebook
                    txtCustomSHKFacebookKey.Text = dm.Element("SHKFacebookKey").Value;
                    txtCustomSHKFacebookSecret.Text = dm.Element("SHKFacebookSecret").Value;
                    // App
                    txtCustomMyAppName.Text = dm.Element("SHKMyAppName").Value;
                    txtCustomMyAppURL.Text = dm.Element("SHKMyAppURL").Value;
                }
                #endregion

                #region "Buttons"
                //1. ButtonRefresh
                foreach (var dm in doc.Descendants("ButtonRefresh"))
                {
                    txtButtonRefreshBackground.Text = dm.Element("BackgroundColor").Value;
                    color = "";
                    color = dm.Element("BackgroundColor").Value;
                    try
                    {
                        tblButtonRefreshBackground.Background = (Brush)bc.ConvertFrom(color);
                    }
                    catch (Exception)
                    {
                    }
                    txtButtonRefreshForeground.Text = dm.Element("Foreground").Value; color = "";
                    color = dm.Element("Foreground").Value;
                    try
                    {
                        tblButtonRefreshForeground.Background = (Brush)bc.ConvertFrom(color);
                    }
                    catch (Exception)
                    {
                    }
                }
                //2. ButtonReadIssue
                foreach (var dm in doc.Descendants("ButtonReadIssue"))
                {
                    txtButtonReadBackground.Text = dm.Element("BackgroundColor").Value;
                    color = "";
                    color = dm.Element("BackgroundColor").Value;
                    try
                    {
                        tblButtonReadBackground.Background = (Brush)bc.ConvertFrom(color);
                    }
                    catch (Exception)
                    {
                    }
                    txtButtonReadForeground.Text = dm.Element("Foreground").Value; color = "";
                    color = dm.Element("Foreground").Value;
                    try
                    {
                        tblButtonReadForeground.Background = (Brush)bc.ConvertFrom(color);
                    }
                    catch (Exception)
                    {
                    }
                }
                //3. ButtonDeleteIssue
                foreach (var dm in doc.Descendants("ButtonDeleteIssue"))
                {
                    txtButtonDeleteBackground.Text = dm.Element("BackgroundColor").Value;
                    color = "";
                    color = dm.Element("BackgroundColor").Value;
                    try
                    {
                        tblButtonDeleteBackground.Background = (Brush)bc.ConvertFrom(color);
                    }
                    catch (Exception)
                    {
                    }
                    txtButtonDeleteForeground.Text = dm.Element("Foreground").Value; color = "";
                    color = dm.Element("Foreground").Value;
                    try
                    {
                        tblButtonDeleteForeground.Background = (Brush)bc.ConvertFrom(color);
                    }
                    catch (Exception)
                    {
                    }
                }
                //4. ButtonFreeDownloadIssue
                foreach (var dm in doc.Descendants("ButtonFreeDownloadIssue"))
                {
                    txtButtonDownloadBackground.Text = dm.Element("BackgroundColor").Value;
                    color = "";
                    color = dm.Element("BackgroundColor").Value;
                    try
                    {
                        tblButtonDownloadBackground.Background = (Brush)bc.ConvertFrom(color);
                    }
                    catch (Exception)
                    {
                    }
                    txtButtonDownloadForeground.Text = dm.Element("Foreground").Value; color = "";
                    color = dm.Element("Foreground").Value;
                    try
                    {
                        tblButtonDownloadForeground.Background = (Brush)bc.ConvertFrom(color);
                    }
                    catch (Exception)
                    {
                    }
                }
                //5. ButtonCancelDownloadIssue
                foreach (var dm in doc.Descendants("ButtonCancelDownloadIssue"))
                {
                    txtButtonCancelBackground.Text = dm.Element("BackgroundColor").Value;
                    color = "";
                    color = dm.Element("BackgroundColor").Value;
                    try
                    {
                        tblButtonCancelBackground.Background = (Brush)bc.ConvertFrom(color);
                    }
                    catch (Exception)
                    {
                    }
                    txtButtonCancelForeground.Text = dm.Element("Foreground").Value; color = "";
                    color = dm.Element("Foreground").Value;
                    try
                    {
                        tblButtonCancelForeground.Background = (Brush)bc.ConvertFrom(color);
                    }
                    catch (Exception)
                    {
                    }
                }
                //6. ButtonFreeUpdateIssue
                foreach (var dm in doc.Descendants("ButtonFreeUpdateIssue"))
                {
                    txtButtonUpdateBackground.Text = dm.Element("BackgroundColor").Value;
                    color = "";
                    color = dm.Element("BackgroundColor").Value;
                    try
                    {
                        tblButtonUpdateBackground.Background = (Brush)bc.ConvertFrom(color);
                    }
                    catch (Exception)
                    {
                    }
                    txtButtonUpdateForeground.Text = dm.Element("Foreground").Value; color = "";
                    color = dm.Element("Foreground").Value;
                    try
                    {
                        tblButtonUpdateForeground.Background = (Brush)bc.ConvertFrom(color);
                    }
                    catch (Exception)
                    {
                    }
                }
                //7. ButtonLogin
                foreach (var dm in doc.Descendants("ButtonLogin"))
                {
                    txtButtonLoginBackground.Text = dm.Element("BackgroundColor").Value;
                    color = "";
                    color = dm.Element("BackgroundColor").Value;
                    try
                    {
                        tblButtonLoginBackground.Background = (Brush)bc.ConvertFrom(color);
                    }
                    catch (Exception)
                    {
                    }
                    txtButtonLoginForeground.Text = dm.Element("Foreground").Value; color = "";
                    color = dm.Element("Foreground").Value;
                    try
                    {
                        tblButtonLoginForeground.Background = (Brush)bc.ConvertFrom(color);
                    }
                    catch (Exception)
                    {
                    }
                }
                //8. ButtonCancelLogin
                foreach (var dm in doc.Descendants("ButtonCancelLogin"))
                {
                    txtButtonCancelLoginBackground.Text = dm.Element("BackgroundColor").Value;
                    color = "";
                    color = dm.Element("BackgroundColor").Value;
                    tblButtonCancelLoginBackground.Background = (Brush)bc.ConvertFrom(color);

                    txtButtonCancelLoginForeground.Text = dm.Element("Foreground").Value;
                    color = "";
                    color = dm.Element("Foreground").Value;
                    tblButtonCancelLoginForeground.Background = (Brush)bc.ConvertFrom(color);

                }

                #endregion
            }
            catch (Exception)
            {
                MessageBox.Show("Load file is uncompleted.", "Load", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Save()
        {
            SaveStyleColor();
            SaveAndValidate_CustomSocial();
            btnClose.IsEnabled = true;
        }

        private void Refresh()
        {
            try
            {
                if (changed)
                {
                    if (MessageBox.Show("Are you sure?", "Refresh", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                    {
                        return;
                    }
                }
                SetDefault();
                LoadData();
                btnClose.IsEnabled = true;
                changed = false;
                HideImages();
            }
            catch (Exception)
            {
            }
        }

        private void SaveAndValidate_CustomSocial()
        {
            doc = XDocument.Load(_pathFile);
            foreach (var dm in doc.Descendants("CustomSocialSetup"))
            {
                // Twiter 
                dm.Element("SHKTwitterConsumerKey").SetValue(txtCustomSHKTwiterKey.Text.Trim());
                dm.Element("SHKTwitterSecret").SetValue(txtCustomSHKTwiterSecret.Text.Trim());
                dm.Element("SHKTwitterCallbackUrl").SetValue(txtCustomSHKTwiterCallbackURL.Text.Trim());
                // Facebook
                dm.Element("SHKFacebookKey").SetValue(txtCustomSHKFacebookKey.Text.Trim());
                dm.Element("SHKFacebookSecret").SetValue(txtCustomSHKFacebookSecret.Text.Trim());
                // Application
                dm.Element("SHKMyAppName").SetValue(txtCustomMyAppName.Text.Trim());
                dm.Element("SHKMyAppURL").SetValue(txtCustomMyAppURL.Text.Trim());
            }
            try
            {
                doc.Save(_pathFile);
            }
            catch (Exception)
            {
            }
        }

        //#region "Event LostForcus"

        //private void txtTitleCoverBackground_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    CheckColorIsValid(txtTitleCoverBackground, tblTitleCoverBackground, imgTitleCoverBackground);
        //}

        //private void txtTitleCoverForeColor_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    CheckColorIsValid(txtTitleCoverForeColor, tblTitleCoverForeground, imgTitleCoverForeground);
        //}

        //private void txtTitleLoginForeground_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    CheckColorIsValid(txtTitleLoginForeground, tblTitleLoginForeground, imgTitleLoginForeground);
        //}

        //private void txtButtonRefreshBackground_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    CheckColorIsValid(txtButtonRefreshBackground, tblButtonRefreshBackground, imgRefreshBackgroundColor);
        //}

        //private void txtButtonReadBackground_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    CheckColorIsValid(txtButtonReadBackground, tblButtonReadBackground, imgReadBackgroundColor);
        //}

        //private void txtButtonUpdateBackground_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    CheckColorIsValid(txtButtonUpdateBackground, tblButtonUpdateBackground, imgUpdateBackgroundColor);
        //}

        //private void txtButtonDeleteBackground_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    CheckColorIsValid(txtButtonDeleteBackground, tblButtonDeleteBackground, imgDeleteBackgroundColor);
        //}

        //private void txtButtonDownloadBackground_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    CheckColorIsValid(txtButtonDownloadBackground, tblButtonDownloadBackground, imgDownloadBackgroundColor);
        //}

        //private void txtButtonCancelBackground_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    CheckColorIsValid(txtButtonCancelBackground, tblButtonCancelBackground, imgCancelBackgroundColor);
        //}

        //private void txtButtonLoginBackground_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    CheckColorIsValid(txtButtonLoginBackground, tblButtonLoginBackground, imgLoginBackgroundColor);
        //}

        //private void txtButtonCancelLoginBackground_LostFocus(object sender, RoutedEventArgs e)
        //{
        //    CheckColorIsValid(txtButtonCancelLoginBackground, tblButtonCancelLoginBackground, imgCancelLoginBackgroundColor);
        //}

        //#endregion

        private void CheckColorIsValid(object textBoxColor, object textBlock, object image)
        {
            try
            {
                if (!string.IsNullOrEmpty((textBoxColor as TextBox).Text.Trim()))
                {
                    if (bc.IsValid((textBoxColor as TextBox).Text.Trim()))
                    {
                        (textBlock as TextBlock).Background = (Brush)bc.ConvertFrom((textBoxColor as TextBox).Text);
                        (image as Image).Visibility = Visibility.Hidden;
                    }
                    else
                        (image as Image).Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {
            }
        }

        private void SaveStyleColor()
        {
            #region "Background"
            //1. ButtonRefresh
            try
            {
                if (!string.IsNullOrEmpty(txtButtonRefreshBackground.Text.Trim()))
                {
                    if (bc.IsValid(txtButtonRefreshBackground.Text.Trim()))
                    {
                        tblButtonRefreshBackground.Background = (Brush)bc.ConvertFrom(txtButtonRefreshBackground.Text.Trim());
                        imgRefreshBackgroundColor.Visibility = Visibility.Hidden;
                        foreach (var dm in doc.Descendants("ButtonRefresh"))
                        {
                            dm.Element("BackgroundColor").Value = txtButtonRefreshBackground.Text;
                            break;
                        }
                    }
                    else imgRefreshBackgroundColor.Visibility = Visibility.Visible;
                    //doc.Save(_pathFile);
                }
            }
            catch (Exception)
            {
            }
            //2. ButtonReadIssue
            try
            {
                if (!string.IsNullOrEmpty(txtButtonReadBackground.Text.Trim()))
                {
                    if (bc.IsValid(txtButtonReadBackground.Text.Trim()))
                    {
                        tblButtonReadBackground.Background = (Brush)bc.ConvertFrom(txtButtonReadBackground.Text.Trim());
                        imgReadBackgroundColor.Visibility = Visibility.Hidden;
                        foreach (var dm in doc.Descendants("ButtonReadIssue"))
                        {
                            dm.Element("BackgroundColor").Value = txtButtonReadBackground.Text;
                            break;
                        }
                    }
                    else imgReadBackgroundColor.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {
            }
            //3. ButtonDeleteIssue

            try
            {
                if (!string.IsNullOrEmpty(txtButtonDeleteBackground.Text.Trim()))
                {
                    if (bc.IsValid(txtButtonDeleteBackground.Text.Trim()))
                    {
                        tblButtonDeleteBackground.Background = (Brush)bc.ConvertFrom(txtButtonDeleteBackground.Text.Trim());
                        imgDeleteBackgroundColor.Visibility = Visibility.Hidden;
                        foreach (var dm in doc.Descendants("ButtonDeleteIssue"))
                        {
                            dm.Element("BackgroundColor").Value = txtButtonDeleteBackground.Text;
                            break;
                        }
                    }
                    else imgDeleteBackgroundColor.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {
            }
            //4. ButtonFreeDownloadIssue
            try
            {
                if (!string.IsNullOrEmpty(txtButtonDownloadBackground.Text.Trim()))
                {
                    if (bc.IsValid(txtButtonDownloadBackground.Text.Trim()))
                    {
                        tblButtonDownloadBackground.Background = (Brush)bc.ConvertFrom(txtButtonDownloadBackground.Text.Trim());
                        imgDownloadBackgroundColor.Visibility = Visibility.Hidden;
                        foreach (var dm in doc.Descendants("ButtonFreeDownloadIssue"))
                        {
                            dm.Element("BackgroundColor").Value = txtButtonDownloadBackground.Text;
                            break;
                        }
                    }
                    else imgDownloadBackgroundColor.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {
            }
            //5. ButtonCancelDownloadIssue
            try
            {

                if (!string.IsNullOrEmpty(txtButtonCancelBackground.Text.Trim()))
                {
                    if (bc.IsValid(txtButtonCancelBackground.Text.Trim()))
                    {
                        tblButtonCancelBackground.Background = (Brush)bc.ConvertFrom(txtButtonCancelBackground.Text.Trim());
                        imgCancelBackgroundColor.Visibility = Visibility.Hidden;
                        foreach (var dm in doc.Descendants("ButtonCancelDownloadIssue"))
                        {
                            dm.Element("BackgroundColor").Value = txtButtonCancelBackground.Text;
                            break;
                        }
                    }
                    else
                        imgCancelBackgroundColor.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {
            }
            //6. ButtonFreeUpdateIssue
            try
            {
                if (!string.IsNullOrEmpty(txtButtonUpdateBackground.Text.Trim()))
                {
                    if (bc.IsValid(txtButtonUpdateBackground.Text.Trim()))
                    {
                        tblButtonUpdateBackground.Background = (Brush)bc.ConvertFrom(txtButtonUpdateBackground.Text.Trim());
                        imgUpdateBackgroundColor.Visibility = Visibility.Hidden;
                        foreach (var dm in doc.Descendants("ButtonFreeUpdateIssue"))
                        {
                            dm.Element("BackgroundColor").Value = txtButtonUpdateBackground.Text;
                            break;
                        }
                    }
                    else imgUpdateBackgroundColor.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {
            }
            //7. ButtonLogin
            try
            {
                if (!string.IsNullOrEmpty(txtButtonLoginBackground.Text.Trim()))
                {
                    if (bc.IsValid(txtButtonLoginBackground.Text.Trim()))
                    {
                        tblButtonLoginBackground.Background = (Brush)bc.ConvertFrom(txtButtonLoginBackground.Text.Trim());
                        imgLoginBackgroundColor.Visibility = Visibility.Hidden;
                        foreach (var dm in doc.Descendants("ButtonLogin"))
                        {
                            dm.Element("BackgroundColor").Value = txtButtonLoginBackground.Text;
                            break;
                        }
                    }
                    else imgLoginBackgroundColor.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {
            }
            //8. ButtonCancelLogin
            try
            {
                if (!string.IsNullOrEmpty(txtButtonCancelLoginBackground.Text.Trim()))
                {
                    if (bc.IsValid(txtButtonCancelLoginBackground.Text.Trim()))
                    {
                        tblButtonCancelLoginBackground.Background = (Brush)bc.ConvertFrom(txtButtonCancelLoginBackground.Text.Trim());
                        imgCancelLoginBackgroundColor.Visibility = Visibility.Hidden;
                        foreach (var dm in doc.Descendants("ButtonCancelLogin"))
                        {
                            dm.Element("BackgroundColor").Value = txtButtonCancelLoginBackground.Text;
                            break;
                        }
                    }
                    else
                        imgCancelLoginBackgroundColor.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {
            }


            // TitleCover BackgroundColor
            try
            {
                if (!string.IsNullOrEmpty(txtTitleCoverBackground.Text.Trim()))
                {
                    if (bc.IsValid(txtTitleCoverBackground.Text.Trim()))
                    {
                        tblTitleCoverBackground.Background = (Brush)bc.ConvertFrom(txtTitleCoverBackground.Text.Trim());
                        imgTitleCoverBackground.Visibility = Visibility.Hidden;
                        foreach (var dm in doc.Descendants("TitleCover"))
                        {
                            dm.Element("BackgroundColor").Value = txtTitleCoverBackground.Text;
                            break;
                        }
                    }
                    else imgTitleCoverBackground.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {
            }
            #endregion

            #region "Foreground"
            // Title ForegroundColor
            try
            {
                if (!string.IsNullOrEmpty(txtTitleCoverForeColor.Text.Trim()))
                {
                    if (bc.IsValid(txtTitleCoverForeColor.Text.Trim()))
                    {
                        tblTitleCoverForeground.Background = (Brush)bc.ConvertFrom(txtTitleCoverForeColor.Text.Trim());
                        imgTitleCoverForeground.Visibility = Visibility.Hidden;
                        foreach (var dm in doc.Descendants("TitleCover"))
                        {
                            dm.Element("Foreground").Value = txtTitleCoverForeColor.Text;
                            break;
                        }
                    }
                    else imgTitleCoverForeground.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (!string.IsNullOrEmpty(txtTitleLoginForeground.Text.Trim()))
                {
                    if (bc.IsValid(txtTitleLoginForeground.Text.Trim()))
                    {
                        tblTitleLoginForeground.Background = (Brush)bc.ConvertFrom(txtTitleLoginForeground.Text.Trim());
                        imgTitleLoginForeground.Visibility = Visibility.Hidden;
                        foreach (var dm in doc.Descendants("TitleLogin"))
                        {
                            dm.Element("Foreground").Value = (txtTitleLoginForeground.Text);
                            break;
                        }
                    }
                    else imgTitleLoginForeground.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {
            }
            //ButtonRefresh
            try
            {
                if (!string.IsNullOrEmpty(txtButtonRefreshForeground.Text.Trim()))
                {
                    if (bc.IsValid(txtButtonRefreshForeground.Text.Trim()))
                    {
                        tblButtonRefreshForeground.Background = (Brush)bc.ConvertFrom(txtButtonRefreshForeground.Text.Trim());
                        imgRefreshForeground.Visibility = Visibility.Hidden;
                        foreach (var dm in doc.Descendants("ButtonRefresh"))
                        {
                            dm.Element("Foreground").Value = txtButtonRefreshForeground.Text;
                            break;
                        }
                    }
                    else imgRefreshForeground.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {
            }
            //ButtonReadIssue
            try
            {
                if (!string.IsNullOrEmpty(txtButtonReadForeground.Text.Trim()))
                {
                    if (bc.IsValid(txtButtonReadForeground.Text.Trim()))
                    {
                        tblButtonReadForeground.Background = (Brush)bc.ConvertFrom(txtButtonReadForeground.Text.Trim());
                        imgReadForeground.Visibility = Visibility.Hidden;
                        foreach (var dm in doc.Descendants("ButtonReadIssue"))
                        {
                            dm.Element("Foreground").Value = txtButtonReadForeground.Text;
                            break;
                        }
                    }
                    else imgReadForeground.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {
            }

            //ButtonDeleteIssue
            try
            {
                if (!string.IsNullOrEmpty(txtButtonDeleteForeground.Text.Trim()))
                {
                    if (bc.IsValid(txtButtonDeleteForeground.Text.Trim()))
                    {
                        tblButtonDeleteForeground.Background = (Brush)bc.ConvertFrom(txtButtonDeleteForeground.Text.Trim());
                        imgDeleteForeground.Visibility = Visibility.Hidden;
                        foreach (var dm in doc.Descendants("ButtonDeleteIssue"))
                        {
                            dm.Element("Foreground").Value = txtButtonDeleteForeground.Text;
                            break;
                        }
                    }
                    else imgDeleteForeground.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {
            }

            //ButtonFreeDownloadIssue
            try
            {
                if (!string.IsNullOrEmpty(txtButtonDownloadForeground.Text.Trim()))
                {
                    if (bc.IsValid(txtButtonDownloadForeground.Text.Trim()))
                    {
                        tblButtonDownloadForeground.Background = (Brush)bc.ConvertFrom(txtButtonDownloadForeground.Text.Trim());
                        imgDownloadForeground.Visibility = Visibility.Hidden;
                        foreach (var dm in doc.Descendants("ButtonFreeDownloadIssue"))
                        {
                            dm.Element("Foreground").Value = txtButtonDownloadForeground.Text;
                            break;
                        }
                    }
                    else imgDownloadForeground.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {
            }

            //ButtonCancelDownloadIssue
            try
            {
                if (!string.IsNullOrEmpty(txtButtonCancelForeground.Text.Trim()))
                {
                    if (bc.IsValid(txtButtonCancelForeground.Text.Trim()))
                    {
                        tblButtonCancelForeground.Background = (Brush)bc.ConvertFrom(txtButtonCancelForeground.Text.Trim());
                        imgCancelForeground.Visibility = Visibility.Hidden;
                        foreach (var dm in doc.Descendants("ButtonCancelDownloadIssue"))
                        {
                            dm.Element("Foreground").Value = txtButtonCancelForeground.Text;
                            break;
                        }
                    }
                    else imgCancelForeground.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {
            }
            //ButtonFreeUpdateIssue
            try
            {
                if (!string.IsNullOrEmpty(txtButtonUpdateForeground.Text.Trim()))
                {
                    if (bc.IsValid(txtButtonUpdateForeground.Text.Trim()))
                    {
                        tblButtonUpdateForeground.Background = (Brush)bc.ConvertFrom(txtButtonUpdateForeground.Text.Trim());
                        imgUpdateForeground.Visibility = Visibility.Hidden;
                        foreach (var dm in doc.Descendants("ButtonFreeUpdateIssue"))
                        {
                            dm.Element("Foreground").Value = txtButtonUpdateForeground.Text;
                            break;
                        }
                    }
                    else imgUpdateForeground.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {
            }
            //ButtonLogin
            try
            {
                if (!string.IsNullOrEmpty(txtButtonLoginForeground.Text.Trim()))
                {
                    if (bc.IsValid(txtButtonLoginForeground.Text.Trim()))
                    {
                        tblButtonLoginForeground.Background = (Brush)bc.ConvertFrom(txtButtonLoginForeground.Text.Trim());
                        imgLoginForeground.Visibility = Visibility.Hidden;
                        foreach (var dm in doc.Descendants("ButtonLogin"))
                        {
                            dm.Element("Foreground").Value = txtButtonLoginForeground.Text;
                            break;
                        }
                    }
                    else imgLoginForeground.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {
            }
            //ButtonCancelLogin
            try
            {
                if (!string.IsNullOrEmpty(txtButtonCancelLoginForeground.Text.Trim()))
                {
                    if (bc.IsValid(txtButtonCancelLoginForeground.Text.Trim()))
                    {
                        tblButtonCancelLoginForeground.Background = (Brush)bc.ConvertFrom(txtButtonCancelLoginForeground.Text.Trim());
                        imgCancelLoginForeground.Visibility = Visibility.Hidden;
                        foreach (var dm in doc.Descendants("ButtonCancelLogin"))
                        {
                            dm.Element("Foreground").Value = txtButtonCancelLoginForeground.Text;
                            break;
                        }
                    }
                    else imgCancelLoginForeground.Visibility = Visibility.Visible;
                }
            }
            catch (Exception)
            {
            }
            #endregion

            try
            {
                doc.Save(_pathFile);
                MessageBox.Show("Save file is completed.", "Save", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Save file í uncompleted.", "Save", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void HideImages()
        {

            imgRefreshBackgroundColor.Visibility = Visibility.Hidden;
            imgRefreshBackgroundColor.Visibility = Visibility.Hidden;
            imgReadBackgroundColor.Visibility = Visibility.Hidden;
            imgReadForeground.Visibility = Visibility.Hidden;
            imgDeleteBackgroundColor.Visibility = Visibility.Hidden;
            imgDeleteForeground.Visibility = Visibility.Hidden;
            imgDownloadBackgroundColor.Visibility = Visibility.Hidden;
            imgDownloadForeground.Visibility = Visibility.Hidden;
            imgCancelBackgroundColor.Visibility = Visibility.Hidden;
            imgCancelLoginForeground.Visibility = Visibility.Hidden;
            imgUpdateBackgroundColor.Visibility = Visibility.Hidden;
            imgUpdateForeground.Visibility = Visibility.Hidden;
            imgLoginBackgroundColor.Visibility = Visibility.Hidden;
            imgLoginForeground.Visibility = Visibility.Hidden;
            imgCancelLoginBackgroundColor.Visibility = Visibility.Hidden;
            imgCancelLoginForeground.Visibility = Visibility.Hidden;
            imgTitleCoverBackground.Visibility = Visibility.Hidden;
            imgTitleCoverForeground.Visibility = Visibility.Hidden;
            imgTitleLoginForeground.Visibility = Visibility.Hidden;
            #region "Background"
            //1. ButtonRefresh
            try
            {
                if (!string.IsNullOrEmpty(txtButtonRefreshBackground.Text.Trim()))
                {
                    if (!bc.IsValid(txtButtonRefreshBackground.Text.Trim()))
                    {
                        imgRefreshBackgroundColor.Visibility = Visibility.Visible;
                    }
                }
                if (!string.IsNullOrEmpty(txtButtonRefreshForeground.Text.Trim()))
                {
                    if (!bc.IsValid(txtButtonRefreshForeground.Text.Trim()))
                    {
                        imgRefreshForeground.Visibility = Visibility.Visible;
                    }
                }
            }
            catch (Exception)
            {
            }
            //2. ButtonReadIssue
            try
            {
                if (!string.IsNullOrEmpty(txtButtonReadBackground.Text.Trim()))
                {
                    if (!bc.IsValid(txtButtonReadBackground.Text.Trim()))
                    {
                        imgReadBackgroundColor.Visibility = Visibility.Visible;
                    }
                }
                if (!string.IsNullOrEmpty(txtButtonReadForeground.Text.Trim()))
                {
                    if (!bc.IsValid(txtButtonReadForeground.Text.Trim()))
                    {
                        imgReadForeground.Visibility = Visibility.Visible;
                    }
                }
            }
            catch (Exception)
            {
            }
            //3. ButtonDeleteIssue

            try
            {
                if (!string.IsNullOrEmpty(txtButtonDeleteBackground.Text.Trim()))
                {
                    if (!bc.IsValid(txtButtonDeleteBackground.Text.Trim()))
                    {
                        imgDeleteBackgroundColor.Visibility = Visibility.Visible;
                    }
                }
                if (!string.IsNullOrEmpty(txtButtonDeleteForeground.Text.Trim()))
                {
                    if (!bc.IsValid(txtButtonDeleteForeground.Text.Trim()))
                    {
                        imgDeleteForeground.Visibility = Visibility.Visible;
                    }
                }
            }
            catch (Exception)
            {
            }
            //4. ButtonFreeDownloadIssue
            try
            {
                if (!string.IsNullOrEmpty(txtButtonDownloadBackground.Text.Trim()))
                {
                    if (!bc.IsValid(txtButtonDownloadBackground.Text.Trim()))
                    {
                        imgDownloadBackgroundColor.Visibility = Visibility.Visible;
                    }
                }
                if (!string.IsNullOrEmpty(txtButtonDownloadForeground.Text.Trim()))
                {
                    if (!bc.IsValid(txtButtonDownloadForeground.Text.Trim()))
                    {
                        imgDownloadForeground.Visibility = Visibility.Visible;
                    }
                }
            }
            catch (Exception)
            {
            }
            //5. ButtonCancelDownloadIssue
            try
            {

                if (!string.IsNullOrEmpty(txtButtonCancelBackground.Text.Trim()))
                {
                    if (!bc.IsValid(txtButtonCancelBackground.Text.Trim()))
                    {
                        imgCancelBackgroundColor.Visibility = Visibility.Visible;
                    }
                }

                if (!string.IsNullOrEmpty(txtButtonCancelForeground.Text.Trim()))
                {
                    if (!bc.IsValid(txtButtonCancelForeground.Text.Trim()))
                    {
                        imgCancelForeground.Visibility = Visibility.Visible;
                    }
                }
            }
            catch (Exception)
            {
            }
            //6. ButtonFreeUpdateIssue
            try
            {
                if (!string.IsNullOrEmpty(txtButtonUpdateBackground.Text.Trim()))
                {
                    if (!bc.IsValid(txtButtonUpdateBackground.Text.Trim()))
                    {
                        imgUpdateBackgroundColor.Visibility = Visibility.Visible;
                    }
                }
                if (!string.IsNullOrEmpty(txtButtonUpdateForeground.Text.Trim()))
                {
                    if (!bc.IsValid(txtButtonUpdateForeground.Text.Trim()))
                    {
                        imgUpdateForeground.Visibility = Visibility.Visible;
                    }
                }
            }
            catch (Exception)
            {
            }
            //7. ButtonLogin
            try
            {
                if (!string.IsNullOrEmpty(txtButtonLoginBackground.Text.Trim()))
                {
                    if (!bc.IsValid(txtButtonLoginBackground.Text.Trim()))
                    {
                        imgLoginBackgroundColor.Visibility = Visibility.Visible;
                    }
                }
                if (!string.IsNullOrEmpty(txtButtonLoginForeground.Text.Trim()))
                {
                    if (!bc.IsValid(txtButtonLoginForeground.Text.Trim()))
                    {
                        imgLoginForeground.Visibility = Visibility.Visible;
                    }
                }
            }
            catch (Exception)
            {
            }
            //8. ButtonCancelLogin
            try
            {
                if (!string.IsNullOrEmpty(txtButtonCancelLoginBackground.Text.Trim()))
                {
                    if (!bc.IsValid(txtButtonCancelLoginBackground.Text.Trim()))
                    {
                        imgCancelLoginBackgroundColor.Visibility = Visibility.Visible;
                    }
                }
                if (!string.IsNullOrEmpty(txtButtonCancelLoginForeground.Text.Trim()))
                {
                    if (!bc.IsValid(txtButtonCancelLoginForeground.Text.Trim()))
                    {
                        imgCancelLoginForeground.Visibility = Visibility.Visible;
                    }
                }
            }
            catch (Exception)
            {
            }
            // TitleCover BackgroundColor
            try
            {
                if (!string.IsNullOrEmpty(txtTitleCoverBackground.Text.Trim()))
                {
                    if (!bc.IsValid(txtTitleCoverBackground.Text.Trim()))
                    {
                        imgTitleCoverBackground.Visibility = Visibility.Visible;
                    }
                }
            }
            catch (Exception)
            {
            }
            #endregion

            #region "ForegroundColor"
            // Title ForegroundColor
            try
            {
                if (!string.IsNullOrEmpty(txtTitleCoverForeColor.Text.Trim()))
                {
                    if (!bc.IsValid(txtTitleCoverForeColor.Text.Trim()))
                    {
                        imgTitleCoverForeground.Visibility = Visibility.Visible;
                    }
                }
            }
            catch (Exception)
            {
            }
            try
            {
                if (!string.IsNullOrEmpty(txtTitleLoginForeground.Text.Trim()))
                {
                    if (!bc.IsValid(txtTitleLoginForeground.Text.Trim()))
                    {
                        imgTitleLoginForeground.Visibility = Visibility.Visible;
                    }
                }
            }
            catch (Exception)
            {
            }
            #endregion


        }

        private void textChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                changed = true;
                btnClose.IsEnabled = false;
                if (sender is TextBox)
                {
                    var txtColor = sender as TextBox;
                    if (txtColor.Name.Equals("txtTitleCoverBackground"))
                    {

                        if (bc.IsValid(txtTitleCoverBackground.Text.Trim()))
                        {
                            tblTitleCoverBackground.Background = (Brush)bc.ConvertFrom(txtTitleCoverBackground.Text.Trim());
                            imgTitleCoverBackground.Visibility = Visibility.Hidden;
                        }
                        else imgTitleCoverBackground.Visibility = Visibility.Visible;
                        return;
                    }
                    if (txtColor.Name.Equals("txtTitleCoverForeColor"))
                    {
                        if (bc.IsValid(txtTitleCoverForeColor.Text.Trim()))
                        {
                            tblTitleCoverForeground.Background = (Brush)bc.ConvertFrom(txtTitleCoverForeColor.Text.Trim());
                            imgTitleCoverForeground.Visibility = Visibility.Hidden;
                        }
                        else imgTitleCoverForeground.Visibility = Visibility.Visible;
                        return;
                    }
                    if (txtColor.Name.Equals("txtTitleLoginForeground"))
                    {
                        if (bc.IsValid(txtTitleLoginForeground.Text.Trim()))
                        {
                            tblTitleLoginForeground.Background = (Brush)bc.ConvertFrom(txtTitleLoginForeground.Text.Trim());
                            imgTitleLoginForeground.Visibility = Visibility.Hidden;
                        }
                        else imgTitleLoginForeground.Visibility = Visibility.Visible;
                        return;
                    }
                    if (txtColor.Name.Equals("txtButtonRefreshBackground"))
                    {
                        if (bc.IsValid(txtButtonRefreshBackground.Text.Trim()))
                        {
                            tblButtonRefreshBackground.Background = (Brush)bc.ConvertFrom(txtButtonRefreshBackground.Text.Trim());
                            imgRefreshBackgroundColor.Visibility = Visibility.Hidden;
                        }
                        else imgRefreshBackgroundColor.Visibility = Visibility.Visible;
                        return;
                    }

                    if (txtColor.Name.Equals("txtButtonRefreshForeground"))
                    {
                        if (bc.IsValid(txtButtonRefreshForeground.Text.Trim()))
                        {
                            tblButtonRefreshForeground.Background = (Brush)bc.ConvertFrom(txtButtonRefreshForeground.Text.Trim());
                            imgRefreshForeground.Visibility = Visibility.Hidden;
                        }
                        else imgRefreshForeground.Visibility = Visibility.Visible;
                        return;
                    }

                    if (txtColor.Name.Equals("txtButtonReadBackground"))
                    {
                        if (bc.IsValid(txtButtonReadBackground.Text.Trim()))
                        {
                            tblButtonReadBackground.Background = (Brush)bc.ConvertFrom(txtButtonReadBackground.Text.Trim());
                            imgReadBackgroundColor.Visibility = Visibility.Hidden;
                        }
                        else imgReadBackgroundColor.Visibility = Visibility.Visible;
                        return;
                    }
                    if (txtColor.Name.Equals("txtButtonReadForeground"))
                    {
                        if (bc.IsValid(txtButtonReadForeground.Text.Trim()))
                        {
                            tblButtonReadForeground.Background = (Brush)bc.ConvertFrom(txtButtonReadForeground.Text.Trim());
                            imgReadForeground.Visibility = Visibility.Hidden;
                        }
                        else imgReadForeground.Visibility = Visibility.Visible;
                        return;
                    }

                    if (txtColor.Name.Equals("txtButtonUpdateBackground"))
                    {
                        if (bc.IsValid(txtButtonUpdateBackground.Text.Trim()))
                        {
                            tblButtonUpdateBackground.Background = (Brush)bc.ConvertFrom(txtButtonUpdateBackground.Text.Trim());
                            imgUpdateBackgroundColor.Visibility = Visibility.Hidden;
                        }
                        else imgUpdateBackgroundColor.Visibility = Visibility.Visible;
                        return;
                    }
                    if (txtColor.Name.Equals("txtButtonUpdateForeground"))
                    {
                        if (bc.IsValid(txtButtonUpdateForeground.Text.Trim()))
                        {
                            tblButtonUpdateForeground.Background = (Brush)bc.ConvertFrom(txtButtonUpdateForeground.Text.Trim());
                            imgUpdateForeground.Visibility = Visibility.Hidden;
                        }
                        else imgUpdateForeground.Visibility = Visibility.Visible;
                        return;
                    }

                    if (txtColor.Name.Equals("txtButtonDeleteBackground"))
                    {
                        if (bc.IsValid(txtButtonDeleteBackground.Text.Trim()))
                        {
                            tblButtonDeleteBackground.Background = (Brush)bc.ConvertFrom(txtButtonDeleteBackground.Text.Trim());
                            imgDeleteBackgroundColor.Visibility = Visibility.Hidden;
                        }
                        else imgDeleteBackgroundColor.Visibility = Visibility.Visible;
                        return;
                    }
                    if (txtColor.Name.Equals("txtButtonDeleteForeground"))
                    {
                        if (bc.IsValid(txtButtonDeleteForeground.Text.Trim()))
                        {
                            tblButtonDeleteForeground.Background = (Brush)bc.ConvertFrom(txtButtonDeleteForeground.Text.Trim());
                            imgDeleteForeground.Visibility = Visibility.Hidden;
                        }
                        else imgDeleteForeground.Visibility = Visibility.Visible;
                        return;
                    }

                    if (txtColor.Name.Equals("txtButtonDownloadBackground"))
                    {
                        if (bc.IsValid(txtButtonDownloadBackground.Text.Trim()))
                        {
                            tblButtonDownloadBackground.Background = (Brush)bc.ConvertFrom(txtButtonDownloadBackground.Text.Trim());
                            imgDownloadBackgroundColor.Visibility = Visibility.Hidden;
                        }
                        else imgDownloadBackgroundColor.Visibility = Visibility.Visible;
                        return;
                    }
                    if (txtColor.Name.Equals("txtButtonDownloadForeground"))
                    {
                        if (bc.IsValid(txtButtonDownloadForeground.Text.Trim()))
                        {
                            tblButtonDownloadForeground.Background = (Brush)bc.ConvertFrom(txtButtonDownloadForeground.Text.Trim());
                            imgDownloadForeground.Visibility = Visibility.Hidden;
                        }
                        else imgDownloadForeground.Visibility = Visibility.Visible;
                        return;
                    }

                    if (txtColor.Name.Equals("txtButtonCancelBackground"))
                    {
                        if (bc.IsValid(txtButtonCancelBackground.Text.Trim()))
                        {
                            tblButtonCancelBackground.Background = (Brush)bc.ConvertFrom(txtButtonCancelBackground.Text.Trim());
                            imgCancelBackgroundColor.Visibility = Visibility.Hidden;
                        }
                        else imgCancelBackgroundColor.Visibility = Visibility.Visible;
                        return;
                    }
                    if (txtColor.Name.Equals("txtButtonCancelForeground"))
                    {
                        if (bc.IsValid(txtButtonCancelForeground.Text.Trim()))
                        {
                            tblButtonCancelForeground.Background = (Brush)bc.ConvertFrom(txtButtonCancelForeground.Text.Trim());
                            imgCancelForeground.Visibility = Visibility.Hidden;
                        }
                        else imgCancelForeground.Visibility = Visibility.Visible;
                        return;
                    }

                    if (txtColor.Name.Equals("txtButtonLoginBackground"))
                    {
                        if (bc.IsValid(txtButtonLoginBackground.Text.Trim()))
                        {
                            tblButtonLoginBackground.Background = (Brush)bc.ConvertFrom(txtButtonLoginBackground.Text.Trim());
                            imgLoginBackgroundColor.Visibility = Visibility.Hidden;
                        }
                        else imgLoginBackgroundColor.Visibility = Visibility.Visible;
                        return;
                    }
                    if (txtColor.Name.Equals("txtButtonLoginForeground"))
                    {
                        if (bc.IsValid(txtButtonLoginForeground.Text.Trim()))
                        {
                            tblButtonLoginForeground.Background = (Brush)bc.ConvertFrom(txtButtonLoginForeground.Text.Trim());
                            imgLoginForeground.Visibility = Visibility.Hidden;
                        }
                        else imgLoginForeground.Visibility = Visibility.Visible;
                        return;
                    }

                    if (txtColor.Name.Equals("txtButtonCancelLoginBackground"))
                    {
                        if (bc.IsValid(txtButtonCancelLoginBackground.Text.Trim()))
                        {
                            tblButtonCancelLoginBackground.Background = (Brush)bc.ConvertFrom(txtButtonCancelLoginBackground.Text.Trim());
                            imgCancelLoginBackgroundColor.Visibility = Visibility.Hidden;
                        }
                        else imgCancelLoginBackgroundColor.Visibility = Visibility.Visible;
                        return;
                    }
                    if (txtColor.Name.Equals("txtButtonCancelLoginForeground"))
                    {
                        if (bc.IsValid(txtButtonCancelLoginForeground.Text.Trim()))
                        {
                            tblButtonCancelLoginForeground.Background = (Brush)bc.ConvertFrom(txtButtonCancelLoginForeground.Text.Trim());
                            imgCancelLoginForeground.Visibility = Visibility.Hidden;
                        }
                        else imgCancelLoginForeground.Visibility = Visibility.Visible;
                        return;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetDefault();
            LoadData();

            txtButtonCancelBackground.TextChanged += textChanged;
            txtButtonCancelForeground.TextChanged += textChanged;
            txtButtonCancelLoginBackground.TextChanged += textChanged;
            txtButtonCancelLoginForeground.TextChanged += textChanged;
            txtButtonDeleteBackground.TextChanged += textChanged;
            txtButtonDeleteForeground.TextChanged += textChanged;
            txtButtonDownloadBackground.TextChanged += textChanged;
            txtButtonDownloadForeground.TextChanged += textChanged;
            txtButtonLoginBackground.TextChanged += textChanged;
            txtButtonLoginForeground.TextChanged += textChanged;
            txtButtonReadBackground.TextChanged += textChanged;
            txtButtonReadForeground.TextChanged += textChanged;
            txtButtonRefreshBackground.TextChanged += textChanged;
            txtButtonRefreshForeground.TextChanged += textChanged;
            txtButtonUpdateBackground.TextChanged += textChanged;
            txtButtonUpdateForeground.TextChanged += textChanged;
            txtCustomMyAppName.TextChanged += textChanged;

            txtTitleCoverBackground.TextChanged += textChanged;
            txtTitleCoverForeColor.TextChanged += textChanged;
            txtTitleLoginForeground.TextChanged += textChanged;
            HideImages();
            FocusManager.SetFocusedElement(this, txtTitleCoverBackground);
        }


        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (changed)
            {
                if (MessageBox.Show("Do you want save the change information ?", "Close", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Save();
                }
            }
        }

    }
}
