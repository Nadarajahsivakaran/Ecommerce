import { Category } from './category.model';

export class Product {
  productId: number;
  productName: string;
  description: string;
  imageUrl: string;
  price: number;
  category: Category;

  constructor(
    productId: number,
    productName: string,
    description: string,
    imageUrl: string,
    price: number,
    category: Category
  ) {
    this.productId = productId;
    (this.productName = productName),
      (this.description = description),
      (this.imageUrl = imageUrl),
      (this.price = price),
      (this.category = category);
  }
}
