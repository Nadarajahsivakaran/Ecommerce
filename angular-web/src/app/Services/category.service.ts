import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from '../Models/api-response.model';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  constructor(private http: HttpClient) {}

  baseurl: string = 'https://localhost:7001/api/Category';

  getAllCategories(): Observable<ApiResponse> {
    return this.http.get<ApiResponse>(this.baseurl);
  }
}
