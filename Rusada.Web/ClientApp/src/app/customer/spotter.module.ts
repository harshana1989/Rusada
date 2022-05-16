import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SpotterComponent } from './spotter.component';
import { AddEditSpotterComponent } from './add-edit-customer/add-edit-spotter.component';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule  } from '@angular/forms';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';


@NgModule({
  declarations: [
    SpotterComponent,
    AddEditSpotterComponent
    
  ],
  imports: [
    CommonModule,
    RouterModule,
    ReactiveFormsModule,
    BsDatepickerModule.forRoot()
  ],
  exports:[
    SpotterComponent
  ]
})
export class SpotterModule { }
