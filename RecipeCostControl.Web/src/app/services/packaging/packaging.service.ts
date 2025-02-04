import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Packaging } from '../../models/packaging.model';

@Injectable({
  providedIn: 'root'
})
export class PackagingService {

  private url = environment.api;

  constructor(private httpClient: HttpClient) { }

  getAll() {
    return this.httpClient.get<Packaging[]>(this.url + '/packaging')
  }
}
