import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ErrorPageComponent } from './error-page/error-page.component';
import { RegisterComponent } from './register/register.component';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { ProfileComponent } from './profile/profile.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { CartComponent } from './cart/cart.component';
import { ShopComponent } from './shop/shop.component';



const routes: Routes = [
    { path: '', redirectTo: '/login', pathMatch: 'full' },
    { path: 'login', component: LoginComponent },
    { path: 'register', component: RegisterComponent },
    {
        path: 'home',
        component: HomeComponent
    },
    {
        path: 'home',
        component: HomeComponent
    },
    {
        path: 'profile',
        component: ProfileComponent
    },
    {
        path: 'product-details',
        component: ProductDetailsComponent
    },
    {
        path: 'cart',
        component: CartComponent
    },
    {
        path: 'shop',
        component: ShopComponent
    },
    {
        path: 'error',
        component: ErrorPageComponent,
        data: {
            'type': 404,
            'title': 'Page Not Found',
            'desc': 'Oopps!! The page you were looking for doesn\'t exist.'
        }
    },
    {
        path: 'error/:type',
        component: ErrorPageComponent
    },
    { path: '**', redirectTo: 'error', pathMatch: 'full' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes, { scrollPositionRestoration: 'top' })],
    exports: [RouterModule]
})
export class AppRoutingModule { }








// path: '',
//         component: AppComponent,
//         canActivate: [],
//         children: [
//             {
//                 path: 'home',
//                 loadChildren: () => import('./home/home.component').then(m => m.HomeComponent)
//             },
//             {
//                 path: 'profile',
//                 loadChildren: () => import('./profile/profile.component').then(m => m.ProfileComponent)
//             },
//             {
//                 path: 'product-detail',
//                 loadChildren: () => import('./product-details/product-details.component').then(m => m.ProductDetailsComponent)
//             },
//             {
//                 path: 'shop',
//                 loadChildren: () => import('./shop/shop.component').then(m => m.ShopComponent)
//             },
//             {
//                 path: 'cart',
//                 loadChildren: () => import('./cart/cart.component').then(m => m.CartComponent)
//             }
//             // { path: '', redirectTo: 'home', pathMatch: 'full' },
//             // { path: '**', redirectTo: 'dashboard', pathMatch: 'full' }
//         ]