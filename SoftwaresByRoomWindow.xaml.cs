//mrinal bedi
using System.Windows;

namespace SIS_data_Retriever
{
    /// <summary>
    /// Interaction logic for SoftwaresByRoomWindow.xaml
    /// </summary>
    public partial class SoftwaresByRoomWindow : Window
    {
        ViewModel vm = new ViewModel();
        public SoftwaresByRoomWindow(ViewModel vm)
        {
            InitializeComponent();
            this.vm = vm;
            DataContext = vm;
        }
    }
}
