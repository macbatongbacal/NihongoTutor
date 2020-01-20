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
using Path = System.IO.Path;

namespace NihongoTutor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private String preSourcePath;
        private string file;
        private string[] lstLetters;
        public MainWindow()
        {
            InitializeComponent();
            InitialData();
            lstLetters = new string[] { "a", "i", "u", "e", "o",
                                        "ka", "ki", "ku", "ke", "ko",
                                        "ga", "gi", "gu", "ge", "go",
                                        "sa", "shi", "su", "se", "so",
                                        "za", "ji", "zu", "ze", "zo",
                                        "ta", "chi", "tsu", "te", "to",
                                        "da", "ji", "zu", "de", "do",
                                        "na", "ni", "nu", "ne", "no",
                                        "ha", "hi", "hu", "he", "ho",
                                        "ba", "bi", "bu", "be", "bo",
                                        "pa", "pi", "pu", "pe", "po",
                                        "ma", "mi", "mu", "me", "mo",
                                        "ya", "yu", "yo",
                                        "ra", "ri", "ru", "re", "ro",
                                        "wa","wo"};
        }

        private void InitialData()
        {
            if (rbtn1.IsChecked == true) {
                preSourcePath = "..\\..\\Hiragana";
            }
            else
            {
                preSourcePath = "..\\..\\Katakana";
            }
            getrandomfile2(preSourcePath);
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            InitialData();
        }
        private string getrandomfile2(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                var extensions = new string[] { ".png", ".jpg", ".gif" };
                try
                {
                    path = Path.GetFullPath(path);
                    var di = new DirectoryInfo(path);
                    var rgFiles = di.GetFiles("*.*").Where(f => extensions.Contains(f.Extension.ToLower()));
                    Random R = new Random();
                    file = rgFiles.ElementAt(R.Next(0, rgFiles.Count())).FullName;
                    result.Source = new BitmapImage(new Uri(file));
                }
                // probably should only catch specific exceptions
                // throwable by the above methods.
                catch { }
            }
            return file;
        }
    }
}
