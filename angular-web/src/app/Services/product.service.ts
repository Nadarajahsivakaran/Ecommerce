import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiResponse } from '../Models/api-response.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private http:HttpClient) { }

  baseurl: string = 'https://localhost:7001/api/Product';

  getAllProducts(): Observable<ApiResponse> {
    return this.http.get<ApiResponse>(this.baseurl);
  }
}
