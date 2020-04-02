import { Component, OnInit, Input, SimpleChange, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-info-popup',
  templateUrl: './info-popup.component.html',
  styleUrls: ['./info-popup.component.scss']
})
export class InfoPopupComponent implements OnInit {

  @Input() content: string;
  @Input() active: boolean = false;
  @Output() updateActive = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  handleOk(): void {
    console.log('Button ok clicked!');
    this.updateActive.emit(false);
  }

  handleCancel(): void {
    console.log('Button cancel clicked!');
    this.updateActive.emit(false);
  }

}
