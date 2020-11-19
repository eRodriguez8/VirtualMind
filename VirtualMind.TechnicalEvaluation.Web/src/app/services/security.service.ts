import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpManagerService } from './manager.service';
import { Usuario } from '../models/usuario';

@Injectable({
	providedIn: 'root'
})
export class SecurityService {

	constructor(private httpManagerService: HttpManagerService) { }

	public getUsuario(): Observable<Usuario> {
		return this.httpManagerService.get<Usuario>(`Usuarios/xIdAplicacion/AUD`);
	}
}
