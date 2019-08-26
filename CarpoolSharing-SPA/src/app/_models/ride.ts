import { Employee } from './employee';
import { Car } from './car';

export interface Ride {
    rideId?: number;
    startLocation?: string;
    endLocation?: string;
    employeeRides?: Employee[];
    employees?: Employee[];
    carPlates?: string;
    car?: Car;
    startDate?: string;
    endDate?: string;
    carId?: number;
}
