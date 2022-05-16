import { Component, OnInit, Pipe } from '@angular/core';
import { SpotterService } from '../spotter.service';
import { AbstractControl, FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';

@Component({
  selector: 'app-add-edit-customer',
  templateUrl: './add-edit-spotter.component.html',
  styleUrls: ['./add-edit-spotter.component.css']
})
export class AddEditSpotterComponent implements OnInit {

  submitted = false;

  spotters: any = [];
  make: any[] = [];
  model: any[] = [];
  SpotterId: any;
  notification: string = '';
  isNotificationHidden: boolean = false;
  searchTerm: string = '';
  spotterForm!: FormGroup;
  constructor(
    private spotterService: SpotterService
    , private activatedroute: ActivatedRoute
    , private location: Location,
    private formBuilder: FormBuilder) { }



  ngOnInit(): void {

    this.spotterForm = this.formBuilder.group(
      {
        makeId: ['', Validators.required],
        modelId: ['', Validators.required],
        registation: ['', Validators.required, Validators.maxLength(5), Validators.pattern('[a-zA-Z]+-[a-zA-Z]')],
        location: ['', Validators.required, Validators.maxLength(255)],
        date: ['', Validators.required]
      },
    );

    this.activatedroute.paramMap.subscribe(params => {
      this.SpotterId = params.get('id');
    });
    console.log(this.SpotterId)
    //this.id=this.activatedroute.snapshot.paramMap.get("id");
    if (this.SpotterId != 0) {
      this.getSpottersById(this.SpotterId)
    }
    this.getMake();
    this.getModel();
  }
  get f(): { [key: string]: AbstractControl } {
    return this.spotterForm.controls;
  }

  onReset(): void {

    this.submitted = false;
    this.spotterForm.reset();
  }

  onSubmit() {
    this.submitted = true;
    if (!this.spotterForm.invalid) {
      const url = "Spotter";
      const SpotterEntity: any = {};
      SpotterEntity.Id = this.SpotterId != 0 ? this.SpotterId : 0;
      SpotterEntity.MakeId = this.spotterForm.get("makeId")?.value;
      SpotterEntity.ModelId = this.spotterForm.get("modelId")?.value;
      SpotterEntity.Registration = this.spotterForm.get("registation")?.value;
      SpotterEntity.Location = this.spotterForm.get("location")?.value;
      SpotterEntity.Date = this.spotterForm.get("date")?.value;
      SpotterEntity.ModelName = '';
      SpotterEntity.MakeName = '';
      SpotterEntity.IsActive = true;
      this.spotterService.getAllByPost<any>(url, SpotterEntity)
        .subscribe(data => {
          if (data != null) {
            if (!data.isError) {
              this.isNotificationHidden = true;
              this.notification = " Save successfully";
            }
            else {
              this.isNotificationHidden = true;
              this.notification = " Save Fail";
            }
          }
        });
    }
  }
  getMake() {
    const actionUrl = "Spotter/GetMake"
    this.spotterService.getAllByGet<any>(actionUrl)
      .subscribe(data => {
        if (data != null) {
          if (!data.isError) {
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
            this.model = data.returnObject.result;
          }
        }
        else {
          //need to create notofication servers
          //this.notificationService.error(null);
        }
      });
  }
  getSpottersById(SpotterId: number) {
    const actionUrl = "Spotter/GetSpotterById"
    const params: any = {
      "SpotterId": SpotterId
    };
    this.spotterService.getAllByGet<any>(actionUrl, params)
      .subscribe(data => {
        if (data != null) {
          if (!data.isError) {
            console.log(data.returnObject.result);
            this.spotters = data.returnObject.result;
            this.PatchFormControllValueInEditMode(this.spotters);
          }
        }
        else {
          //need to create notofication servers
          //this.notificationService.error(null);
        }
      });
  }

  PatchFormControllValueInEditMode(item: any) {
    this.spotterForm.get("makeId")?.patchValue(item.makeId);
    this.spotterForm.get("modelId")?.patchValue(item.modelId);
    this.spotterForm.get("registation")?.patchValue(item.registration);
    this.spotterForm.get("location")?.patchValue(item.location);
  }

  backClicked() {
    this.location.back();
  }
  public getModelCode(id: number): any {
    return this.model.find((x) => x.id === id);
  }
  public getMakeCode(id: number): any {
    return this.make.find((x) => x.id === id);
  }


}
