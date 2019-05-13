using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace Airline.Models
{
  public class City
  {
    private string _name;
    private int _id;

    public City()
    {

    }

    public City(string name)
    {
      _name = name;
    }

    public int GetId()
    {
      return _id;
    }

    public void SetId(int id)
    {
      _id = id;
    }

    public string GetName()
    {
      return _name;
    }

    public void SetName(string name)
    {
      _name = name;
    }


    public static City Find(int check)
    {
      City ret = new City();
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM cities where id = "+check+";";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      rdr.Read();
      if(rdr.IsDBNull(0) == false)
      {
        ret.SetId(rdr.GetInt32(0));
        ret.SetName(rdr.GetString(1));
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return ret;
    }

    public static List<City> GetAll()
    {
      List<City> allCities = new List<City> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM cities;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        City newCity = new City();
        newCity.SetName(rdr.GetString(1));
        newCity.SetId(rdr.GetInt32(0));
        allCities.Add(newCity);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allCities;
    }

    public static void ClearAll()
    {
      MySqlConnection conn = DB.Connection();
      conn.Open();
      var cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"DELETE FROM cities;";
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
      cmd.CommandText = @"INSERT INTO `cities` (`name`) VALUES ('"+_name+"');";
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
      cmd.CommandText = @"UPDATE `cities` SET `"+field+"` = '"+change+"' WHERE `cities`.`id` = "+_id+";";
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
      cmd.CommandText = @"delete from cities WHERE `cities`.`id` = "+_id+";";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }
  }
}
