import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MOCK_PROJECTS } from '../mocks/mock-projects';
import { Project } from '../models/project';

@Component({
  selector: 'app-project',
  templateUrl: './project.component.html',
  styleUrls: ['./project.component.css']
})
export class ProjectComponent implements OnInit {
  project: Project;

  constructor(private route: ActivatedRoute,
              private router: Router) { }

  ngOnInit() {
    this.getProject();
  }

  private getProject() {
    const id = +this.route.snapshot.paramMap.get('id');
    this.project = MOCK_PROJECTS.find(x => x.id === id);
  }

  back() {
    this.router.navigate(['/']);
  }

  save() {
    this.router.navigate(['/']);
  }

}
