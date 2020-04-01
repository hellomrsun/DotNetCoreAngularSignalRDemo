import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Grape } from '../models/grape';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GrapeService {

  constructor(private httpClient: HttpClient) { }

  public GetAllGrapes(): Observable<Grape[]> {
    const url = environment.api + '/api/v1/Grapes/Grapes';
    return this.httpClient.get<Grape[]>(url);
  }

  public Save(grape: Grape): Observable<Object> {
    const url = environment.api + '/api/v1/Grapes/Add';
    return this.httpClient.put(url, grape);
  }

  public Delete(id: number) {
    console.log('delete');
    const url = environment.api + '/api/v1/Grapes/Delete/' + id;

    return this.httpClient.delete(url);
  }

}
