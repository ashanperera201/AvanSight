import React, { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { Pharma } from "../Types";
import "../styles/PharmaComponent.css";
import { fetchAllPharma } from "../services/pharma.service";

const PharmaComponent: React.FC = () => {
  const [pharmaList, setPharmaList] = useState<Pharma[]>([]);

  useEffect(() => {
    fetchPharmaDetails();
  }, []);

  const fetchPharmaDetails = (): void => {
    fetchAllPharma().then((response) => {
      if (response && response.data) {
        setPharmaList(response.data)
      }
    });
  };

  return (
    <div className="pharma-container">
      <h1 className="pharma-title">Pharma Details</h1>
      <p className="pharma-subtitle">Clients of AvanSight.</p>

      <div className="pharma-list">
        {pharmaList.map((pharma, index) => (
          <Link
            to={`/${pharma.pharmaName}`}
            key={index}
            className="pharma-item-link"
          >
            <div className="pharma-item">
              <h3 className="pharma-item-title">{pharma.pharmaName}</h3>
              <p className="pharma-item-country">{pharma.country}</p>
            </div>
          </Link>
        ))}
      </div>
    </div>
  );
};

export default PharmaComponent;
