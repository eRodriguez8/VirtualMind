export class Contenedores {
	constructor(
		public fecharegistro: Date,
		public codigoarticulo: string,
		public etiqueta: string,
		public legajo: string,
		public idAuditoriaSector: number,
		public nombreSector: string,
		public idAuditoriaIncidencia: number,
		public nombreIncidencia: string,
		public idregion: number,
		public id: number
	) { }
}
