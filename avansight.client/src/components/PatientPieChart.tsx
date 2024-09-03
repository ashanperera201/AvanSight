import React, { useEffect, useRef } from "react";
import * as am5 from "@amcharts/amcharts5";
import * as am5percent from "@amcharts/amcharts5/percent";
import am5themes_Animated from "@amcharts/amcharts5/themes/Animated";
import { Patient } from "../Types";

interface IPieChartComponentProps {
  patients: Patient[];
}

const PieChartComponent: React.FC<IPieChartComponentProps> = (
  props: IPieChartComponentProps
) => {
  const chartRef = useRef<HTMLDivElement>(null);

  const genderMapping: any = {
    1: "Male",
    2: "Female",
  };

  const { patients } = props;

  useEffect(() => {
    let root = am5.Root.new(chartRef.current!);
    root.setThemes([am5themes_Animated.new(root)]);

    let chart = root.container.children.push(
      am5percent.PieChart.new(root, {
        endAngle: 270,
      })
    );

    let series = chart.series.push(
      am5percent.PieSeries.new(root, {
        valueField: "value",
        categoryField: "category",
        endAngle: 270,
      })
    );

    series.states.create("hidden", {
      endAngle: -90,
    });

    const data = Object.keys(genderCount).map(gender => ({
        category: gender,
        value: genderCount[gender]
      }));


    series.data.setAll([...data]);

    series.appear(1000, 100);

    return () => {
      root.dispose();
    };
  }, []);

  const genderCount = patients.reduce(
    (acc: { [key: string]: number }, patient) => {
      const genderLabel = genderMapping[patient.gender] || "Other"; 

      if (!acc[genderLabel]) {
        acc[genderLabel] = 0;
      }

      acc[genderLabel]++;
      return acc;
    },
    {}
  );

  return (
    <>
      <h2 style={{ textAlign: "center" }}> Patient Distribution by Gender</h2>
      <div ref={chartRef} style={{ width: "100%", height: "500px" }}></div>
    </>
  );
};

export default PieChartComponent;
