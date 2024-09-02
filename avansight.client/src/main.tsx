import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import PharmaComponent from "./components/PharmaComponent";
import StudyComponent from "./components/StudyComponent";
import PatientComponent from "./components/PatientComponent";
import "./index.css";

createRoot(document.getElementById("root")!).render(
  <Router>
    <Routes>
      <Route path="/" element={<PharmaComponent />} />
      <Route path="/:pharmaName" element={<StudyComponent />} />
      <Route path="/:pharmaName/:studyName" element={<PatientComponent />} />
    </Routes>
  </Router>
);
