//mrinal bedi
using System.Windows;
using System.Windows.Controls;

namespace SIS_data_Retriever
{
    /// <summary>
    /// Interaction logic for RoomsWindow.xaml
    /// </summary>
    public partial class RoomsWindow : Window
    {
        ViewModel vm = new ViewModel();
        public RoomsWindow(ViewModel vm)
        {
            InitializeComponent();
            this.vm = vm;
            DataContext = vm;

        }

        private void rooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vm.ShowSoftwaresbyRoom(vm.SelectedRoom.RoomId);
            SoftwaresByRoomWindow sw = new SoftwaresByRoomWindow(vm);
            sw.Show();
        }
    }
}
