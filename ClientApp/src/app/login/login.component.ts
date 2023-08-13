import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginData } from 'src/interfaces/auth.interfaces';
import { UserModel } from 'src/models/user';
import { AuthService } from 'src/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  user: UserModel = new UserModel();

  userLogin: LoginData = {
    email: '',
    password: ''
  }

  // email: string = '';
  // password: string = '';

  email = new FormControl('', [Validators.required, Validators.email]);
  password = new FormControl('', [Validators.required]);

  constructor(
    private authService: AuthService,
    private router: Router,
    private route: ActivatedRoute) { }


  ngOnInit(): void {
    localStorage.clear();

  }

  getErrorMessage() {
    if (this.email.hasError('required')) {
      return 'You must enter a value';
    }

    return this.email.hasError('email') ? 'Not a valid email' : '';
  }

  onSubmit() {
    this.authService.login(this.userLogin).subscribe(
      (result) => {
        this.user = result;
        localStorage.setItem('token', result.token);
        localStorage.setItem('currentUserId', this.user.id.toString());
        localStorage.setItem('name', this.user.firstName);
        localStorage.setItem('email', this.user.email);
        localStorage.setItem('isLoggedin', 'true');

        if (localStorage.getItem('isLoggedin')) {
          this.router.navigate(['/home']);
        }

        // localStorage.setItem('role', this._userDTO.role);
      },
      (error) => {
        console.log("error logging in user", error);
      }
    );
  }
}
