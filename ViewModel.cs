//mrinal bedi
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SIS_data_Retriever
{
    public class ViewModel : INotifyPropertyChanged
    {
        public BindingList<Software> Softwares { get; set; }
        public BindingList<Room> Rooms { get; set; }
        public BindingList<RoomSoftware> RoomSoftwares { get; set; }
        private Room selectedRoom;
        public Room SelectedRoom { get => selectedRoom; set { selectedRoom = value; onChange(); } }

        private Software selectedSoftware;
        public Software SelectedSoftware { get => selectedSoftware; set { selectedSoftware = value; onChange(); } }

        public ViewModel()
        {
            Softwares = new BindingList<Software>(Database.GetInstance().ReadSoftwares());
        }

        public void ShowRooms(Guid id)
        {
            Rooms = new BindingList<Room>(Database.GetInstance().ReadRoom(id));
        }

        public void ShowSoftwaresbyRoom(int id)
        {
            RoomSoftwares = new BindingList<RoomSoftware>(Database.GetInstance().ReadSoftwaresByRoom(id));
        }

        #region propertychanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void onChange([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
