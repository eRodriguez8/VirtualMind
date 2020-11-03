export class Incidencia {
	constructor(
		public ts: Date,
		public usuario: string,
		public incidencia: string,
		public idTipoAuditoria: number,
		public id: number
	) { }
}
