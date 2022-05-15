import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ISpotter } from '../shared/models/spotter';
import { Observable, from, throwError } from 'rxjs';
import { catchError, retry, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class SpotterService {


  baseUrl = "https://localhost:44381/"

  constructor(private http: HttpClient) {

  }
  handleError(error: Response) {
    return Observable.throw(error.statusText);
  }
  public getAllByGet<t>(actionUrl: any, param?: any): Observable<t> {
    const endpointUrl: string = this.baseUrl + actionUrl;
    return this.http.get<t>(endpointUrl, { params: param })
      .pipe(
        map((response: t) => { return response; }),
        catchError(this.handleError)
      )
    //return this.http.get<t>(endpointUrl)
  }
  public getAllByGetWithJson<T>(actionurl: any, param?: any): Observable<T> {
    return this.http.get<T>(actionurl + JSON.stringify(param))
      .pipe(
        map((response: T) => { return response; }),
        catchError(this.handleError)
      );

  }
  public add<T>(actionurl: any, object: any): Observable<T> {
    const endpointUrl: string = actionurl;
    return this.http.post<T>(endpointUrl, object)
      .pipe(
        map((response: T) => { return response; }),
        catchError(this.handleError)
      );
  }
}

