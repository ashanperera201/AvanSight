export enum Gender {
    Unknown,
    Male,
    Female,
}

export enum Race {
    Unknown,
    Asian,
    Black,
    White,
    Other,
    NotReported
}

/*add other types*/
export interface Patient {
    patientIdentifier: string;
    age: number;
    gender: Gender;
    race: Race;
    dateOfConsent: Date;
    screenFailureReason?: string;
    screenFailedDate?: Date;
    studyIdentifier: string;
}

export interface Pharma {
    pharmaName: string;
    country: string;
    studies: Study[];
}

export interface Study {
    id: number;
    studyIdentifier: string;
    projectNumber: string;
    studyName: string;
    patients: Patient[];
}