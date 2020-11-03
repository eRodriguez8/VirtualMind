import { Component, OnInit, Input } from '@angular/core';
import { HttpManagerService } from 'src/app/services/manager.service';
import { AppContextService } from 'src/app/services/appContext.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Posiciones } from 'src/app/models/posiciones';


@Component({
	selector: 'app-posiciones',
	templateUrl: './posiciones.component.html',
	styleUrls: ['./posiciones.component.scss']
})

export class PosicionesComponent implements OnInit {
	@Input() posiciones: Posiciones[];
	public headElements = [
		'#',
		'Region',
		'Posicion',
		'Codigo Articulo',
		'Bultos',
		'Incidencia',
		'Legajo',
		'Fecha Registro'
	];
	dtPosiciones: any = {};

	constructor(private context: AppContextService, private modalService: NgbModal, private http: HttpManagerService) {	}

	ngOnInit() { }
}
