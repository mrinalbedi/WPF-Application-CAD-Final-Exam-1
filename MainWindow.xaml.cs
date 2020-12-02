//mrinal bedi
using System.Windows;
using System.Windows.Controls;

namespace SIS_data_Retriever
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel vm = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void Softwares_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vm.ShowRooms(vm.SelectedSoftware.UniqueID);
            RoomsWindow ew = new RoomsWindow(vm);
            ew.Show();
        }
    }
}
