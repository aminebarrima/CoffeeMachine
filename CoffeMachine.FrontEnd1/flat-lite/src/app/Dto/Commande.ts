import { Badge } from "./Badge";
import { Boisson } from "./Boisson";

export class Commande {
 /* constructor(badge:Badge){
    this.badge=  badge;
    this.dateCommande=new Date();
  }*/
  constructor(){
    this.dateCommande=new Date();
  }
    commandeId: number;
    withMug:boolean;
    dateCommande:Date;
    badgeId: number;
    boissonId:number;
    memoeryFlage:boolean;
    sucre: number;
    badge:Badge;
    boisson:Boisson;
  }