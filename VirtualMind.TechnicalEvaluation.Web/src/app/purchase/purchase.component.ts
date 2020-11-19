import { Component, OnInit } from '@angular/core';
import { HttpManagerService } from 'src/app/services/manager.service';
import { HelperService } from '../services/helper.service';


@Component({
	selector: 'app-purchase',
	templateUrl: './purchase.component.html',
	styleUrls: ['./purchase.component.scss']
})

export class PurchaseComponent implements OnInit {

	constructor(private http: HttpManagerService, private helper: HelperService) { }

	ngOnInit() { }
}
