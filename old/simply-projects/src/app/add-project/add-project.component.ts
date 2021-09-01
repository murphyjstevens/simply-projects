import { Component, OnInit } from '@angular/core';
import { DynamicDialogRef } from 'primeng/dynamicdialog';

@Component({
  selector: 'app-add-project',
  templateUrl: './add-project.component.html',
  styleUrls: ['./add-project.component.css']
})
export class AddProjectComponent implements OnInit {
  name: string;
  totalCost: number;
  description: string;

  constructor(public ref: DynamicDialogRef) { }

  ngOnInit() {
  }

  save() {
    this.ref.close({ didAddProject: true });
  }

  close() {
    this.ref.close({ didAddProject: false });
  }
}
