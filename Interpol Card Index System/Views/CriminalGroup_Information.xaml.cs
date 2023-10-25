using Interpol_Card_Index_System.Models;
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

namespace Interpol_Card_Index_System.Views
{
    /// <summary>
    /// Логика взаимодействия для CriminalGroup_Information.xaml
    /// </summary>
    public partial class CriminalGroup_Information : Window
    {
        public CriminalGroup_Information(CriminalGroup crimeGroup)
        {
            InitializeComponent();
            this.DataContext = crimeGroup;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
