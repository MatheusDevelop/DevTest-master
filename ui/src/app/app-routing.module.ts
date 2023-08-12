import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { JobComponent } from './job/job.component';
import { HomeComponent } from './home/home.component';
import { JobDetailComponent } from './job-detail/job-detail.component';
import { EngineerComponent } from './engineer/engineer.component';
import { EngineerDetailComponent } from './engineer-detail/engineer-detail.component';


const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'home', component: HomeComponent },
  { path: 'jobs', component: JobComponent },
  { path: 'engineers', component: EngineerComponent },
  { path: 'job/:id', component: JobDetailComponent },
  { path: 'engineer/:id', component: EngineerDetailComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
