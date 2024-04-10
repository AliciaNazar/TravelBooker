import { CommonModule } from '@angular/common';
import { Component, inject } from '@angular/core';
import { TravelBookerServiceService } from '../../services/travel-booker-service.service';
import { ActivatedRoute } from '@angular/router';
import { ILocalidad } from '../../models/localidad.model';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  private _travelBookerService = inject(TravelBookerServiceService);
  private _route = inject(ActivatedRoute);

  public localidad?: ILocalidad;



  // ngOnInit(): void {
  //   this._route.params.subscribe(params => {
  //     this._travelBookerService.getLocalidadById(params['id']).subscribe((data:ILocalidad)=>{
  //       this.localidad=data;
  //     });
  //   })
  // }


}

