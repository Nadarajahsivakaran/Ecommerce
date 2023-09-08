import { Category } from './category.model';
import { Product } from './product.model';

describe('Product', () => {
  it('should create an instance', () => {
    const productId = 1;
    const productName = 'Product';
    const description = 'Product des';
    const imageUrl = 'image';
    const price = 200;
    const category: Category = {
      categoryId: 1,
      categoryName: 'category',
    };
    expect(
      new Product(
        productId,
        productName,
        description,
        imageUrl,
        price,
        category
      )
    ).toBeTruthy();
  });
});
