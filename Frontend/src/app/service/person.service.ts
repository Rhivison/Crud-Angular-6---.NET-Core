import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  private endpoint: string = "Person";

  constructor(
    private http: HttpClient
  ) { }

  GetData(callback = function(returnObject){}){
    callback(this.http.get(`${environment.apiUrl}/${this.endpoint}`));
  }
}
