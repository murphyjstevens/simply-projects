import { Project } from '../models/project';

export const MOCK_PROJECTS = [
  new Project(1, 'Basement Flooring', 1, 4025.00, 'Redoing the flooring for the basement'),
  new Project(2, 'Kitchen Remodel', 1, 14000.20, 'Changing the layout for the kitchen and replacing the flooring'),
  new Project(3, 'Roof Repair', 1, 5000, 'Fix the roof leaks'),
  new Project(4, 'New Water Heater', 1, 4000, 'Get a new water heater after the current one goes bad')
];
