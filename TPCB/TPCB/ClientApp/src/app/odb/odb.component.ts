import { Component, OnInit, Input } from '@angular/core';
import { Discussion} from '../Discussion';
import { OdbService } from '../Services/odb.service';
import { formatDate } from '@angular/common';
import { AltDiscussion } from '../AltDiscussion';

@Component({
  selector: 'app-odb',
  templateUrl: './odb.component.html',
  styleUrls: ['./odb.component.css']
})
export class ODBComponent implements OnInit {

 
  allcomments: AltDiscussion[] = null;
  idpointer: number = null;
  admincheck: string = '';

  deletedata: AltDiscussion = {
    CommentId: null,
    Username: '',
    Comment: '',
    ComDate:'',
  };



  
  userdata: Discussion = {
    Username: 'Anonymous',
    Comment: '',
    ComDate: formatDate(new Date(), 'MM-dd-yyyy', 'en'),
  };

  curleng: number = this.userdata.Comment.length;


  constructor(private odbService: OdbService) { }


  postThisComment(): void {
    this.odbService.postComment(this.userdata);
    location.reload();
  }

  deleteThisComment(): void {
    this.odbService.deleteComment(this.idpointer)
    location.reload();
  }
  

  ngOnInit() {
    this.odbService.getComments().then(response => this.allcomments = response);
    this.curleng = 0;
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error);
    return Promise.reject(error.message || error);
  }



}
