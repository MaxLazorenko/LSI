import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public reports: Report[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Report[]>(baseUrl + 'reports' + '?roomName=Room0&from=2021-10-29&to=2021-11-15').subscribe(result => {
      this.reports = result;
    }, error => console.error(error));
  }
}

interface Report {
  nameOfExport: string;
  dateOfExport: number;
  nameOfRoom: number;
  userName: string;
}
