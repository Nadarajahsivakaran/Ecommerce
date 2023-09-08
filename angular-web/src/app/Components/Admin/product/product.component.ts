import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { Product } from 'src/app/Models/product.model';
import { loadProduct } from 'src/app/Store/Product/product.action';
import { MatTableDataSource } from '@angular/material/table';
import { selectProducts } from 'src/app/Store/Product/product.selector';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css'],
})
export class ProductComponent implements OnInit {
  constructor(private store: Store) {}
  products: Product[] = [];
  dataSource!: MatTableDataSource<Product>;

  displayedColumns: string[] = [
    'productName',
    'price',
    'categoryName',
    'Action',
  ];
  ngOnInit(): void {
    this.store.dispatch(loadProduct());
    this.store.select(selectProducts).subscribe((items) => {
      this.products = items;
      this.dataSource = new MatTableDataSource<Product>(this.products);
    });
  }
}
