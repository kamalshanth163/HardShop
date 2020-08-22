import { Phone } from './phone';
import { Address } from './address';

export interface Customer {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
  phone: Phone[];
  address: Address[];
  gender: string;
  age: number;
  role: string;
  created: Date;
  lastActive: Date;
  photoUrl: string;
}
