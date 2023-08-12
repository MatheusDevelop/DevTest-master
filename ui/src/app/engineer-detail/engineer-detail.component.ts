import { Component, OnInit } from '@angular/core';
import { EngineerModel } from '../models/engineer.model';
import { EngineerService } from '../services/engineer.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-engineer-detail',
  templateUrl: './engineer-detail.component.html',
  styleUrls: ['./engineer-detail.component.scss']
})
export class EngineerDetailComponent implements OnInit {

  private engineerId: number;

  public engineer: EngineerModel;

  constructor(
    private route: ActivatedRoute,
    private engineerService: EngineerService) {
      this.engineerId = route.snapshot.params.id;
    }

  ngOnInit() {
    this.engineerService.GetEngineer(this.engineerId).subscribe(e => this.engineer = e);
  }
}
