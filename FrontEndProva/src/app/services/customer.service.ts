import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {catchError} from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  configUrl = 'http://localhost:53611/api/';

  constructor(private http: HttpClient) { }

  getCustomers() {
    return this.http.get(this.configUrl+"Customers/GetAll");
  }
  getOneCustomer(id:any){
    return this.http.get(this.configUrl+`Customers?id=${id}`)
  }
  newCustomer(customer:any){
    console.log(customer);
    const headers = new HttpHeaders({'Content-Type': 'text/uri-list'});
    return this.http.post(this.configUrl+'Customers', JSON.stringify(customer), {headers: headers})
        .subscribe(res => {
        console.log(res);
    }, (err) => {
        console.log(err);
    });
  }
  editCustomer(customer:any){
    const headers = new HttpHeaders({'Content-Type': 'text/uri-list'});
    return this.http.put(this.configUrl+'Customers', JSON.stringify(customer), {headers: headers}).subscribe(res => {
        console.log(res);
    }, (err) => {
        console.log(err);
    });
  }
}
