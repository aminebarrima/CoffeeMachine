
import { RegisterBindingModel } from '../Dto/register.model';
import { RegisterService } from '../Services/register.service';
import { ToastrService } from 'ngx-toastr';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

 


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
register = new RegisterBindingModel();

resultatSucces=false;
resultat="";
  constructor(private RegisterService: RegisterService,private toastr: ToastrService) { }

  ngOnInit() {
  }
  onSubmit()
{
this.RegisterService.register(this.register).
subscribe(res=>{
  console.log(res) ,
  this.resultatSucces=true,
this.resultat=res.Message,
this.toastr.success('Opération terminé avec succès', 'Créer un Compte');
},
);


}

}
