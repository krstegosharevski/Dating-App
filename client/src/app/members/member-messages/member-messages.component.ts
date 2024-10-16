import { ChangeDetectionStrategy, Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Message } from 'src/app/_models/message';
import { MessageService } from 'src/app/_services/message.service';

@Component({
  changeDetection: ChangeDetectionStrategy.OnPush,
  selector: 'app-member-messages',
  templateUrl: './member-messages.component.html',
  styleUrls: ['./member-messages.component.css']
})
export class MemberMessagesComponent implements OnInit {
  
  @ViewChild('messageForm') messageForm?: NgForm
  @Input() username?: string;
  messageContent = '';
  //@ViewChild('myDiv') private myDiv?: ElementRef;


  constructor(public messagesService: MessageService) { }

  ngOnInit(): void {
  }

  // ngAfterViewInit() {
  //   this.scrollToBottom();
  // }

  // private scrollToBottom(): void {
  //   this.myDiv!.nativeElement.scrollTop = this.myDiv!.nativeElement.scrollHeight;
  // }

  sendMessage(){
    if(!this.username) return;
    this.messagesService.sendMessage(this.username, this.messageContent).then(() => {
      this.messageForm?.reset();
    })
  }

 
}
