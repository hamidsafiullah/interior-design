import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { LoginData, RegisterData } from 'src/interfaces/auth.interfaces';


@Injectable({
    providedIn: 'root'
})
export class AuthService {
    private apiUrl = environment.baseUrl;

    constructor(private http: HttpClient) { }

    register(data: RegisterData): Observable<any> {
        return this.http.post(`${this.apiUrl}/register`, data);
    }

    login(data: LoginData): Observable<any> {
        return this.http.post(`${this.apiUrl}/login`, data);
    }
}
