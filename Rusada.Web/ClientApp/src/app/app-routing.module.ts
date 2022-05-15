import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddEditSpotterComponent } from './customer/add-edit-customer/add-edit-spotter.component';
import { SpotterComponent } from './customer/spotter.component';

const routes: Routes = [
    {path:'', component:SpotterComponent,data: { breadcrumb: 'Spotter' }},
    {path:'spotter/:id', component:AddEditSpotterComponent},
    {path:'**', redirectTo:'' , pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
