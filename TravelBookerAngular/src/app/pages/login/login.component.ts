import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, HttpClientModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  login: Login;

  constructor(private http: HttpClient,private router: Router) {
    this.login = new Login();
  }

  onLogin() {
    console.log("primer comentario")
    this.http.post('https://localhost:7139/api/Usuario/login', this.login).subscribe((res: any) => {
      console.log("segundo comentario")
      if (res.success) {
        alert("Bienvenido!");
      } else {
        alert("Credenciales inválidas");
      }
    }, error => {
      console.error("Error al iniciar sesión:", error);
      alert("Error al iniciar sesión: " + error.message);
    });
    }
  }

export class Login { 
    EmailId: string;
    Password: string;
    constructor() {
      this.EmailId = '';
      this.Password = '';
    } 
}
