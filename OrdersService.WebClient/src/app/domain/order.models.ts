export interface OrderEditModel {
  city?: string;
  country?: string;
  customerName?: string;
  number?: string;
  phone?: string;
  postCode?: string;
  price?: string;
  street?: string;
}

export interface OrderDto {
  city: string;
  country: string;
  customerName: string;
  number?: string;
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
