import { Injectable, EventEmitter } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from "@aspnet/signalr";
import { Message } from '../../shared/models/message';

@Injectable({
  providedIn: 'root'
})
export class SignalrService {

  private hubConnection: HubConnection;

  signalReceived = new EventEmitter<Message>();

  constructor() {
    this.buildConnection();
    this.startConnection();
  }

  public buildConnection = () => {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl("http://localhost:")
      .build();
  }

  public startConnection = () => {
    this.hubConnection.start()
      .then(() => {
        console.log("SignalR hub connection started.");
        this.registerSignalEvent();
      })
      .catch(err => {
        console.log("Failed to start SignalR hub connection!" + err);

        setTimeout(function () {
          this.startConnection();
        }, 3000);
      });
  }

  public registerSignalEvent() {
    this.hubConnection.on("Notify", (data: Message) => {
      this.signalReceived.emit(data);
    });
  }

}
