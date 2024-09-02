import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { Patient } from "../Types";
import "ag-grid-community/styles/ag-grid.css";
import "ag-grid-community/styles/ag-theme-alpine.css";
import Breadcrumb from "./Breadcrumb";
import PatientsBarChart from "./PatientsBarChart";
import { fetchPatients } from "../services/pharma.service";
import PatientGrid from "./PatientGrid";

const PatientComponent: React.FC = () => {
  const { pharmaName, studyName } = useParams();
  const [patients, setPatients] = useState<Patient[]>([]);

  useEffect(() => {
    fetchPatientDetails();
  }, [studyName, pharmaName]);

  const fetchPatientDetails = (): void => {
    fetchPatients(pharmaName!, studyName!).then((response) => {
      if (response && response.data) {
        setPatients(response.data);
      }
    });
  };

  return (
    <div>
      {patients && patients.length > 0 ? (
        <>
          <Breadcrumb />

          <h2>Patients in {studyName}</h2>

          <PatientGrid patients={patients} />

          <div style={{ marginTop: 120 }}>
            <PatientsBarChart />
          </div>
        </>
      ) : (
        <></>
      )}
    </div>
  );
};

export default PatientComponent;
