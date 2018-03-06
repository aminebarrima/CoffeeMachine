import { Component, OnInit } from '@angular/core';
import { BoissonService } from '../Services/boisson.service';
import { Boisson } from '../Dto/Boisson';
import { Commande } from '../Dto/Commande';

import { CommandeService } from '../Services/commande.service';
import { NgForm } from '@angular/forms';
import { Badge } from '../Dto/Badge';

@Component({
  selector: 'app-commande',
  templateUrl: './commande.component.html',
  styleUrls: ['./commande.component.css']
})
export class CommandeComponent implements OnInit {
  boissons: Boisson[];
  badges:Badge[];
  commande = new Commande(new Badge());
  commandeSucces = false;
  badge = new Badge();
  sucretable: number[] = [0, 1, 2, 3];
  constructor(private boissonService: BoissonService, private commandeService: CommandeService) { }

  ngOnInit() {

    this.getBoissons();
  }
  getBoissons(): void {
    this.boissonService.getBoissons()
      .subscribe(boissons => this.boissons = boissons);
  }
  
  onSubmit(commandeForm: NgForm) {
    // this.commandeService.AddCommande();
    console.log(commandeForm.value);

    this.commandeService.AddCommande(this.commande)
      .subscribe(commande => {
        this.commande.commandeId = commande,
        this.commandeSucces=true
      });

  }
}
