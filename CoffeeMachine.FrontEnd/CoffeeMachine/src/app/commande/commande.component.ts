import { Component, OnInit } from '@angular/core';
import { BoissonService } from '../Services/boisson.service';
import { Boisson } from '../Dto/Boisson';
import { Commande } from '../Dto/Commande';

import { CommandeService } from '../Services/commande.service';
import { NgForm } from '@angular/forms';
import { Badge } from '../Dto/Badge';
import { BadgeService } from '../Services/badge.service';

@Component({
  selector: 'app-commande',
  templateUrl: './commande.component.html',
  styleUrls: ['./commande.component.css']
})
export class CommandeComponent implements OnInit {
  boissons: Boisson[];
  badges:Badge[];
  commande = new Commande();
  commandeSucces = false;
  badge = new Badge();
  sucretable: number[] = [0, 1, 2, 3];
  constructor(private boissonService: BoissonService, private commandeService: CommandeService, private BadgeService: BadgeService) { }

  ngOnInit() {

    this.getBoissons();
    this.getBadge();
  }
  getBoissons(): void {
    this.boissonService.getBoissons()
      .subscribe(boissons => this.boissons = boissons);
  }
  getCommandebyBadge(BadgeId: number): void {
    this.commandeService.getMemoeryCommandeByBadge(BadgeId)
      .subscribe(commande => {
        this.commande.boissonId =commande .boissonId,
        this.commande.badgeId =commande .badgeId,
        this.commande.sucre =commande .sucre,
        this.commande.withMug =commande .withMug,
        this.commande.memoeryFlage =commande .memoeryFlage,
        console.log(commande)
      });
  }
  getBadge(): void {
    this.BadgeService.getBadges()
      .subscribe(badges => this.badges = badges);
  }
  onChange(badgeId:number) {
    console.log(badgeId);
    this.getCommandebyBadge(badgeId);
    this.commandeSucces=false;
 
}

  onSubmit(commandeForm: NgForm) {    
    //console.log(commandeForm.value);
    this.commandeService.AddCommande(this.commande)
      .subscribe(commande => {
        this.commande.commandeId = commande,
        this.commandeSucces=true
      });
    }


reset(){
  this.commande = new Commande();
  this.commandeSucces=false;
}


  }
