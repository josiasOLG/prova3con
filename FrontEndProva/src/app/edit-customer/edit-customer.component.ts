import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../services/customer.service';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Customer } from '../customer';

@Component({
  selector: 'app-edit-customer',
  templateUrl: './edit-customer.component.html',
  styleUrls: ['./edit-customer.component.css']
})
export class EditCustomerComponent implements OnInit {
  formulario: FormGroup;
  customer:Customer = new Customer();
  url: string
  dados: any
  constructor(private customerService: CustomerService,
     private router: Router, private fb: FormBuilder, private route: ActivatedRoute) {
    this.url = this.router.url;
  }


  ngOnInit() {

    if(this.url == "/edit"){
        this.dados = this.route.snapshot.params;
        this.customer.id = this.dados.id;
    }
    this.formulario =  this.fb.group({
      id:[this.customer.id],
      name:[this.customer.name, [Validators.required]],
      registerDate:[this.customer.registerDate, [Validators.required]]
    });
  }

  onSubmit(){
      switch (this.router.url) {
          case "/new":
              this.customerService.newCustomer(this.formulario.value);
              break;
          default:
              this.customerService.editCustomer(this.formulario.value);
      }
  }

}
