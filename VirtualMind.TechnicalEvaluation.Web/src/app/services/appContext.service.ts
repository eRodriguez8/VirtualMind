import { Injectable } from '@angular/core';
import { AppContext } from '../models/appContext';
import { Region } from '../models/region';

@Injectable()
export class AppContextService {

    private appContext: AppContext;
    
    constructor() {}

    setActualContext(context: AppContext) {
        this.appContext = context;
    }

    getActualContext() {
        return this.appContext;
    }
}
