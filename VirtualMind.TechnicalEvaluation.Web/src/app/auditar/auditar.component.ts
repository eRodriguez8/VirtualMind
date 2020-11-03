import { Component, OnInit, ViewChild } from '@angular/core';
import { HttpManagerService } from 'src/app/services/manager.service';
import { FiltroGetAll } from '../models/filtroGetAll';
import { RespuestaExcel } from '../models/respuestaExcel';
import { HelperService } from '../services/helper.service';
import { Contenedores } from '../models/contenedores';
import { Limpieza } from '../models/limpieza';
import { Posiciones } from '../models/posiciones';
import { FiltroConsultaComponent } from './filtro-consulta/filtro-consulta.component';
import { AuditoriaTabla } from '../models/auditoriaTabla';

@Component({
	selector: 'app-auditar',
	templateUrl: './auditar.component.html',
	styleUrls: ['./auditar.component.scss']
})

export class AuditarComponent implements OnInit {
	filtros = new FiltroGetAll();
	contenedores: Contenedores[];
	limpieza: Limpieza[];
	posiciones: Posiciones[];
	title: string;
	@ViewChild(FiltroConsultaComponent) child;

	constructor(private http: HttpManagerService, private helper: HelperService) { }

	ngOnInit() { }

	cargarGrilla() {
		const fechaApi = this.filtros.fecha.split('-');
		const legajo = (this.filtros.legajo.toString() == '' ? '0' : this.filtros.legajo.toString());

		if (this.filtros.reporte == 1) {
			this.http.get<Contenedores[]>('Contenedores/' + this.filtros.incidencia.toString() + '/' +
				this.filtros.sector.toString() + '?legajo=' + legajo + '&fechaDesde=' + fechaApi[0] + '&fechaHasta=' + fechaApi[1]
			).subscribe(dataResult => {
				this.contenedores = dataResult;
				this.changeIncidencias(this.contenedores);
				this.changeSectores(this.contenedores);
				this.posiciones = null;
				this.limpieza = null;
				this.title = 'Contenedores';
			});
		} else if (this.filtros.reporte == 2) {
			this.http.get<Limpieza[]>('Limpieza/' + this.filtros.incidencia.toString() + '?legajo=' + legajo +
				'&fechaDesde=' + fechaApi[0] + '&fechaHasta=' + fechaApi[1]
			).subscribe(dataResult => {
				this.limpieza = dataResult;
				this.changeIncidencias(this.limpieza);
				this.contenedores = null;
				this.posiciones = null;
				this.title = 'Limpieza';
			});
		} else if (this.filtros.reporte == 3) {
			this.http.get<Posiciones[]>('Posiciones/' + this.filtros.incidencia.toString() + '?legajo=' + legajo +
				'&fechaDesde=' + fechaApi[0] + '&fechaHasta=' + fechaApi[1]
			).subscribe(dataResult => {
				this.posiciones = dataResult;
				this.changeIncidencias(this.posiciones);
				this.contenedores = null;
				this.limpieza = null;
				this.title = 'Posiciones';
			});
		}
	}

	obtenerFiltros(filtro: FiltroGetAll) {
		this.filtros = filtro;
		this.cargarGrilla();
	}

	Descargar() {
		let body;

		if (this.contenedores) {
			body = this.contenedores;
		} else if (this.limpieza) {
			body = this.limpieza;
		} else if (this.posiciones) {
			body = this.posiciones;
		}

		if (body) {
			this.http.post<RespuestaExcel>('Exportar/', body).subscribe(dataResult => {
				if (this.contenedores) {
					dataResult.nombre = dataResult.nombre.replace('Auditorias ', 'Auditorias de Contenedores ');
				} else if (this.limpieza) {
					dataResult.nombre = dataResult.nombre.replace('Auditorias ', 'Auditorias de Limpiezas ');
				} else if (this.posiciones) {
					dataResult.nombre = dataResult.nombre.replace('Auditorias ', 'Auditorias de Posiciones ');
				}
				this.helper.downloadFile(dataResult.bytes, dataResult.nombre);
			});
		}
	}

	private changeIncidencias(list: any) {
		for (let item of list) {
			const incidencia = this.child.incidencias.filter(x => x.id == item.idAuditoriaIncidencia)[0];
			item.nombreIncidencia = incidencia.incidencia;
		}
	}

	private changeSectores(list: any) {
		for (let item of list) {
			const sectores = this.child.sectores.filter(x => x.id == item.idAuditoriaSector)[0];
			console.log(sectores);
			item.nombreSector = sectores.descripcion;
		}
	}
}
