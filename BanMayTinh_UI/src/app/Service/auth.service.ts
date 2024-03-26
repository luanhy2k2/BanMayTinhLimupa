import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private jwtHelper: JwtHelperService) {}
  getEmailFromToken(token: string): string {
    const decodedToken = this.jwtHelper.decodeToken(token);
    const email = decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress'];
    console.log(decodedToken);
      return email;
  }
  getRoleFromToken(token: string): string {
    const decodedToken = this.jwtHelper.decodeToken(token);
    const role = decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
    console.log(decodedToken);
      return role;
  }
  getPhoneFromToken(token: string): string {
    const decodedToken = this.jwtHelper.decodeToken(token);
    const role = decodedToken['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/mobilephone'];
    console.log(decodedToken);
      return role;
  }
}
