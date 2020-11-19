import { Component, OnInit } from '@angular/core';
import { HttpManagerService } from 'src/app/services/manager.service';
import { HelperService } from '../services/helper.service';

@Component({
	selector: 'app-quote',
	templateUrl: './quote.component.html',
	styleUrls: ['./quote.component.scss']
})

export class QuoteComponent implements OnInit {
	
	constructor(private http: HttpManagerService, private helper: HelperService) { }

	ngOnInit() { }

}
