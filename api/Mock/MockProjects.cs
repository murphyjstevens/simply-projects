using System.Collections.Generic;
using Api.Models;

namespace Api.Mock {
  public class MockProjects {
    public static List<ProjectModel> GetMockProjects() {
      return new List<ProjectModel>() {
        new ProjectModel(1, "Basement Flooring", "Redoing the flooring for the basement"),
        new ProjectModel(2, "Kitchen Remodel", "Changing the layout for the kitchen and replacing the flooring"),
        new ProjectModel(3, "Roof Repair", "Fix the roof leaks"),
        new ProjectModel(4, "New Water Heater", "Get a new water heater after the current one goes bad")
      };
    }
  }
}