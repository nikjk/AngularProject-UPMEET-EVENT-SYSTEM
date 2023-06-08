import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EventsComponent } from './events/events.component';
import { FormComponent } from './event-form/event-form.component';
import { FavoritesComponent } from './favorites/favorites.component';

const routes: Routes = [
  { path: 'events', component: EventsComponent },
  { path: 'event-form', component: FormComponent },
  { path: 'favorites', component: FavoritesComponent }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
