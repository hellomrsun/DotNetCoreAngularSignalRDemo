import { Component, OnInit } from "@angular/core";
import { Grape } from "src/app/models/grape";
import { GrapeService } from 'src/app/services/grape.service';

@Component({
  selector: 'app-grapes',
  templateUrl: "./grapes.component.html",
  styleUrls: ["./grapes.component.scss"]
})
export class GrapesComponent implements OnInit {
  public grapes: Grape[];
  public editId: number;
  i = 0;

  constructor(private service: GrapeService) { }

  ngOnInit(): void {
    this.GetGrapes();
  }

  addRow(): void {
    console.log('row added');

    this.i = this.grapes.length;

    this.grapes = [
      ...this.grapes,
      {
        id: this.i,
        name: 'dd',
        description: 'd'
      }
    ];
    this.i++;
  }


  editName(id: number, event: MouseEvent): void {
    event.preventDefault();
    event.stopPropagation();
    this.editId = id;
  }

  editDescription(id: number, event: MouseEvent): void {
    event.preventDefault();
    event.stopPropagation();
    this.editId = id;
  }

  deleteRow(id: number) {
    console.log('delete is triggered');
    this.service.Delete(id).subscribe(
      x => console.log('The deletion is successful!'),
      error => console.log('Failed to delete grape!' + error)
    );

    this.grapes = this.grapes.filter(d => d.id !== id);
  }

  save() {

  }

  GetGrapes() {
    this.service.GetAllGrapes().subscribe(x => {
      this.grapes = x;
    });
  }

}
