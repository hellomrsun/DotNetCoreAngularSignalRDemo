import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { GrapeService } from 'src/app/services/grape.service';
import { Grape } from 'src/app/models/grape';

@Component({
  selector: 'app-add-grape',
  templateUrl: './add-grape.component.html',
  styleUrls: ['./add-grape.component.scss']
})
export class AddGrapeComponent implements OnInit {

  public name: string;
  public description: string;

  constructor(private service: GrapeService) { }

  ngOnInit(): void {
  }

  Save() {
    const grape: Grape = {
      id: 0, //This value will not be used in API
      name: this.name,
      description: this.description
    };
    console.log('save triggered. Name:' + this.name + ", Description:" + this.description);
    this.service.Save(grape).subscribe(
      x => {
        console.log("Grape has been created successfully!");
        alert("Grape has been created successfully!");
      },
      y => console.log("Failed to create grape!" + y));
  }

}
