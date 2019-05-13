using Microsoft.VisualStudio.TestTools.UnitTesting;
using Airline.Models;
using System.Collections.Generic;
using System;

namespace Airline.Tests
{
  [TestClass]
  public class FlightTests : IDisposable
  {

    public void Dispose()
    {

      Flight.ClearAll();
    }

    public FlightTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=airline_test;";
    }
    [TestMethod]
    public void Flight_ReturnsEmpty_0()
    {
      // Arrange
      // Act
      List<Flight> allFlights = Flight.GetAll();
      // Assert
      Assert.AreEqual(0, allFlights.Count);
    }

    [TestMethod]
    public void Flight_ReturnsNotEmpty_1()
    {
      // Arrange
      Flight newFlight = new Flight();
      newFlight.Save();
      // Act
      List<Flight> allFlights = Flight.GetAll();
      // Assert
      Assert.AreEqual(1, allFlights.Count);
    }

    [TestMethod]
    public void Flight_FindFlightId_Flight()
    {
      // Arrange
      Flight newFlight = new Flight();
      newFlight.Save();
      List<Flight> allFlights = Flight.GetAll();
      // Act
      // Assert
      int testFlight = Flight.Find(allFlights[0].GetId()).GetId();
      Assert.AreEqual(allFlights[0].GetId(), testFlight);
    }

    // [TestMethod]
    // public void Flight_FindFlightId_Flight()
    // {
    //   // Arrange
    //   Flight newFlight = new Flight();
    //   newFlight.Save();
    //   List<Flight> allFlights = Flight.GetAll();
    //   // Act
    //   // Assert
    //   int testFlight = Flight.Find(allFlights[0].GetId()).GetId();
    //   Assert.AreEqual(allFlights[0].GetId(), testFlight);
    // }
  }
}
