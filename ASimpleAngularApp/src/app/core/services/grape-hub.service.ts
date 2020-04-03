import { Injectable, EventEmitter } from '@angular/core';
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { Grape } from 'src/app/shared/models/grape';
import { NotificationInfo } from 'src/app/shared/models/notification-info';

@Injectable({
  providedIn: 'root'
})
export class GrapeHubService {

  private hubConnection: HubConnection;

  grapesReceived = new EventEmitter<Grape[]>();

  constructor() {
    this.buildConnection();
    this.startConnection();
  }

  public buildConnection() {
    this.hubConnection = new HubConnectionBuilder()
      .withUrl("http://localhost:60956/grapeHub")
      .build();
  }

  public startConnection() {
    this.hubConnection.start()
      .then(() => {
        console.log("grapeHub connection started.");
        this.registerSignalEvent();
      })
      .catch(err => {
        console.log("Failed to start grapeHub connection!" + err);

        setTimeout(function () {
          this.startConnection();
        }, 3000);
      });
  }

  public registerSignalEvent() {
    this.hubConnection.on("GrapesUpdate", (data: Object) => {
      const x = JSON.stringify(data);
      console.log('grapes received from hub' + x);
      let o: NotificationInfo = JSON.parse(x);
      console.log('grapes message is: ' + o.message);
      this.grapesReceived.emit(o.message);
    });
  }
}
