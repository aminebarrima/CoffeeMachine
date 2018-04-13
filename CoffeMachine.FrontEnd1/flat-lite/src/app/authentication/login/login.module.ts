import {NgModule} from '@angular/core';
import {WithSocialComponent} from './with-social/with-social.component';
import {RouterModule} from '@angular/router';
import {CommonModule} from '@angular/common';
import {LoginRoutes} from './login.routing';
import {SharedModule} from '../../shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
    imports: [
        CommonModule,
        RouterModule.forChild(LoginRoutes),
        SharedModule,
        ReactiveFormsModule 
    ],
    declarations: [WithSocialComponent]
})

export class LoginModule {}
