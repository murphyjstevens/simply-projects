using System.Collections.Generic;
using Api.Models;

namespace Api.Mock {
  public class MockProjects {
    public static List<ProjectModel> GetMockProjects() {
      return new List<ProjectModel>() {
        new ProjectModel(1, "Basement Flooring", 1, 4025.00m, "Redoing the flooring for the basement"),
        new ProjectModel(2, "Kitchen Remodel", 1, 14000.20m, "Changing the layout for the kitchen and replacing the flooring"),
        new ProjectModel(3, "Roof Repair", 1, 5000, "Fix the roof leaks"),
        new ProjectModel(4, "New Water Heater", 1, 4000, "Get a new water heater after the current one goes bad")
      };
    }
  }
}