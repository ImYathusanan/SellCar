import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class VehileService {

  constructor(private http: HttpClient) { }

  public getMakes() {
    return this.http.get('https://localhost:44319/api/makes');
  }

  public getFeatures() {
    return this.http.get('https://localhost:44319/api/features');
  }

}
