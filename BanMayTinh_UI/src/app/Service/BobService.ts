// blob-storage.service.ts

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class BlobStorageService {
  private baseUrl = 'https://luan2k2hy.blob.core.windows.net/fileupload';

  constructor(private http: HttpClient) {}

  getImageUrl(imageName: string): string {
    return `${this.baseUrl}/${imageName}`;
  }

  getImage(imageName: string): Observable<Blob> {
    const imageUrl = this.getImageUrl(imageName);
    return this.http.get(imageUrl, { responseType: 'blob' });
  }
}
