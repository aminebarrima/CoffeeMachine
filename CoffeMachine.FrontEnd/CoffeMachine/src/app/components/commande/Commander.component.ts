import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-commander',
  template: '<router-outlet><spinner></spinner></router-outlet>'
})
export class CommanderComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
