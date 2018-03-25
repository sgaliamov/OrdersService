export interface OrderModel {
  price?: number;
  address?: string;
  customerName?: string;
}

export interface OrderDto {
  id: string;
  price: number;
  address: string;
  customerName: string;
}
