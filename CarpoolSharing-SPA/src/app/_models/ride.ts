import { Employee } from './employee';
import { Car } from './car';

export interface Ride {
    rideId: number;
    startLocation: string;
    endLocation: string;
    employee: Employee[];
    carPlates: string;
    car?: Car;
    startDate?: Date;
    endDate?: Date;
}
