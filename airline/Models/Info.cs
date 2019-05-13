using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace Airline.Models
{
  public class Info
  {
    private DateTime _time;
    private int _id;
    private int _city;
    private string _deparr;

    public Info()
    {
        _deparr = "departure";
    }

    public Info(string deparr)
    {
      _deparr = deparr;
    }

    public int GetId()
    {
      return _id;
    }

    public void SetId(int id)
    {
      _id = id;
    }

    public int GetCity()
    {
      return _city;
    }

    public void SetCity(int city)
    {
      _city = city;
    }

    public DateTime GetTime()
    {
      return _time;
    }

    public void SetTime(DateTime time)
    {
      _time = time;
    }

    public string GetDeparr()
    {
      return _deparr;
    }

    public void SetDeparr(string deparr)
    {
      _deparr = deparr;
    }

    public static Info Find(int check, string da)
    {
      Info ret = new Info();
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM "+da+" where id = "+check+";";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      rdr.Read();
      if(rdr.IsDBNull(0) == false)
      {
        ret.SetId(rdr.GetInt32(0));
        ret.SetCity(rdr.GetInt32(1));
        ret.SetTime(rdr.GetDateTime(2));
        ret.SetDeparr(da);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return ret;
    }

    public static List<Info> GetAll(string da)
    {
      List<Info> allInfo = new List<Info> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM "+da+";";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        Info newInfo = new Info();
        newInfo.SetId(rdr.GetInt32(0));
        newInfo.SetCity(rdr.GetInt32(1));
        newInfo.SetTime(rdr.GetDateTime(2));
        newInfo.SetDeparr(da);
        allInfo.Add(newInfo);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allInfo;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM departure;";
      cmd.ExecuteNonQuery();
      cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM arrival;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
       conn.Dispose();
      }
    }

    // public static List<City> GetDeparture(int num)
    // {
    //
    //   List<City> allItems = new List<City> {};
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"SELECT * FROM `cities` WHERE `` = "+num+" order by `hair` desc;";
    //   MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
    //   while(rdr.Read())
    //   {
    //     City newCity = new City();
    //     City.SetName(rdr.GetString(1));
    //     City.SetId(rdr.GetInt32(0));
    //     allItems.Add(newClient);
    //   }
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    //   return allItems;
    // }

    public void Save()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO `"+_deparr+"` (`city`,`time`) VALUES ('"+_city+"','"+_time+"');";
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
      cmd.CommandText = @"UPDATE `"+_deparr+"` SET `"+field+"` = '"+change+"' WHERE `id` = "+_id+";";
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
      cmd.CommandText = @"delete from "+_deparr+" WHERE `id` = "+_id+";";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}
