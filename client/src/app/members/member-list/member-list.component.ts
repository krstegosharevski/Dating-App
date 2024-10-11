import { Component, OnInit } from '@angular/core';
import { Observable, take } from 'rxjs';
import { Member } from 'src/app/_models/member';
import { Pagination } from 'src/app/_models/pagination';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { MembersService } from 'src/app/_services/members.service';
import { UserParams } from 'src/app/_models/userParams';
import { AccountService } from 'src/app/_services/account.service';
import { User } from 'src/app/_models/user';

@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.css'],
})
export class MemberListComponent implements OnInit {
  //members$: Observable<Member[]> | undefined;
  members: Member[] = [];
  pagination: Pagination | undefined;
  userPrams: UserParams | undefined;
  genderList = [{value: 'male', display: 'Males'}, {value: 'female', display: 'Females'}]
   

  constructor(private memberService: MembersService) {
    this.userPrams = this.memberService.getUserParams();
   }

  ngOnInit(): void {
    //this.members$ = this.memberService.getMembers();
    this.loadMembers();
  }

  loadMembers(){
    if(this.userPrams){
      this.memberService.setUserParams(this.userPrams);
      this.memberService.getMembers(this.userPrams).subscribe({
        next: response => {
          if(response.result && response.pagination){
            this.members = response.result;
            this.pagination = response.pagination;
          }
        }
      })
    }
   
  }

  resetFilters(){
      this.userPrams = this.memberService.resetUserParams();
      this.loadMembers();
  }

  pageChanged(event: any){
    if(this.userPrams && this.userPrams?.pageNumber !== event.page){
      this.userPrams.pageNumber = event.page;
      this.memberService.setUserParams(this.userPrams);
      this.loadMembers(); 
    }
  }

}
