import { Injectable } from '@angular/core';
import { MOCK_PROJECTS } from '../mocks/mock-projects';
import { Observable, of } from 'rxjs';
import { Project } from '../models/project';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {
  constructor(private http: HttpClient) { }

  private endpoint = 'https://localhost:5001/Projects';
  getProjects(): Observable<Project[]> {
    return this.http.get<Project[]>(this.endpoint);
  }
}
