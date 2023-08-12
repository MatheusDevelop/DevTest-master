import { JobModel } from "./job.model";

export interface EngineerModel {
    name:string;
    engineerId:string;
    jobs:JobModel[]
}
  