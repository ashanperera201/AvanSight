import { Pharma, Study } from '../Types';
import axiosBase from './axios-base.service';


export const fetchAllPharma = () => {
    const url: string = `/Pharma`;
    return axiosBase.get<Pharma[]>(url)
}


export const fetchStudies = (pharmaName: string) => {
    const url: string = `/Pharma/${pharmaName}`;
    return axiosBase.get<Study[]>(url)
}

export const fetchPatients = (pharma: string, study: string) => {
    const url: string = `/Pharma/${pharma}/study/${study}`;
    return axiosBase.get(url)
}