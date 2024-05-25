import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'TravelBookerAngular';
  
  constructor(private router: Router) {}
  irALogin() {
    this.router.navigate(['/login']);
  }
  redirigirAlHome() {
    this.router.navigate(['/home']);
  }
  about() {
    this.router.navigate(['/about']);
  }
}
