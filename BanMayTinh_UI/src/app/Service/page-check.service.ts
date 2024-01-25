import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class PageCheckService {
  private currentPage: string = '';

  constructor() {}

  setCurrentPage(page: string): void {
    this.currentPage = page;
  }

  isUserPage(): boolean {
    return this.currentPage === 'user';
  }

  isAdminPage(): boolean {
    return this.currentPage === 'admin';
  }
}
