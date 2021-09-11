using System.Collections.Generic;
using Api.Models;

namespace Api.Mock {
  public class MockProjects {
    public static List<Project> GetMockProjects() {
      return new List<Project>() {
        new Project(1, "Basement Flooring", "Redoing the flooring for the basement"),
        new Project(2, "Kitchen Remodel", "Changing the layout for the kitchen and replacing the flooring"),
        new Project(3, "Roof Repair", "Fix the roof leaks"),
        new Project(4, "New Water Heater", "Get a new water heater after the current one goes bad")
      };
    }
  }
}