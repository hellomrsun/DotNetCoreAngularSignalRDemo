import { Grape } from './grape';
import { MessageType } from './MessageType';

export class NotificationInfo {
  messageType: MessageType;
  dateTime: Date;
  message: Grape[]
}
