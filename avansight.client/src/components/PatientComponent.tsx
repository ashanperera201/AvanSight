import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { Patient } from "../Types";
import "ag-grid-community/styles/ag-grid.css";
import "ag-grid-community/styles/ag-theme-alpine.css";
import Breadcrumb from "./Breadcrumb";
import PatientsBarChart from "./PatientsBarChart";
import { fetchPatients } from "../services/pharma.service";
import PatientGrid from "./PatientGrid";
import PieChartComponent from "./PatientPieChart";

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
          <div
            style={{
              width: "100%",
              display: "flex",
              justifyContent: 'center'
            }}
          >
            <div
              style={{ width: "60%", display: "flex", flexDirection: "column" }}
            >
              <Breadcrumb />

              <h2>Patients in {studyName}</h2>

              <PatientGrid patients={patients} />

              <div style={{ marginTop: 120 }}>
                <PatientsBarChart patients={patients} />
              </div>
              <div style={{ marginTop: 120 }}>
                <PieChartComponent patients={patients} />
              </div>
            </div>
          </div>
        </>
      ) : (
        <></>
      )}
    </div>
  );
};

export default PatientComponent;
