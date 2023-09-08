export class ApiResponse {
  isSuccess: boolean;
  statusCode: number;
  message: any;
  res: any;

  constructor(isSuccess: boolean, statusCode: number, message: any, res: any) {
    (this.isSuccess = isSuccess),
      (this.statusCode = statusCode),
      (this.message = message),
      (this.res = res);
  }
}
