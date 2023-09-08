import { ApiResponse } from './api-response.model';

describe('ApiResponse', () => {
  it('should create an instance', () => {
    const isSuccess = true;
    const statusCode =2000;
    const message = "test";
    const res = "response";
    expect(new ApiResponse(isSuccess,statusCode,message,res)).toBeTruthy();
  });
});
