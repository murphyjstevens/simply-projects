export class Project {
  id: number;
  name: string;
  userId: number;
  totalCost: number;
  description: string;

  constructor(id: number, name: string, userId: number, totalCost: number, description: string) {
    this.id = id;
    this.name = name;
    this.userId = userId;
    this.totalCost = totalCost;
    this.description = description;
  }
}
