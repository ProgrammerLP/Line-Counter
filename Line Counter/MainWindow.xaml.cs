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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace Line_Counter
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        string path = "";

        public MainWindow()
        {
            InitializeComponent();

            try
            {
                int numOfLines = System.IO.File.ReadAllLines(@"LSS Launcher/LauncherData/Data.ld").Length;
                Console.WriteLine(numOfLines.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void choose_path_btn_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Choose Project Folder";


            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = fbd.SelectedPath;
                TBK_path.Text = path;
                start_btn.IsEnabled = true;
            }
            
        }

        private void start_btn_Click(object sender, RoutedEventArgs e)
        {
            string[] files = Directory.GetFiles(path, "*.cs", SearchOption.TopDirectoryOnly);
            string[] files1 = Directory.GetFiles(path, "*.xaml", SearchOption.TopDirectoryOnly);
            string[] files2 = Directory.GetFiles(path, "*.java", SearchOption.AllDirectories);

            PB_1.Maximum = files.Length + files1.Length + files2.Length;
            PB_1.Minimum = 0;
            PB_1.Value = 0;

            int numOfLines = 0;

            foreach (string file in files)
            {
                PB_1.Value += 1;
                try
                {
                    numOfLines += System.IO.File.ReadAllLines(file).Length;
                    Console.WriteLine(numOfLines.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine(file);
            }

            foreach (string file in files1)
            {
                PB_1.Value += 1;
                try
                {
                    numOfLines += System.IO.File.ReadAllLines(file).Length;
                    Console.WriteLine(numOfLines.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine(file);
            }

            foreach (string file in files2)
            {
                PB_1.Value += 1;
                try
                {
                    numOfLines += System.IO.File.ReadAllLines(file).Length;
                    Console.WriteLine(numOfLines.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine(file);
            }

            MessageBox.Show(PB_1.Maximum + " Files\n" + numOfLines + " Lines");
            path = "";
            start_btn.IsEnabled = false;
        }
    }
}
