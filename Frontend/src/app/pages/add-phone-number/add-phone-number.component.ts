import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import { PersonPhoneService} from 'src/app/service/person-phone.service';
import {Router} from "@angular/router";
import { personPhone } from 'src/app/model/personPhone';

@Component({
  selector: 'app-add-phone-number',
  templateUrl: './add-phone-number.component.html',
  styleUrls: ['./add-phone-number.component.css']
})
export class AddPhoneNumberComponent implements OnInit {

  addForm: FormGroup;
  personPhone: personPhone

  constructor(private formBuilder: FormBuilder,
              private router: Router,
              private dataService: PersonPhoneService
              ) { }

  ngOnInit() {

    this.addForm = this.formBuilder.group({
      phoneNumber: ['', Validators.required],
      phoneNumberTypeID: ['', Validators.required],
    });

  }

  onSubmit(){
    let context = this
    context.personPhone = new personPhone()
    context.personPhone.BusinessEntityID = 1;
    context.personPhone.PhoneNumber = this.addForm.value.phoneNumber
    context.personPhone.PhoneNumberTypeID = this.addForm.value.phoneNumberTypeID
    this.dataService.PostData(context.personPhone, function(returnObject){
      returnObject.subscribe(
        response =>{
          this.router.navigate(['list-phone-number']);
        }
      )
    })
    this.router.navigate(['list-phone-number']);
    this.router.navigate(['list-phone-number']);
  }

}
