import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ReportService } from './report.service';
import { ResponseHandler } from '../response/responseHandler';


@Component({
    selector: 'esport-app',
    templateUrl: './categoryReport.html'
})

export class CategoryReportComponent {
    initDate: Date;
    finishDate: Date;
    loading: boolean = false;
    categoryReportResult:any={};
    

    constructor(private reportService: ReportService, private responseHandler: ResponseHandler) {
    }

    buildReport() {
        this.loading=true;
        let initDateStr:string="";
        if(this.initDate){
            initDateStr=this.initDate.toString();
        }
        let finishDateStr:string="";
        if(this.finishDate){
           finishDateStr=this.finishDate.toString();
        }
        
        this.reportService.categoryReport(this.formatDate(initDateStr),this.formatDate( finishDateStr)).subscribe(
            response => {
                if(response.Success){
                    this.proccessResponse(response.Data.Result);
                    this.categoryReportResult.Total=response.Data.TotalAmount;
                    this.responseHandler.hideMessage();
                }else{
                    this.responseHandler.buildBadResponse(response.Message);
                }
                this.loading = false;
            },
            error => {
                this.loading = false;
                this.responseHandler.buildBadResponse("Error al emitir reporte");
            }
        );
    }

    formatDate(toFormat:string):string{
        let lastChange:string="";
        while(toFormat.includes("-")){
            toFormat=toFormat.replace("-","");
        }
        return toFormat;
    }
    private proccessResponse(response: any) {
        this.categoryReportResult.ItemsResult = [];
        for (let reportResult of response) {
            this.categoryReportResult.ItemsResult.push(reportResult);
        }
    }
}