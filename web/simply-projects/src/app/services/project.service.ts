import { Injectable } from '@angular/core';
import { MOCK_PROJECTS } from '../mocks/mock-projects';
import { Observable, of } from 'rxjs';
import { Project } from '../models/project';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {
  constructor() { }

  getMockProjects(): Observable<Project[]> {
    return of(MOCK_PROJECTS.map(project =>
      new Project(project.id, project.name, project.userId, project.totalCost, project.description)));
  }
}
