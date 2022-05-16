import { Component, OnInit } from '@angular/core';
import { SpotterService } from './spotter.service';


@Component({
  selector: 'app-customer',
  templateUrl: './spotter.component.html',
  styleUrls: ['./spotter.component.css']
})
export class SpotterComponent implements OnInit {
  spotters: any[] = [];
  allspotters: any = [];
  searchText: string = '';


  constructor(private spotterService: SpotterService) { }

  ngOnInit(): void {

    this.getSpotters()
  }

  getSpotters() {
    const actionUrl = "Spotter/GetSpotter"
    this.spotterService.getAllByGet<any>(actionUrl)
      .subscribe(data => {
        if (data != null) {
          if (!data.isError) {
            console.log(data.returnObject.result);
            this.spotters = data.returnObject.result;
            this.allspotters = data.returnObject.result;
          }
        }
        else {
          //need to create notofication servers
          //this.notificationService.error(null);
        }
      });

    console.log(this.spotters);
  }
  search(searchValue: string) {
    this.spotters = this.allspotters.filter((spotter: any) =>
      spotter.makeName.toLowerCase().includes(searchValue)
    );
  }

  reset() {
    this.spotters = this.allspotters
  }
  delete(id: any) {

    //need to impliment new APi method to deactive spotter  no time to compleate this now 
    const url = "Spotter";
    const SpotterEntity: any = {};
    SpotterEntity.Id = id;
    SpotterEntity.MakeId = 0;
    SpotterEntity.ModelId = 0;
    SpotterEntity.Registration = '';
    SpotterEntity.Location = '';
    SpotterEntity.Date = new Date();
    SpotterEntity.ModelName = '';
    SpotterEntity.MakeName = '';
    SpotterEntity.IsActive = false;
    this.spotterService.getAllByPost<any>(url, SpotterEntity)
      .subscribe(data => {
        if (data != null) {
          if (!data.isError) {
          }
          else {

          }
        }
      });


  }
}
