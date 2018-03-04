import { Component, OnInit } from '@angular/core';
import { BoissonService } from '../Services/boisson.service';
import { Boisson } from '../Dto/Boisson';
import { Commande } from '../Dto/Commande';
import { CommandeService } from '../Services/commande.service';

@Component({
  selector: 'app-commande',
  templateUrl: './commande.component.html',
  styleUrls: ['./commande.component.css']
})
export class CommandeComponent implements OnInit {
boissons:Boisson[];
commande:Commande;
sucre:number[]=[0,1, 2, 3];
  constructor(private boissonService: BoissonService,private commandeService:CommandeService) { }

  ngOnInit() {
    this.getBoissons();
  }
  getBoissons(): void {
    this.boissonService.getBoissons()
    .subscribe(boissons => this.boissons = boissons);
  }
  onSubmit() { 
    this.commandeService.AddCommande();
    }
}
