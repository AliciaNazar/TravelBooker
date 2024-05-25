import { Routes } from '@angular/router';
import { HomeComponent } from './pages/home/home.component';
import { LoginComponent } from './pages/login/login.component';
import { ReservaComponent } from './pages/reserva/reserva.component';
import { ViajeComponent } from './pages/viaje/viaje.component';
import { AboutComponent } from './pages/about/about.component';

export const routes: Routes = [
    {path:'', component:HomeComponent},
    {path:'home', redirectTo:''},
    {path:'login', component:LoginComponent},
    // {path:'**', redirectTo:'',pathMatch:'full'},
    {path:'viaje', component:ViajeComponent},
    {path:'reserva',component:ReservaComponent},
    {path:'about',component:AboutComponent}
];
