import { Component, Input, OnInit } from '@angular/core';
import { AppContext } from '../models/appContext';

@Component({
    selector: 'app-menu',
    templateUrl: './menu.component.html',
    styleUrls: ['./menu.component.css']
})

export class MenuComponent implements OnInit {
    public appContext: AppContext;
    @Input()

    set context(context: AppContext) {
        this.appContext = context;
    }

    constructor() { }

    ngOnInit() { }
}
