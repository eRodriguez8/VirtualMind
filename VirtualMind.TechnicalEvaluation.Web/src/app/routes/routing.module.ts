import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InicioComponent } from '../inicio/inicio.component';
import { UnauthorizedComponent } from '../unauthorized/unauthorized.component';
import { QuoteComponent } from '../quote/quote.component';
import { PurchaseComponent } from '../purchase/purchase.component';

const appRoutes: Routes = [
    { path: '', redirectTo: 'Inicio', pathMatch: 'full' },
    { path: 'quote', component: QuoteComponent },
    { path: 'purchase', component: PurchaseComponent },
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
