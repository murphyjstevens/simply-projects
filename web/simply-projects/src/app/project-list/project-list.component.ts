import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DialogService } from 'primeng/dynamicdialog';

import { Project } from '../models/project';
import { ProjectService } from '../services/project.service';
import { AddProjectComponent } from '../add-project/add-project.component';

@Component({
  selector: 'app-project-list',
  templateUrl: './project-list.component.html',
  styleUrls: ['./project-list.component.css'],
  providers: [DialogService]
})
export class ProjectListComponent implements OnInit {
  projects: Project[];

  constructor(
    public dialogService: DialogService,
    private projectService: ProjectService,
    private router: Router) { }

  ngOnInit() {
    this.getProjects();
  }

  private getProjects() {
    this.projectService.getMockProjects().subscribe(projects => this.projects = projects);
    console.log('Loaded mock projects');
  }

  openAddProjectDialog() {
    const ref = this.dialogService.open(AddProjectComponent, {
      header: 'Add Project',
      width: '50%'
    });

    ref.onClose.subscribe(result => {
      if (result.didAddProject) {
        this.getProjects();
      }
    });
  }
}
