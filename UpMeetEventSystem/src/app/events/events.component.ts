import { Component } from '@angular/core';
import { ApiService } from '../api.service';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.css']
})
export class EventsComponent {

  constructor(private apiService: ApiService){}

  ngOnInit(): void {
    this.getEvents();
  }

}
