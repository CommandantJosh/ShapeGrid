import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpErrorResponse, HttpResponse } from '@angular/common/http';

import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Triangle } from './Triangle';
import { TriangleResponse } from './TriangleResponse';

@Injectable({
  providedIn: 'root'
})
export class TriangleService {

  constructor(private http: HttpClient) { }

  GetTriangleCoordinates(triangle : Triangle){
    return this.http.get<TriangleResponse>("https://localhost:7115/Shape/Triangle/coordinates/"+ triangle.height + "/" + triangle.width + "/" + triangle.row + "/" + triangle.column, {})
    .pipe(
      catchError(this.handleError)
    );
  }
  GetTriangleLocation(triangle : Triangle){
    return this.http.get<TriangleResponse>("https://localhost:7115/Shape/Triangle/location/"+ triangle.height + "/" + triangle.width + "/" + triangle.vertex1x + "," + triangle.vertex1y + "," + triangle.vertex2x 
                          + "," + triangle.vertex2y+ "," + triangle.vertex3x + "," + triangle.vertex3y, {})
    .pipe(
      catchError(this.handleError)
    );
  }
  
  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      console.error(
        `Backend returned code ${error.status}, body was: `, error.error);
    }
    // Return an observable with a user-facing error message.
    return throwError(
      'Something bad happened; please try again later.');
  }

}
