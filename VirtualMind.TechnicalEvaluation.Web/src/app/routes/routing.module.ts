import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InicioComponent } from '../inicio/inicio.component';
import { UnauthorizedComponent } from '../unauthorized/unauthorized.component';
import { AuditarComponent } from '../auditar/auditar.component';

const appRoutes: Routes = [
    { path: '', redirectTo: 'Inicio', pathMatch: 'full' },
    { path: 'Auditar', component: AuditarComponent },
    { path: 'Inicio', component: InicioComponent },
    { path: 'Unauthorized', component: UnauthorizedComponent },
    { path: '**', component: InicioComponent }
];

@NgModule({
    imports: [RouterModule.forRoot(appRoutes)],
    exports: [RouterModule]
})
export class AppRoutingModule {

}
