//Mrinal bedi
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SIS_data_Retriever
{
    public class Database
    {
        private const string CONN_STRING
           = "Server=.\\SQLEXPRESS;Database=SIS;Trusted_Connection=True;";

        private const string READ_SOFTWARES_COMMAND = "Select * from Software ";

        private const string READ_ROOMS_COMMAND = "select * from Software s inner join labsoftware ls on " +
            " s.uniqueId=ls.softwareUniqueId where softwareUniqueId=@uniqueid ";

        private const string READ_SOFTWARES_BY_ROOM_COMMAND = "Select * from labsoftware ls inner join Room r " +
            "on r.id=ls.roomid where roomid=@roomid";

        private static Database db;

        private readonly SqlConnection conn;

        //getting instance of database
        public static Database GetInstance()
        {
            if (db == null)
                db = new Database();
            return db;
        }

        //creating connection to database
        private Database()
        {
            conn = new SqlConnection(CONN_STRING);
            conn.Open();
        }


        public List<Software> ReadSoftwares()
        {
            var Softwares = new List<Software>();
            var cmd = new SqlCommand(READ_SOFTWARES_COMMAND, conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var ui = reader.GetOrdinal("UniqueID");
                var p = reader.GetOrdinal("Product");
                Softwares.Add(new Software
                {
                    UniqueID = reader.GetGuid(ui),
                    Product = reader.IsDBNull(p) ? null : reader.GetString(p)
                });
            }
            reader.Close();
            return Softwares;
        }

        public List<Room> ReadRoom(Guid id)
        {
            var Rooms = new List<Room>();
            var cmd = new SqlCommand(READ_ROOMS_COMMAND, conn);
            cmd.Parameters.AddWithValue("@uniqueid", id);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var r = reader.GetOrdinal("RoomId");
                var Product = reader.GetOrdinal("Product");
                Rooms.Add(new Room
                {
                    RoomId = reader.GetInt32(r),
                    Product = reader.IsDBNull(Product) ? null : reader.GetString(Product)
                });
            }
            reader.Close();
            return Rooms;
        }

        public List<RoomSoftware> ReadSoftwaresByRoom(int roomid)
        {
            var RoomSoftwares = new List<RoomSoftware>();
            var cmd = new SqlCommand(READ_SOFTWARES_BY_ROOM_COMMAND, conn);
            cmd.Parameters.AddWithValue("@roomid", roomid);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var ui = reader.GetOrdinal("SoftwareUniqueID");
                var r = reader.GetOrdinal("Roomid");
                var n = reader.GetOrdinal("Number");

                RoomSoftwares.Add(new RoomSoftware
                {
                    SoftwareUniqueId = reader.GetGuid(ui),
                    Roomid = reader.GetInt32(r),
                    Number = reader.IsDBNull(n) ? null : reader.GetString(n)

                });
            }
            reader.Close();
            return RoomSoftwares;
        }
    }
}
