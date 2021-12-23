import { Component, OnInit } from '@angular/core';
import { Triangle } from '../Triangle';
import { TriangleService } from '../triangle.service';
import { TriangleResponse } from '../TriangleResponse';

@Component({
  selector: 'app-triangle',
  templateUrl: './triangle.component.html',
  styleUrls: ['./triangle.component.css']
})
export class TriangleComponent implements OnInit {

  triangle: Triangle = {
    height: 10,
    width: 10,
    row: "A",
    column: 1,
    vertex1x: 0,
    vertex1y: 10,
    vertex2x: 0,
    vertex2y: 0,
    vertex3x: 10,
    vertex3y: 10,
  };
  constructor(private triangleService: TriangleService) { }

  ngOnInit(): void {

  }

  GetTriangleCoordinates() {
    this.triangleService.GetTriangleCoordinates(this.triangle)
      .subscribe((data: TriangleResponse) => {
          this.triangle.vertex1x = data.coordinates[0][0];
          this.triangle.vertex1y = data.coordinates[0][1];
          this.triangle.vertex2x = data.coordinates[1][0];
          this.triangle.vertex2y = data.coordinates[1][1];
          this.triangle.vertex3x = data.coordinates[2][0];
          this.triangle.vertex3y = data.coordinates[2][1];
      });
  }

  GetTriangleLocation( ) {
    if(this.triangle.vertex1x != null && this.triangle.vertex1y && this.triangle.vertex2x != null && this.triangle.vertex2y && this.triangle.vertex3x != null && this.triangle.vertex3y){
      this.triangleService.GetTriangleLocation(this.triangle)
        .subscribe((data: TriangleResponse) =>  {
          this.triangle.row = data.location[0];
          this.triangle.column =  Number.parseInt(data.location[1]);
        })
    }
  }
}
