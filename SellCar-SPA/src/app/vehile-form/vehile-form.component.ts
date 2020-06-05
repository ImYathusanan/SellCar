import { VehileService } from '../services/vehile.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vehile-form',
  templateUrl: './vehile-form.component.html',
  styleUrls: ['./vehile-form.component.css']
})
export class VehileFormComponent implements OnInit {

  makes: any[];
  models: any[];
  features: any[];
  vehiles: any = {};

  constructor(private vehileService: VehileService) { }

  ngOnInit(): void {
    this.vehileService.getMakes().subscribe((response: any[]) => {
      this.makes = response;
    })
    
    this.vehileService.getFeatures().subscribe((response: any[]) => {
      this.features = response;
    })
  }

  onMakeChange() {
    let selectedMake = this.makes.find(m => m.id == this.vehiles.make);
    this.models = selectedMake ? selectedMake.models : [];
  }

}
