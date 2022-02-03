import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PersonPhoneService {
  
  private endpoint: string = "PersonPhone";
  
  constructor(private http: HttpClient) { }

  GetData(callback = function(returnObject){}){
    callback(this.http.get(`${environment.apiUrl}/${this.endpoint}`));
  }

  PostData(object, callback = function (returnObject) { }) {
    callback(this.http.post(`${environment.apiUrl}/${this.endpoint}`, object));
  }

  GetObject(phoneNumber, callback = function (returnObject) { }) {
    callback(this.http.get(`${environment.apiUrl}/${this.endpoint}/${phoneNumber}`));
  }

  PutData(object, callback = function (returnObject) { }) {
    callback(this.http.put(`${environment.apiUrl}/${this.endpoint}`, object));
  }

  DeleteData(phoneNumber, callback = function (returnObject) { }) {
    callback(this.http.delete(`${environment.apiUrl}/${this.endpoint}/${phoneNumber}`));
  }
}
