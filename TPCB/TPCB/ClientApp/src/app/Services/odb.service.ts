import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { Discussion } from '../Discussion';
import { AltDiscussion } from '../AltDiscussion';
import { HttpClientModule } from '@angular/common/http';
import { MessageService } from './message.service';
import { promise } from 'protractor';
@Injectable({
  providedIn: 'root'
})
export class OdbService {

  url = 'https://localhost:44311/TPCB/Discussion';  // URL to web api
  newurl = '';
  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' }) //send the object as JSON
  };

  constructor(
    private httpBus: HttpClient
  ) { }
  //get existing comments
  getComments(): Promise<AltDiscussion[]>{
    return this.httpBus.get<AltDiscussion[]>(this.url).toPromise();
  }

  //Post a new comment
  postComment(pos: Discussion): Promise<Discussion>{
    return this.httpBus.post<Discussion>("https://localhost:44311/TPCB/Discussion", pos, this.httpOptions).toPromise();
  }

  //Delete existing comment by id
  deleteComment(dis: number): Promise<AltDiscussion> {
    this.newurl = this.url + "/" + dis;
    return this.httpBus.delete<AltDiscussion>(this.newurl).toPromise();
  }
}
