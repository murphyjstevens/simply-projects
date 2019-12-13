export class Project {
  id: number;
  name: string;
  userId: number;
  totalCost: number;

  constructor(id: number, name: string, userId: number, totalCost: number) {
    this.id = id;
    this.name = name;
    this.userId = userId;
    this.totalCost = totalCost;
  }
}
