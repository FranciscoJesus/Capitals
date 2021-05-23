import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { CapitalViewModel } from './capitals.model';
import { CapitalsService } from './capitals.service';

@Component({
  selector: 'app-capitals',
  templateUrl: './capitals.component.html',
  styleUrls: ['./capitals.component.scss']
})
export class CapitalsComponent implements OnInit {

  searchForm: FormGroup;
  capitals: CapitalViewModel[] = [];

  constructor(private capitalsService: CapitalsService,
              private fb: FormBuilder) { }

  ngOnInit(): void {
    this.searchForm = this.fb.group({
      countrySearch: ''
    });
  }

  searchCapital() : void{
    let country = this.searchForm.get('countrySearch')?.value;
    if(country){
      this.capitalsService.getCapitalsByCountry(country).subscribe(capitals => 
        {
          this.capitals = capitals;
        }, error => {
          this.capitals = [];
        })
    }
  }

}
