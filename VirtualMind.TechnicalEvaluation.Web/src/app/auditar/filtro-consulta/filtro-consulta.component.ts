import { Component, OnInit, EventEmitter, Output, ViewChild } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Incidencia } from 'src/app/models/incidencia';
import { AppContext } from 'src/app/models/appContext';
import { HttpManagerService } from 'src/app/services/manager.service';
import { AppContextService } from 'src/app/services/appContext.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FiltroGetAll } from 'src/app/models/filtroGetAll';
import { DaterangePickerComponent } from 'ng2-daterangepicker';
import * as moment from 'moment';
import { Auditoria } from 'src/app/models/auditoria';
import { Sectores } from 'src/app/models/sectores';

@Component({
	selector: 'app-filtro-consulta',
	templateUrl: './filtro-consulta.component.html',
	styleUrls: ['./filtro-consulta.component.scss']
})

export class FiltroConsultaComponent implements OnInit {
	filtro = new FiltroGetAll();
	filtroForm: FormGroup;
	incidencias: Incidencia[];
	sectores: Sectores[];
	auditorias: Auditoria[];
	Appcontext: AppContext;
	idSelected: number;
	daterangeC: any = {};
	fechasel: string;
	@ViewChild(DaterangePickerComponent)
	picker: DaterangePickerComponent;
	options: any = {
		locale: {
			format: 'DD/MM/YYYY',
			separator: ' - ',
			applyLabel: 'Aceptar',
			cancelLabel: 'Cancelar',
			fromLabel: 'Desde',
			toLabel: 'Hasta',
			customRangeLabel: 'Custom',
			daysOfWeek: [
				'Do',
				'Lu',
				'Ma',
				'Mi',
				'Ju',
				'Vi',
				'Sa'
			],
			monthNames: [
				'Enero',
				'Febrero',
				'Marzo',
				'Abril',
				'Mayo',
				'Junio',
				'Julio',
				'Agosto',
				'Septiembre',
				'Octubre',
				'Noviembre',
				'Diciembre'
			]
		},
		alwaysShowCalendars: false,
		autoUpdateInput: false
	};

	@Output() filtroConsulta = new EventEmitter<FiltroGetAll>();

	constructor(private context: AppContextService, private modalService: NgbModal, private http: HttpManagerService) {
		this.daterangeC = {};
		this.filtro.fecha = '';
		this.filtroForm = new FormGroup({
			reporteForm: new FormControl(''),
			incidenciaForm: new FormControl(''),
			sectorForm: new FormControl(''),
			legajoForm: new FormControl(''),
		});
	}

	ngOnInit() {
		this.fechasel = '';
		this.incidencias = [];
		this.sectores = [];
		this.auditorias = [
			new Auditoria('Posiciones', 3),
			new Auditoria('Limpieza', 2),
			new Auditoria('Contenedores', 1)
		];
	}

	WidgetsCollapse(idCollapse: string, idOpen: string): void {
		$(idCollapse).find('a[data-toggle="collapse"]').trigger('click');
		if ($(idOpen).find('.fa-chevron-down').length > 0) {
			$(idOpen).trigger('click');
		}
	}

	WidgetClose(id: any): void {
		if ($(id).find('.fa-chevron-down').length > 0) {
			$(id).trigger('click');
		}
	}

	reporteChange(id) {
		this.idSelected = id;

		if (this.idSelected == 1) {
			this.http.get<Sectores[]>('Sectores/').subscribe(dataResult => {
				this.sectores = dataResult;
			});
		}

		this.http.get<Incidencia[]>('Incidencias/' + id.toString()).subscribe(dataResult => {
			this.incidencias = dataResult;
		});
	}

	onSubmit() {
		let fechaCDesde = '';
		let fechaCHasta = '';

		if (this.filtro.fecha !== '' || this.filtro.fecha == undefined) {
			const fechas = this.FormatStringDate(this.filtro.fecha);
			fechaCDesde = fechas.yearFrom + '-' + fechas.monthFrom + '-' + fechas.dayFrom;
			fechaCHasta = fechas.yearTo + '-' + fechas.monthTo + '-' + fechas.dayTo;
		}

		if (fechaCDesde && fechaCHasta) {
			const valores = fechaCDesde + '/' + fechaCHasta;
			this.filtro.fecha = valores === '/' ? '' : valores;
			this.filtro.reporte = this.filtroForm.controls["reporteForm"].value;
			this.filtro.incidencia = this.filtroForm.controls["incidenciaForm"].value;
			if (this.idSelected == 1) {
				this.filtro.sector = this.filtroForm.controls["sectorForm"].value;
			}
			this.filtro.legajo = this.filtroForm.controls["legajoForm"].value;
			this.filtro.fecha = this.fechasel;
			this.filtroConsulta.emit(this.filtro);
		}
	}

	FormatStringDate(fecha: string): any {
		return {
			dayFrom: fecha.slice(0, 2),
			monthFrom: Number(fecha.slice(3, 5)),
			yearFrom: fecha.slice(6, 10),
			dayTo: fecha.slice(13, 15),
			monthTo: Number(fecha.slice(16, 18)),
			yearTo: fecha.slice(19, 23)
		};
	}

	selectedDate(value: any, tipo: string) {
		if (tipo === 'C') {
			if (value != null) {
				this.daterangeC.start = value.start;
				this.daterangeC.end = value.end;
				this.daterangeC.label = value.label;
				this.filtro.fecha = value.start.format('DD/MM/YYYY') + '-' + value.end.format('DD/MM/YYYY');
				this.fechasel = this.filtro.fecha;
			} else {
				this.picker.datePicker.startDate = moment();
				this.picker.datePicker.endDate = moment();
				this.daterangeC = {};
				this.filtro.fecha = '';
			}
		}
	}
}
