import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { Project } from '../models/project';
import { MOCK_PROJECTS } from '../mocks/mock-projects';
import { ProjectService } from '../services/project.service';

@Component({
  selector: 'app-project-list',
  templateUrl: './project-list.component.html',
  styleUrls: ['./project-list.component.css']
})
export class ProjectListComponent implements OnInit {
  projects: Project[];

  constructor(
    private projectService: ProjectService,
    private router: Router) { }

  ngOnInit() {
    this.getProjects();
    console.log(this.projects[0].name);
  }

  private getProjects() {
    this.projectService.getMockProjects().subscribe(projects => this.projects = projects);
  }

}
