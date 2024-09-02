import React, { useEffect, useState } from "react";
import { useParams, Link } from "react-router-dom";
import { Study } from "../Types";
import Breadcrumb from "./Breadcrumb"; 
import { fetchStudies } from "../services/pharma.service";

const StudyComponent: React.FC = () => {
  const { pharmaName } = useParams<{ pharmaName: string }>();
  const [studies, setStudies] = useState<Study[]>([]);

  useEffect(() => {
    if (pharmaName) {
      getStudies(pharmaName);
    }
  }, [pharmaName]);

  const getStudies = (pharmaName: string): void => {
    fetchStudies(pharmaName).then(result => {
      if(result && result.data) {
        setStudies(result.data);
      }
    })
  };

  return (
    <div style={{ padding: "20px" }}>
      <Breadcrumb />
      
      <h2>Studies for {pharmaName}</h2>
      <div
        style={{
          display: "flex",
          flexDirection: "column",
          gap: "10px",
          marginTop: "20px",
        }}
      >
        {studies.map((study, index) => (
          <Link
            to={`/${pharmaName}/${study.studyName}`}
            key={index}
            style={{ textDecoration: "none" }}
          >
            <div
              style={{
                border: "1px solid #ddd",
                borderRadius: "8px",
                padding: "15px",
                cursor: "pointer",
                boxShadow: "0 2px 4px rgba(0,0,0,0.1)",
                backgroundColor: "#fff",
              }}
            >
              <h3 style={{ margin: 0 }}>{study.studyName}</h3>
              <p style={{ margin: "5px 0", color: "#555" }}>
                {study.studyIdentifier}
              </p>
              <p style={{ margin: "5px 0", color: "#999" }}>{study.projectNumber}</p>
            </div>
          </Link>
        ))}
      </div>
    </div>
  );
};

export default StudyComponent;
