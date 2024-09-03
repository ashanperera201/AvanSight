import { useRef } from "react";
import { Gender, Patient } from "../Types";
import { ColDef } from "ag-grid-community";
import { AgGridReact } from "ag-grid-react";

interface IPatientGridProps {
  patients: Patient[];
}

const columnDefs: ColDef[] = [
  { headerName: "Patient ID", field: "patientIdentifier" },
  { headerName: "Age", field: "age" },
  {
    headerName: "Gender",
    field: "gender",
    valueGetter: (params) => {
      return params.data.gender === 1
        ? 'Male'
        : params.data.gender === 2
        ? 'Female'
        : 'Unknown';
    },
  },
  {
    headerName: "Race",
    field: "race",
    valueGetter: (params) => {
      return params.data.race === 1
        ? "Asian"
        : params.data.race === 2
        ? "Black"
        : params.data.race === 3
        ? "White"
        : "Not Specified";
    },
  },
  { headerName: "Enrollment Date", field: "enrollmentDate" },
  { headerName: "Reason", field: "reason" },
];

const PatientGrid = (props: IPatientGridProps): JSX.Element => {
  const { patients } = props;
  const gridRef = useRef<AgGridReact>(null);

  return (
    <>
      <div
        className="ag-theme-alpine"
        style={{ height: 400, width: "100%", marginBottom: "20px" }}
      >
        <AgGridReact
          ref={gridRef}
          rowData={patients}
          columnDefs={columnDefs}
          domLayout="autoHeight"
        />
      </div>
    </>
  );
};

export default PatientGrid;
