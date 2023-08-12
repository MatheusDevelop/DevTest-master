import { Component, OnInit } from '@angular/core';
import { EngineerModel } from '../models/engineer.model';
import { NgForm } from '@angular/forms';
import { EngineerService } from '../services/engineer.service';

@Component({
  selector: 'app-engineer',
  templateUrl: './engineer.component.html',
  styleUrls: ['./engineer.component.scss']
})
export class EngineerComponent implements OnInit {
  public engineers: EngineerModel[] = [];
  constructor(
    private engineerService: EngineerService,
  ) { }
  public newEngineer: EngineerModel = {
    name:null,
    engineerId:null,
    jobs:null
  };
  ngOnInit(): void {
    this.engineerService.GetEngineers().subscribe(engineers => this.engineers = engineers);
  }
  public createEngineer(form: NgForm): void {
    if (form.invalid) {
      alert('form is not valid');
    } else {
      this.engineerService.CreateEngineer(this.newEngineer).then(() => {
        this.engineerService.GetEngineers().subscribe(engineers => this.engineers = engineers);
      });
    }
  }
}
