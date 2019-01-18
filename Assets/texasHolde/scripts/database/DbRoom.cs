
using System.Data;
using MySql.Data.MySqlClient;
using System;


public class DbRoom : DataBase
{

    public DbRoom() : base()
    { }

    public void CreateRoom(Room room)//insert users data in to the data base
    {
        string query = "INSERT INTO `room`(`amountPlayers`, `minbet`, `maxbet`) VALUES (@AmountPlayers,@minBet,@maxBet)";

        using (MySqlCommand cmd = new MySqlCommand(query))
        {
            //cmd.Parameters.AddWithValue("@roomId", room.id);
            cmd.Parameters.AddWithValue("@AmountPlayers", room.amountOfPlayers);
            cmd.Parameters.AddWithValue("@minBet", room.minBet);
            cmd.Parameters.AddWithValue("@maxBet", room.minBet);

            base.ExecuteSimpleQuery(cmd);
        }

    }//create a room in the data base



    public Room getRoomInfo() {

        DataSet ds = new DataSet();
        string query = "SELECT * FROM room";


        using (MySqlCommand cmd = new MySqlCommand(query))
        {
            ds = GetMultipleQuary(cmd);
        }
        DataTable dt = new DataTable();
        try
        {
            dt = ds.Tables[0];

        }
        catch { }

         
        if (dt.Rows.Count != 0)
        {
            Room room = new Room();
            DataRow dr = dt.Rows[0];
            room.id = int.Parse(dr["roomid"].ToString());
            room.amountOfPlayers = int.Parse(dr["amountPlayers"].ToString());
            room.maxBet = int.Parse(dr["maxbet"].ToString());
            room.minBet = int.Parse(dr["minbet"].ToString());
            return room;

        }

        return null;

    }

    public void UpdateRoom(Room room)//update users data in to the data base
    {
        string query = "UPDATE `room` SET `amountPlayers`=@amountPlayers,`minbet`=@minbet,`maxbet`=@maxbet WHERE `roomid`=@roomId";


        using (MySqlCommand cmd = new MySqlCommand(query))
        {
            cmd.Parameters.AddWithValue("@roomId", room.id);
            cmd.Parameters.AddWithValue("@amountPlayers", room.amountOfPlayers);
            cmd.Parameters.AddWithValue("@minbet", room.minBet);
            cmd.Parameters.AddWithValue("@maxbet", room.maxBet);

            base.ExecuteSimpleQuery(cmd);
        }

    }

    public void deleteRoom(Room room)//delete player info from the connection table
    {
        string query = "DELETE FROM `room` WHERE roomid=@roomId";
       
        using (MySqlCommand cmd = new MySqlCommand(query))
        {
            cmd.Parameters.AddWithValue("@roomId", room.id);
            base.ExecuteSimpleQuery(cmd);
        }

    }
}