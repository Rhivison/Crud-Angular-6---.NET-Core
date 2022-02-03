import { Component, OnInit } from '@angular/core';
import {Router} from "@angular/router";
import { PersonPhoneService } from 'src/app/service/person-phone.service';
import { PersonService } from 'src/app/service/person.service';
import { PhoneNumberTypeService } from 'src/app/service/phone-number-type.service'; 
import { personPhone } from 'src/app/model/personPhone';
import { person } from 'src/app/model/person';
import { phoneNumberType } from 'src/app/model/phoneNumberType'; 

@Component({
  selector: 'app-list-phone-number',
  templateUrl: './list-phone-number.component.html',
  styleUrls: ['./list-phone-number.component.css']
})
export class ListPhoneNumberComponent implements OnInit {

  phoneNumbers: personPhone []
  viewPhoneNumbers = []
  persons: person []
  phoneNumberTypes: phoneNumberType[] 

  constructor(
    private dataService: PersonPhoneService,
    private dataPersonService: PersonService,
    private dataPhoneNumberTypeService: PhoneNumberTypeService,
    private router: Router,

  ) { }

  ngOnInit() {
    this.refreshList();
    
  }

  refreshList(){
    let context = this;
    this.dataService.GetData(function(returnObject){
      returnObject.subscribe(
        response =>{
          context.handleSuccessfullRefreshList(response)
          context.refreshPersonList();
          context.refreshPhoneNumberTypeList();
        }
      )
    })
  }
  refreshPersonList(){
    let context = this;
    this.dataPersonService.GetData(function(returnObject){
      returnObject.subscribe(
        response =>{
          context.handleSuccessfullRefreshListPerson(response)
        }
      )
    })

  }
  refreshPhoneNumberTypeList(){
    let context = this;
    this.dataPhoneNumberTypeService.GetData(function(returnObject){
      returnObject.subscribe(
        response => {
          context.handleSuccessfullRefreshListPhoneNumberType(response)
        }
      )
    })
  }

  handleSuccessfullRefreshList(response){
      this.phoneNumbers = response.data.personPhoneObjects
  }

  handleSuccessfullRefreshListPerson(response){
    let context = this;
    this.persons = response.data.personObjects;
    for(const aux of context.phoneNumbers){
      let person = context.persons.find(x => x.BusinessEntityID== aux.BusinessEntityID);
      let newPersonPhone = new  personPhone ();
      newPersonPhone = aux;
      newPersonPhone.Person = person;
      context.viewPhoneNumbers.push(newPersonPhone);
    }
  }

  handleSuccessfullRefreshListPhoneNumberType(response){
    let context = this;
    this.phoneNumberTypes = response.data.phoneNumberTypeObjects;
    for (const aux of context.viewPhoneNumbers){
      let phoneNumberType = context.phoneNumberTypes.find(x => x.PhoneNumberTypeID == aux.PhoneNumberTypeID);
      aux.PhoneNumberType = phoneNumberType;
    }
  }

  deletePersonPhone(personPhone){
   let context = this
   this.dataService.DeleteData(personPhone.phoneNumber,function(returnObject){
     returnObject.subscribe(
       response =>{
         context.refreshList();
       }
     )
   })
   this.router.navigate(['list-phone-number']);
  }

  editPersonPhone(personPhone){
    this.router.navigate([`./edit-phone-number`, personPhone.phoneNumber])
  }

  addPersonPhone(){
    this.router.navigate(['add-phone-number']);
  }
  


}
