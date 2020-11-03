import { Component, OnInit, Input } from '@angular/core';
import { HttpManagerService } from 'src/app/services/manager.service';
import { AppContextService } from 'src/app/services/appContext.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Limpieza } from 'src/app/models/limpieza';


@Component({
	selector: 'app-limpieza',
	templateUrl: './limpieza.component.html',
	styleUrls: ['./limpieza.component.scss']
})

export class LimpiezaComponent implements OnInit {
	@Input() limpieza: Limpieza[];
	public headElements = [
		'#',
		'Region',
		'Ubicacion',
		'Incidencia',
		'Legajo',
		'Fecha Registro'
	];
	dtLimpieza: any = {};

	constructor(private context: AppContextService, private modalService: NgbModal, private http: HttpManagerService) {	}

	ngOnInit() { }
}
