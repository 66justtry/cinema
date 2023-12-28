import { Component, OnDestroy, Inject } from '@angular/core';
import { DateChangeService } from '../services/date-change.service'; 
import { Subscription } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { DateService } from '../services/date.service';

@Component({
  selector: 'app-home-content',
  templateUrl: './home-content.component.html',
  styleUrls: ['./home-content.component.css']
})
export class HomeContentComponent implements OnDestroy{
  public isLoading = true;
  public movies: MovieSessionShort[] = [];
  private subscription: Subscription;
  
  getMovies(http: HttpClient, baseUrl: string, date: Date | null): void {
    let q = "";
    if (date !== null)
      q = "?date=" + date.getFullYear() + "-" + (date.getMonth() + 1) + "-" + date.getDate();
    http.get<MovieSessionShort[]>(baseUrl + 'api/movies' + q).subscribe(result => {
      
      this.movies = result;
      for (let m of this.movies)
          for (let s of m.sessions) {
            s.output = this.dateService.getTime(s.dateTime);
            s.isTooltipVisible = false;
          }
      this.isLoading = false;
    }, () => {});
  }
  
  constructor(private dateChangeService: DateChangeService, private dateService: DateService, http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.isLoading = true;
    this.getMovies(http, baseUrl, null);
    
    this.subscription = this.dateChangeService.currentDate.subscribe((date) => {
      this.movies = [];
      this.isLoading = true;
      this.getMovies(http, baseUrl, date);
    });
  }
  
  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
  
  showTooltip(s: SessionShort) {
    s.isTooltipVisible = true;
  }
  
  hideTooltip(s: SessionShort) {
    s.isTooltipVisible = false;
  }
}

interface MovieSessionShort {
  id: number;
  name: string;
  age: number;
  photoUrl: number;
  sessions: SessionShort[];
}

interface SessionShort {
  id: number;
  videoTypeName: string;
  dateTime: Date;
  price: number;
  output: string;
  isTooltipVisible: boolean;
}
