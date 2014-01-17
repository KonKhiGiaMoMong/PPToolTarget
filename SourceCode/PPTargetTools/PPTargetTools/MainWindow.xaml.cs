using PPTargetTools.Pages;
using System;
using System.Collections.Generic;
using System.IO;
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


namespace WpfToolsTarget
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            /// <summary>
            /// Initializes a new instance of the ToolsTarget class.
            /// </summary>
        }

        private void cbExistTarget_Checked(object sender, RoutedEventArgs e)
        {
            Handle(sender as CheckBox);
        }

        private void cbExistTarget_Unchecked(object sender, RoutedEventArgs e)
        {
            Handle(sender as CheckBox);
        }

        void Handle(CheckBox checkBox)
        {
            // Use IsChecked.
            bool flag = checkBox.IsChecked.Value;
            if (flag)
            {
                cbbTarget.IsEnabled = true;
                if (!String.IsNullOrEmpty(txtpath.Text))
                {
                    FillTargetNameCombo(txtpath.Text);
                }
            }
            else
            {
                cbbTarget.IsEnabled = false;
                cbbTarget.Items.Clear();
            }

        }

        private void btmBrowse_Click(object sender, RoutedEventArgs e)
        {
            // Display FolderBrowserDialog by calling ShowDialog method =
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            //get path
            txtpath.Text = dialog.SelectedPath;
            if (cbExistTarget.IsChecked.Value)
            {
                FillTargetNameCombo(txtpath.Text);
            }
        }

        private void FillTargetNameCombo(String path)
        {
            try
            {
                cbbTarget.Items.Clear();

                // Get all subdirectories
                var directories = Directory.GetDirectories(path);
                foreach (String item in directories)
                {
                    cbbTarget.Items.Add(item.Remove(0, path.Length + 1));
                    cbbTargetSub.Items.Add(item.Remove(0, path.Length + 1));
                }
                cbbTarget.SelectedIndex = 0;
                cbbTargetSub.SelectedIndex = 0;
            }
            catch (Exception e)
            {

            }
        }



        private void FillTargetNameCombo(String path, ComboBox[] elements)
        {
            try
            {
                foreach (ComboBox cbb in elements)
                {
                    cbb.Items.Clear();
                }

                if (Directory.Exists(path))
                {
                    // Get all subdirectories
                    var directories = Directory.GetDirectories(path);
                    foreach (String item in directories)
                    {
                        foreach (ComboBox cbb in elements)
                        {
                            cbb.Items.Add(item.Remove(0, path.Length + 1));
                        }
                        //cbbTarget.Items.Add(item.Remove(0, path.Length + 1));
                        //cbbTargetSub.Items.Add(item.Remove(0, path.Length + 1));
                    }
                    foreach (ComboBox cbb in elements)
                    {
                        cbb.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception e)
            {

            }
        }

        private void CreateTarget(String path)
        {
            String pathDir = txtpath.Text + "\\" + txtNameTarget.Text;

            // check folder exists
            if (Directory.Exists(txtpath.Text))
            {
                // check sub directory exists
                if (!Directory.Exists(pathDir))
                {
                    Directory.CreateDirectory(pathDir);
                    string[] pathArr = { "AppConfig", "Assets", "Images", "Modern" };
                    string[] pathAss = { "Pages", "Thumbnail" };
                    string[] pathModern = { "assets", "background", "logo" };
                    foreach (var item in pathArr)
                    {
                        //Create sub directory AppConfig, Assets, Images
                        string paths = pathDir + "\\" + item;
                        if (item == "Assets")
                        {
                            //Create sub directory InternalIssue
                            string pathAssets = paths + "\\InternalIssue";
                            Directory.CreateDirectory(pathAssets);
                            foreach (var i in pathAss)
                            {
                                //Create sub directory Pages, Thumbnail
                                string assets = pathAssets + "\\" + i;
                                Directory.CreateDirectory(assets);
                            }
                        }
                        if (item == "Modern")
                        {
                            foreach (var i in pathModern)
                            {
                                //Create sub directory "assets", "background", "logo"
                                string modern = paths + "\\" + i;
                                Directory.CreateDirectory(modern);
                            }
                        }
                        Directory.CreateDirectory(paths);
                    }

                    MessageBox.Show("Create Directory Target completed.", "Create Target", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtNameTarget.Text = "";
                }
                else
                {
                    // directory exists
                    MessageBox.Show("Sub directory exists");
                }
            }
            else
            {
                MessageBox.Show("No directory exists");
            }
        }

        private void btmCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                // declare the directory path
                if (String.IsNullOrEmpty(txtpath.Text))
                {
                    MessageBox.Show("Declare the directory path");
                    return;
                }
                if (String.IsNullOrEmpty(txtNameTarget.Text))
                {
                    MessageBox.Show("Declare the directory Name");
                    return;
                }

                if (cbExistTarget.IsChecked.Value && cbbTarget.SelectedItem != null)
                {
                    DirectoryCopy(txtpath.Text + "\\" + cbbTarget.SelectedItem.ToString(), txtpath.Text + "\\" + txtNameTarget.Text, true);
                    txtNameTarget.Text = "";
                    MessageBox.Show("Create Directory Target completed.", "Create Target", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    CreateTarget(txtpath.Text);
                }
            }
            catch (Exception)
            {
            }
        }

        public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(sourceDirName);
                DirectoryInfo[] dirs = dir.GetDirectories();

                // If the source directory does not exist, throw an exception.
                if (!dir.Exists)
                {
                    throw new DirectoryNotFoundException(
                        "Source directory does not exist or could not be found: "
                        + sourceDirName);
                }
                // If the destination directory does not exist, create it.
                if (!Directory.Exists(destDirName))
                {
                    Directory.CreateDirectory(destDirName);

                    if (copySubDirs)
                    {
                        foreach (DirectoryInfo subdir in dirs)
                        {
                            // Create the subdirectory.
                            string temppath = System.IO.Path.Combine(destDirName, subdir.Name);
                            //// Copy the subdirectories.
                            DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                        }
                    }
                    // Get the file contents of the directory to copy.
                    FileInfo[] fileInfo = dir.GetFiles();

                    foreach (FileInfo file in fileInfo)
                    {
                        // Create the path to the new copy of the file.
                        string temppath = System.IO.Path.Combine(destDirName, file.Name);

                        // Copy the file.
                        file.CopyTo(temppath, false);
                    }
                }
                else
                {
                    // directory exists
                    MessageBox.Show("sub directory exists");
                    return;
                }
            }
            catch (Exception)
            {
            }
        }

        private void cbPPDesktop_Checked(object sender, RoutedEventArgs e)
        {
            btnCopyReverse.IsEnabled = false;
            if (cbPPDesktop.IsChecked == true)
            {
                cbPPModernUI.IsChecked = false;

                try
                {
                    if (cbbTargetSub.Items.Count > 0)
                    {
                        cbbTargetSub.Items.Clear();
                    }
                    if (!String.IsNullOrEmpty(txtpath.Text) && !String.IsNullOrWhiteSpace(txtpath.Text))
                    {
                        FillTargetNameCombo(txtpath.Text);
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void cbPPDesktop_Unchecked(object sender, RoutedEventArgs e)
        {
            if (cbPPDesktop.IsChecked == false)
            {
                cbPPModernUI.IsChecked = true;
            }
        }

        private void cbPPModernUI_Unchecked(object sender, RoutedEventArgs e)
        {
            if (cbPPModernUI.IsChecked == false)
            {
                cbPPDesktop.IsChecked = true;
            }
        }

        private void cbPPModernUI_Checked(object sender, RoutedEventArgs e)
        {
            if (cbPPModernUI.IsChecked == true)
            {
                cbPPDesktop.IsChecked = false;
                btnCopyReverse.IsEnabled = true;
                try
                {
                    if (cbbTargetSub.Items.Count > 0)
                    {
                        cbbTargetSub.Items.Clear();
                    }
                    if (!String.IsNullOrEmpty(txtpath.Text) && !String.IsNullOrWhiteSpace(txtpath.Text))
                    {
                        FillTargetNameCombo(txtpath.Text);
                    }
                }
                catch (Exception)
                {
                }
            }
            else btnCopyReverse.IsEnabled = false;
        }
        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (tabSubmiss.IsSelected)
            {
                try
                {

                }
                catch (Exception ex)
                {
                }
            }
        }


        private void btnCopyReverse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbbTargetSub.SelectedIndex != -1)
                {
                    string path = System.IO.Path.GetDirectoryName(txtpath.Text);
                    string pathFrom = path + " \\PPModernUI\\PP\\PP.Presentation\\Package.appxmanifest";
                    string pathTo = path + " \\Clients\\" + cbbTargetSub.SelectedValue;

                    // Copy File Package.appxmanifest
                    if (File.Exists(pathFrom))
                    {
                        try
                        {
                            pathTo = pathTo + @"\Modern\assets\Package.appxmanifest";

                            FileInfo fl = new FileInfo(pathFrom);
                            fl.CopyTo(pathTo);
                            MessageBox.Show("Copy file completed.", "Copy file", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Copy file uncompleted.\r\n" + ex.ToString(), "Copy file", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }

                }
                else MessageBox.Show("You must choose a target.", "Select target", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            catch (Exception)
            {
            }
        }

        private void txtpath_MouseLeave(object sender, MouseEventArgs e)
        {

            if (cbExistTarget.IsChecked == true)
            {
                FillTargetNameCombo(txtpath.Text.Trim(), new ComboBox[] { cbbTarget, cbbTargetSub });
            }
        }

        private void txtpath_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            if (cbExistTarget.IsChecked == true)
            {
                FillTargetNameCombo(txtpath.Text.Trim(), new ComboBox[] { cbbTarget, cbbTargetSub });
            }
        }

        private void btnEdit_Config_Click(object sender, RoutedEventArgs e)
        {

            if (cbPPDesktop.IsChecked == false && cbPPModernUI.IsChecked == false)
            {
                MessageBox.Show("Choose a target type.", "Target", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (cbbTargetSub.SelectedIndex<0)
            {
                
                MessageBox.Show("You must choose a target.", "Target", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!Directory.Exists(txtpath.Text + "\\" + cbbTargetSub.SelectedItem.ToString() + "\\AppConfig"))
            {
                MessageBox.Show("This Director is not exist.", "Edit Config", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (cbPPDesktop.IsChecked == true)
            {
                try
                {
                    DirectoryInfo dir = new DirectoryInfo(txtpath.Text + "\\" + cbbTargetSub.SelectedItem.ToString() + "\\AppConfig");
                    FileInfo[] fileInfo = dir.GetFiles();
                    foreach (FileInfo file in fileInfo)
                    {
                        string filename = System.IO.Path.GetFileName(file.ToString());
                        if (filename.Contains("ControlConf.conf") == true)
                        {
                            ConfigDesktop conf = new ConfigDesktop(dir.ToString() + "\\" + filename);
                            conf.filepath = dir.ToString() + "\\" + filename;
                            conf.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("File Config is not Exist.", "Config", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("File Config is not Exist.", "Config", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else if (cbPPModernUI.IsChecked == true)
            {
                String fileName = txtpath.Text + "\\" + cbbTargetSub.SelectedItem.ToString() + "\\AppConfig\\AppConfig.conf";
                if (!File.Exists(fileName))
                {
                    MessageBox.Show("File Config is not Exist.", "Config", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                (new ConfigModernUI(fileName, cbbTargetSub.SelectedItem.ToString())).ShowDialog();
            }

        }

        private void btnCopy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbPPDesktop.IsChecked == true)
                {
                    string path = System.IO.Path.GetDirectoryName(txtpath.Text);
                    string pathPP = path + " \\PP\\PP.Presentation";

                    DirectoryInfo dir = new DirectoryInfo(txtpath.Text + "\\" + cbbTargetSub.SelectedItem.ToString());
                    DirectoryInfo[] dirs = dir.GetDirectories();

                    foreach (var item in dirs)
                    {
                        // Copy file from config folder in VS to local
                        if (item.ToString().Equals("AppConfig"))
                        {
                            DirectoryInfo source = new DirectoryInfo(dir.ToString() + "\\AppConfig");
                            FileInfo[] files = source.GetFiles();

                            foreach (FileInfo file in files)
                            {
                                // Create the path to the new copy of the file.
                                string temppathfile = System.IO.Path.Combine(pathPP + "\\AppConfig", file.Name);
                                // Copy the file.
                                file.CopyTo(temppathfile, true);
                            }
                        }

                        // Copy file  icon64.ico from Images folder folder in VS to local
                        if (item.ToString().Equals("Images"))
                        {
                            DirectoryInfo source = new DirectoryInfo(dir.ToString() + "\\Images");
                            string[] files = Directory.GetFiles(source.ToString(), "icon64*");
                            foreach (string file in files)
                            {
                                string filename = System.IO.Path.GetFileName(file);
                                string temppathfile = System.IO.Path.Combine(pathPP + "\\Images", filename);
                                // Copy the file.
                                System.IO.File.Copy(file, temppathfile, true);
                            }
                        }
                    }
                    MessageBox.Show("Copy file completed.", "Copy file", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else if (cbPPModernUI.IsChecked == true)
                {
                    string path = System.IO.Path.GetDirectoryName(txtpath.Text);
                    string pathPP = path + " \\PPModernUI\\PP\\PP.Presentation";

                    DirectoryInfo dir = new DirectoryInfo(txtpath.Text + "\\" + cbbTargetSub.SelectedItem.ToString());
                    DirectoryInfo[] dirs = dir.GetDirectories();

                    foreach (var item in dirs)
                    {
                        if (item.ToString().Equals("Modern"))
                        {
                            {
                                // Copy the file background
                                DirectoryInfo sourceback = new DirectoryInfo(dir.ToString() + "\\Modern " + "\\background");
                                FileInfo[] filesback = sourceback.GetFiles();
                                if (!Directory.Exists(pathPP + "\\Images" + "\\background"))
                                {
                                    Directory.CreateDirectory(pathPP + "\\Images" + "\\background");
                                }
                                foreach (FileInfo file in filesback)
                                {
                                    string temppathfile = System.IO.Path.Combine(pathPP + "\\Images" + "\\background", file.Name);

                                    file.CopyTo(temppathfile, true);
                                }

                                // Copy the file Assets
                                DirectoryInfo sourceAssets = new DirectoryInfo(dir.ToString() + "\\Modern " + "\\Assets");
                                FileInfo[] filesAssets = sourceAssets.GetFiles();
                                foreach (FileInfo fileas in filesAssets)
                                {
                                    string filename = System.IO.Path.GetFileName(fileas.ToString());
                                    if (filename.Contains(".appxmanifest") == false && filename.Contains(".conf") == false)
                                    {
                                        string temppathassets = System.IO.Path.Combine(pathPP + "\\Assets", filename);

                                        fileas.CopyTo(temppathassets, true);
                                    }
                                }

                                //Copy file home.html to ~PPModernUI\PP\PP.Presentation\Assets
                                string[] filesHtml = Directory.GetFiles(sourceAssets.ToString(), "*.html");
                                foreach (string file in filesHtml)
                                {
                                    string filename = System.IO.Path.GetFileName(file);
                                    string temppathfile = System.IO.Path.Combine(pathPP + "\\Assets", filename);

                                    System.IO.File.Copy(file, temppathfile, true);
                                }

                                // Copy file home.html to ~PPModernUI\PP\PP.Presentation\AppConfig
                                string[] filesConf = Directory.GetFiles(sourceAssets.ToString(), "*.conf");
                                foreach (string file in filesConf)
                                {
                                    string filename = System.IO.Path.GetFileName(file);
                                    string temppathApp = System.IO.Path.Combine(pathPP + "\\AppConfig", filename);

                                    System.IO.File.Copy(file, temppathApp, true);
                                }

                                //Copy file Package.appxmanifest to ~PPModernUI\PP\PP.Presentation
                                string[] filesPackage = Directory.GetFiles(sourceAssets.ToString(), "*.appxmanifest");
                                foreach (string file in filesPackage)
                                {
                                    string filename = System.IO.Path.GetFileName(file);
                                    string temppathfile = System.IO.Path.Combine(pathPP, filename);

                                    System.IO.File.Copy(file, temppathfile, true);
                                }


                                // Copy the file logo
                                DirectoryInfo sourcelogo = new DirectoryInfo(dir.ToString() + "\\Modern " + "\\logo");
                                FileInfo[] fileslogo = sourcelogo.GetFiles();

                                if (!Directory.Exists(pathPP + "\\Images" + "\\logo"))
                                {
                                    Directory.CreateDirectory(pathPP + "\\Images" + "\\logo");
                                }

                                foreach (FileInfo file in fileslogo)
                                {
                                    string temppathfile = System.IO.Path.Combine(pathPP + "\\Images" + "\\logo", file.Name);

                                    file.CopyTo(temppathfile, true);

                                }
                            }
                        }
                    }
                    MessageBox.Show("Copy file completed.", "Copy file", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                else MessageBox.Show("You must choose a target.", "Select target", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {

            }
        }

    }
}




