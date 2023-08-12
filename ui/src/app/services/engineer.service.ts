import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { EngineerModel } from '../models/engineer.model';

@Injectable({
  providedIn: 'root'
})
export class EngineerService {

  constructor(private httpClient: HttpClient) { }

  public GetEngineers(): Observable<EngineerModel[]> {
    return this.httpClient.get<EngineerModel[]>('http://localhost:63235/engineer');
  }
  public GetEngineer(engineerId: number): Observable<EngineerModel> {
    return this.httpClient.get<EngineerModel>(`http://localhost:63235/engineer/${engineerId}`);
  }
  public CreateEngineer(engineer: EngineerModel): Promise<object> {
    return this.httpClient.post('http://localhost:63235/engineer', engineer).toPromise();
  }
}
