import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Employee } from '../_models/employee';
import { Observable } from 'rxjs';
import { StatsByMonth } from '../_models/StatsByMonth';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  baseUrl = environment.apiUrl;

  constructor(public http: HttpClient) { }

  getEmployees(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.baseUrl + 'employees/GetEmployees');
  }

  getAvailableEmployees(timesDates): Observable<Employee[]> {
    return this.http.post<Employee[]>(this.baseUrl + 'employees/GetAvailableEmployees/', timesDates);
  }

  getCarStatisticsByMonth(month: number): Observable<StatsByMonth[]> {
    return this.http.get<StatsByMonth[]>(this.baseUrl + 'employees/GetEmplStatsByMonth/' + month);
  }
}
