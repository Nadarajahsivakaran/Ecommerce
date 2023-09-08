import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { loadCategory } from 'src/app/Store/Category/category.action';
import { MatTableDataSource } from '@angular/material/table';
import { Category } from 'src/app/Models/category.model';
import { selectCategories } from 'src/app/Store/Category/category.selector';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.css'],
})
export class CategoryComponent implements OnInit {
  constructor(private store: Store) {}
  categories: Category[] = [];
  dataSource!: MatTableDataSource<Category>;

  displayedColumns: string[] = ['categoryName', 'Action'];

  ngOnInit(): void {
    this.store.dispatch(loadCategory());

    this.store.select(selectCategories).subscribe((items) => {
      this.categories = items;
      this.dataSource = new MatTableDataSource<Category>(this.categories);
    });
  }
}
