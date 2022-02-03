import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PersonPhoneService} from 'src/app/service/person-phone.service';
import { PersonService } from 'src/app/service/person.service';
import { PhoneNumberTypeService } from 'src/app/service/phone-number-type.service';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'app-edit-phone-number',
  templateUrl: './edit-phone-number.component.html',
  styleUrls: ['./edit-phone-number.component.css']
})
export class EditPhoneNumberComponent implements OnInit {
  phoneNumber: string
  editForm: FormGroup;

  constructor(
    private route: ActivatedRoute,
    private dataService: PersonPhoneService,
    private formBuilder: FormBuilder
  ) { }

  ngOnInit() {
    let context = this;
    let personPhone 
    this.phoneNumber = this.route.snapshot.params['phoneNumber']
    this.dataService.GetObject(this.phoneNumber, function(returnObject){
      returnObject.subscribe(
        response =>{
         personPhone = response.data.personPhoneObjects
         //context.editForm.setValue(personPhone);
         //console.log(personPhone)
        }
      )
    })

    this.editForm = this.formBuilder.group({
      phoneNumber: ['', Validators.required],
      phoneNumberTypeID: ['', Validators.required],
    });
    
    
  
  }

 

}
