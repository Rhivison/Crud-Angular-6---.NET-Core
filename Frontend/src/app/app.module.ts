import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import {routing} from "./app.routing";
import {ReactiveFormsModule} from "@angular/forms";
import {HttpClientModule} from "@angular/common/http";
import { ListPhoneNumberComponent } from './pages/list-phone-number/list-phone-number.component';
import { EditPhoneNumberComponent } from './pages/edit-phone-number/edit-phone-number.component';
import { AddPhoneNumberComponent } from './pages/add-phone-number/add-phone-number.component';


@NgModule({
  declarations: [
    AppComponent,
    ListPhoneNumberComponent,
    EditPhoneNumberComponent,
    AddPhoneNumberComponent,
  ],
  imports: [
    BrowserModule,
    routing,
    ReactiveFormsModule,
    HttpClientModule
  ],
  //providers: [UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
