import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ReportService } from './report.service';
import { ResponseHandler } from '../response/responseHandler';


@Component({
    selector: 'esport-app',
    templateUrl: './productReport.html'
})

export class ProductReportComponent {
    productQuantity: number = 1;
    loading: boolean = false;
    productReportResult: Array<any> = [];
    

    constructor(private reportService: ReportService, private responseHandler: ResponseHandler) {
    }

    buildReport() {
        this.loading=true;
        this.reportService.productsMoreSaled(this.productQuantity).subscribe(
            response => {
                if(response.Success){
                    this.proccessResponse(response.Data.Result);
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
    private proccessResponse(response: any) {
        this.productReportResult = [];
        for (let reportResult of response) {
            this.productReportResult.push(reportResult);
        }
    }
}