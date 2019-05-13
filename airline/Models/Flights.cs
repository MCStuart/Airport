using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace Airline.Models
{
  public class Flight
  {
    private int _id;
    private string _status;
    private int _arrival;
    private int _departure;

  public Flight()
  {

  }

  public int GetId()
  {
    return _id;
  }

  public void SetId(int id)
  {
    _id = id;
  }

  public int GetArrival()
  {
    return _arrival;
  }

  public void SetArrival(int arrival)
  {
    _arrival = arrival;
  }

  public int GetDeparture()
  {
    return _departure;
  }

  public void SetDeparture(int departure)
  {
    _departure = departure;
  }

  public string GetStatus()
  {
    return _status;
  }

  public void SetStatus(string status)
  {
    _status = status;
  }

  public static Flight Find(int check)
  {
    Flight ret = new Flight();
    MySqlConnection conn = DB.Connection();
    conn.Open();
    MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"SELECT * FROM flights where id = "+check+";";
    MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
    rdr.Read();
    if(rdr.IsDBNull(0) == false)
    {
      ret.SetId(rdr.GetInt32(0));
      ret.SetStatus(rdr.GetString(1));
      ret.SetArrival(rdr.GetInt32(2));
      ret.SetDeparture(rdr.GetInt32(3));
    }
    conn.Close();
    if (conn != null)
    {
      conn.Dispose();
    }
    return ret;
  }

  public static List<Flight> GetAll()
  {
    List<Flight> allFlights = new List<Flight> {};
    MySqlConnection conn = DB.Connection();
    conn.Open();
    MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"SELECT * FROM flights;";
    MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
    while(rdr.Read())
    {
      Flight newFlight = new Flight();
      newFlight.SetId(rdr.GetInt32(0));
      newFlight.SetStatus(rdr.GetString(1));
      newFlight.SetArrival(rdr.GetInt32(2));
      newFlight.SetDeparture(rdr.GetInt32(3));
      allFlights.Add(newFlight);
    }
    conn.Close();
    if (conn != null)
    {
      conn.Dispose();
    }
    return allFlights;
  }

  public static void ClearAll()
  {
    MySqlConnection conn = DB.Connection();
    conn.Open();
    var cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"DELETE FROM flights;";
    cmd.ExecuteNonQuery();
    conn.Close();
    if (conn != null)
    {
     conn.Dispose();
    }
  }

//Arrival and Departure Board Goes Here Later

  public void Save()
  {
    MySqlConnection conn = DB.Connection();
    conn.Open();
    MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"INSERT INTO `flights` (`status`, `arrival`, `departure`) VALUES ('"+_status+"', '"+_arrival+"', '"+_departure+"');";
    cmd.ExecuteNonQuery();
    conn.Close();
    if (conn != null)
    {
      conn.Dispose();
    }
  }

  public void Update(string field, string change)
  {
    MySqlConnection conn = DB.Connection();
    conn.Open();
    MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"UPDATE `flights` SET `"+field+"` = '"+change+"' WHERE `flights`.`id` = "+_id+";";
    cmd.ExecuteNonQuery();
    conn.Close();
    if (conn != null)
    {
      conn.Dispose();
    }
  }

  public void Delete()
  {
    MySqlConnection conn = DB.Connection();
    conn.Open();
    MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    cmd.CommandText = @"delete from flights WHERE `flights`.`id` = "+_id+";";
    cmd.ExecuteNonQuery();
    conn.Close();
    if (conn != null)
    {
      conn.Dispose();
    }
  }

  }
}
