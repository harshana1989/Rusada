import { Component, OnInit } from '@angular/core';
import { SpotterService } from '../spotter.service';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-add-edit-customer',
  templateUrl: './add-edit-spotter.component.html',
  styleUrls: ['./add-edit-spotter.component.css']
})
export class AddEditSpotterComponent implements OnInit {

  make: any[] = [];
  model: any[] = [];
  notification:string='';
  isNotificationHidden:boolean=false;


  spotterForm = new FormGroup({
    makeId: new FormControl(''),
    modelId: new FormControl(''),
    registation: new FormControl(''),
    location: new FormControl(''),
    date: new FormControl(''),
  });

  constructor(private spotterService: SpotterService) { }

  ngOnInit(): void {
    this.getMake();
    this.getModel();
  }

  onSubmit() {
    debugger
    if (!this.spotterForm.invalid) {
      const url = + "Spotter/SaveSpotter";
      const dataToBeSaved = this.bindDataToBeSaved();
      this.spotterService.add<any>(url, dataToBeSaved)
        .subscribe(data => {
          if (data != null) {
            if (!data.isError) {
              this.isNotificationHidden=true;
              this.notification=" Save successfully";
            }
            else {
              this.isNotificationHidden=true;
              this.notification=" Save Fail";
            }
          }
        });
    }
  }
  bindDataToBeSaved() {
    var formData = this.spotterForm.getRawValue();
    formData['id'] = this.spotterForm;
    return formData;
  }
  getMake() {
    const actionUrl = "Spotter/GetMake"
    this.spotterService.getAllByGet<any>(actionUrl)
      .subscribe(data => {
        if (data != null) {
          if (!data.isError) {
            console.log(data.returnObject.result);
            this.make = data.returnObject.result;
          }
        }
        else {
          //need to create notofication servers
          //this.notificationService.error(null);
        }
      });
  }
  getModel() {
    const actionUrl = "Spotter/GetModel"
    this.spotterService.getAllByGet<any>(actionUrl)
      .subscribe(data => {
        if (data != null) {
          if (!data.isError) {
            console.log(data.returnObject.result);
            this.model = data.returnObject.result;
          }
        }
        else {
          //need to create notofication servers
          //this.notificationService.error(null);
        }
      });
  }
}
