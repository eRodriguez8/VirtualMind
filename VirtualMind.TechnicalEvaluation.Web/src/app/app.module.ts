import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { NgbModule, NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { NgBootstrapFormValidationModule } from 'ng-bootstrap-form-validation';

import { HttpManagerService } from './services/manager.service';

import { AppRoutingModule } from './routes/routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { InicioComponent } from './inicio/inicio.component';
import { UnauthorizedComponent } from './unauthorized/unauthorized.component';
import { MenuComponent } from './menu/menu.component';
import { DataTablesModule } from 'angular-datatables';
import { HashLocationStrategy, LocationStrategy } from '@angular/common';
import { HelperProvider } from './providers/helper.provider';
import { AppContextService } from './services/appContext.service';
import { NgBusyModule } from 'ng-busy';
import { ToastrModule } from 'ngx-toastr';
import { MultiselectDropdownModule } from 'angular-2-dropdown-multiselect';
import { HandleErrorComponent } from './handle-error/handle-error.component';
import { AuditarComponent } from './auditar/auditar.component';
import { FiltroConsultaComponent } from './auditar/filtro-consulta/filtro-consulta.component';
import { Daterangepicker } from 'ng2-daterangepicker';
import { ContenedoresComponent } from './auditar/contenedores/contenedores.component';
import { LimpiezaComponent } from './auditar/limpieza/limpieza.component';
import { PosicionesComponent } from './auditar/posiciones/posiciones.component';

@NgModule({
    imports: [
        BrowserModule,
        BrowserAnimationsModule,
        FormsModule,
        ReactiveFormsModule,
        AppRoutingModule,
        NgBusyModule,
        ToastrModule.forRoot({
            positionClass: 'toast-bottom-right'
        }),
        HttpClientModule,
        NgMultiSelectDropDownModule.forRoot(),
        NgbModule.forRoot(),
        MultiselectDropdownModule,
        NgBootstrapFormValidationModule.forRoot(),
        NgBootstrapFormValidationModule,
        DataTablesModule.forRoot(),
        Daterangepicker
    ],
    declarations: [AppComponent, HeaderComponent,
        InicioComponent, UnauthorizedComponent,
        MenuComponent, HandleErrorComponent,
        AuditarComponent, FiltroConsultaComponent,
        ContenedoresComponent, LimpiezaComponent,
        PosicionesComponent
      ],
    bootstrap: [AppComponent],
    providers: [
        HttpManagerService,
        HelperProvider,
        AppContextService,
        NgbActiveModal,
        { provide: LocationStrategy, useClass: HashLocationStrategy }
    ],
    entryComponents: [HandleErrorComponent]
})

export class AppModule { }
