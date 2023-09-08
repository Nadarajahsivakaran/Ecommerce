import { Category } from './category.model';

describe('Category', () => {
  it('should create an instance', () => {
    const categoryId = 1; // Replace with the actual ID you want to use
    const categoryName = 'Test Category'; // Replace with the actual name you want to use
    expect(new Category(categoryId, categoryName)).toBeTruthy();
  });
});
