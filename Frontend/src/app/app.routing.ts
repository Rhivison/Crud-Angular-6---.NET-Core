import { RouterModule, Routes } from '@angular/router';
import { ListPhoneNumberComponent } from './pages/list-phone-number/list-phone-number.component';
import { EditPhoneNumberComponent } from './pages/edit-phone-number/edit-phone-number.component';
import { AddPhoneNumberComponent } from './pages/add-phone-number/add-phone-number.component';

const routes: Routes = [
 
  {path: 'list-phone-number', component:ListPhoneNumberComponent},
  {path: 'edit-phone-number/:phoneNumber', component:EditPhoneNumberComponent},
  {path: 'add-phone-number', component:AddPhoneNumberComponent},
  {path:'', component:ListPhoneNumberComponent}
  
];

export const routing = RouterModule.forRoot(routes);
