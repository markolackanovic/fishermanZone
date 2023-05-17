export class LoggedInUserModel {
  id: number = 0;
  username: string = "";
  password: string = "";
  firstName: string = "";
  lastName: string = "";
  firstNameCyr: string = "";
  lastNameCyr: string = "";
  isLoggedIn: boolean = false;
  token: string = "";
  isVerificationRequired: string = "";
}
