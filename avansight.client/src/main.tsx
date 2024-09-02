import { StrictMode } from 'react';
import { createRoot } from 'react-dom/client';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import { PharmaComponent } from './PharmaComponent';
import { StudyComponent } from './StudyComponent';
import { PatientComponent } from './PatientComponent';
import './index.css';

createRoot(document.getElementById('root')!).render(
    /*Use routing*/
);
