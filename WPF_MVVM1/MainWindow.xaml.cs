using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_MVVM1.Code;

namespace WPF_MVVM1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        SongViewModel SVM = new SongViewModel();
        public MainWindow()
        {
            this.SVM.Song = new Song { ArtistName = "1", SongTitle = "2" };
            InitializeComponent();
            this.DataContext = this.SVM;
        }

        private void textBlock1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var s = this.SVM.ArtistName;
            var i = Convert.ToInt32(s);
            i++;
            this.SVM.ArtistName = i.ToString();
        }
    }
}
