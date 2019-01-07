export interface OrderModel {
  city?: string;
  country?: string;
  customerName?: string;
  number?: number;
  phone?: string;
  postCode?: string;
  price?: string;
  street?: string;
}

export interface OrderDto {
  city: string;
  country: string;
  customerName: string;
  number?: number;
  orderId: string;
  phone: string;
  postCode: string;
  price: string;
  street: string;
}

export interface PagedResult<T> {
  total: number;
  data: T;
}
