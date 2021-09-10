using System.Collections.Generic;
using Api.Models;

namespace Api.Mock {
  public class MockMaterials {
    public static List<MaterialModel> GetMockMaterials() {
      return new List<MaterialModel>() {
        new MaterialModel(id: 1, projectId: 1, name: "Planks", cost: 50.0M, quantity: 250 ),
        new MaterialModel(id: 2, projectId: 1, name: "Underlayment", cost: 45.00M, quantity: 10),
        new MaterialModel(id: 3, projectId: 1, name: "Floor Transition", cost: 10.99M, quantity: 5)
      };
    }
  }
}