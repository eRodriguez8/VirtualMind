import { Component, OnInit, Input } from '@angular/core';
import { HttpManagerService } from 'src/app/services/manager.service';
import { AppContextService } from 'src/app/services/appContext.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Contenedores } from 'src/app/models/contenedores';


@Component({
	selector: 'app-contenedores',
	templateUrl: './contenedores.component.html',
	styleUrls: ['./contenedores.component.scss']
})

export class ContenedoresComponent implements OnInit {
	@Input() contenedores: Contenedores[];

	public headElements = [
		'#',
		'Region',
		'Etiqueta',
		'Codigo Articulo',
		'Sector',
		'Incidencia',
		'Legajo',
		'Fecha Registro'
	];
	dtContenedores: any = {};

	constructor(private context: AppContextService, private modalService: NgbModal, private http: HttpManagerService) {	}

	ngOnInit() { }

	configGrilla() {
		this.dtContenedores = {
			searching: false,
			lengthChange: false,
			processing: true,
			select: true,
			language: {
				info: 'Mostrando página _PAGE_ de _PAGES_',
				infoEmpty: '',
				sEmptyTable: 'Sin datos',
				paginate: {
					previous: 'Anterior',
					next: 'Siguiente'
				}
			}
		};
	}
}
