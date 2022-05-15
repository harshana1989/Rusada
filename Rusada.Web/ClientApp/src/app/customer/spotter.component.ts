import { Component, OnInit } from '@angular/core';
import { SpotterService } from './spotter.service';


@Component({
  selector: 'app-customer',
  templateUrl: './spotter.component.html',
  styleUrls: ['./spotter.component.css']
})
export class SpotterComponent implements OnInit {
  spotters: any[]=[];
 


  constructor(private spotterService: SpotterService) { }

  ngOnInit(): void {
      this.getSpotters()
  }

  getSpotters(){
    const actionUrl ="Spotter/GetSpotter"
    this.spotterService.getAllByGet<any>(actionUrl)
      .subscribe(data => {
        if (data != null) {
          if (!data.isError) {
            console.log(data.returnObject.result);
            this.spotters = data.returnObject.result;
          }
        }
        else {
          //need to create notofication servers
          //this.notificationService.error(null);
        }
      });

      console.log(this.spotters);
    }
  }
