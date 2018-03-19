import { Component, OnInit } from '@angular/core';
import { RegisterBindingModel } from '../Dto/register.model';
import { RegisterService } from '../Services/register.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
register = new RegisterBindingModel();

resultatSucces=false;
resultat="";
  constructor(private RegisterService: RegisterService) { }

  ngOnInit() {
  }
  onSubmit()
{
this.RegisterService.register(this.register).
subscribe(res=>{
  console.log(res) ,
  this.resultatSucces=true,
this.resultat=res.Message
},
);


}

}
