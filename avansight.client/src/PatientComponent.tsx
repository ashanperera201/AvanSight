import { useEffect, useState, useRef } from 'react';
import { useLocation, useParams } from 'react-router-dom';
import { AgGridReact } from 'ag-grid-react';
import { ColDef, GridReadyEvent } from 'ag-grid-community';
import * as am5 from "@amcharts/amcharts5";
import * as am5xy from "@amcharts/amcharts5/xy";
import * as am5percent from "@amcharts/amcharts5/percent";
import { Patient, Gender, Race } from './Types';
import 'ag-grid-community/styles/ag-grid.css';
import 'ag-grid-community/styles/ag-theme-alpine.css';
import { Breadcrumb } from './Breadcrumb';

const drawBarChart = (chartDivId: string, patients: Patient[]) => {

};

const drawPieChart = (chartDivId: string, patients: Patient[]) => {

};



export const PatientComponent = () => {
   
    return (
        <div>
           
        </div>
    );
};
