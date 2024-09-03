import React, { useEffect, useRef } from "react";
import * as am5 from "@amcharts/amcharts5";
import * as am5xy from "@amcharts/amcharts5/xy";
import am5themes_Animated from "@amcharts/amcharts5/themes/Animated";
import { Patient } from "../Types";

interface IMultiSeriesBarChartProps {
  patients: Patient[];
}

const PatientsBarChart: React.FC<IMultiSeriesBarChartProps> = (
  props: IMultiSeriesBarChartProps
) => {
  const chartRef = useRef<HTMLDivElement>(null);
  const { patients } = props;

  useEffect(() => {
    let root = am5.Root.new(chartRef.current!);

    root.setThemes([am5themes_Animated.new(root)]);

    let chart = root.container.children.push(
      am5xy.XYChart.new(root, {
        panX: false,
        panY: false,
        layout: root.verticalLayout,
      })
    );

    let legend = chart.children.push(
      am5.Legend.new(root, {
        centerX: am5.p50,
        x: am5.p50,
      })
    );

    const genderMapping: any = {
      1: "Male",
      2: "Female",
    };

    const raceMapping: any = {
      1: "Asian",
      2: "Black",
      3: "White",
      4: "Other",
      5: "Not Specified",
    };

    const data = Object.values(raceMapping).map((raceLabel) => {
      const raceData = patients.filter(
        (patient) => raceMapping[patient.race] === raceLabel
      );
      return {
        race: raceLabel,
        Male: raceData.filter((patient) => patient.gender === 1).length,
        Female: raceData.filter((patient) => patient.gender === 2).length,
        NotReported: raceData.filter(
          (patient) => !genderMapping[patient.gender]
        ).length,
      };
    });

    let xAxis = chart.xAxes.push(
      am5xy.CategoryAxis.new(root, {
        categoryField: "race",
        renderer: am5xy.AxisRendererX.new(root, {
          minGridDistance: 20,
          cellStartLocation: 0.1,
          cellEndLocation: 0.9,
        }),
      })
    );

    let yAxis = chart.yAxes.push(
      am5xy.ValueAxis.new(root, {
        renderer: am5xy.AxisRendererY.new(root, {
          strokeOpacity: 0.1,
        }),
        extraMax: 0.1,
      })
    );

    xAxis.data.setAll(data);

    function createSeries(name: string, fieldName: string) {
      let series = chart.series.push(
        am5xy.ColumnSeries.new(root, {
          name: name,
          xAxis: xAxis,
          yAxis: yAxis,
          valueYField: fieldName,
          categoryXField: "race",
          stacked: true,
        })
      );

      series.columns.template.setAll({
        tooltipText: "{name}, {categoryX}: {valueY}",
        width: am5.percent(90),
      });

      series.data.setAll(data);

      series.appear();

      legend.data.push(series);
    }

    createSeries("Male", "Male");
    createSeries("Female", "Female");
    createSeries("NotReported", "NotReported");

    chart.appear(1000, 100);

    return () => {
      root.dispose();
    };
  }, [patients]);

  return (
    <>
      <h2 style={{ textAlign: "center" }}> Patient Distribution by Race & Gender</h2>
      <div ref={chartRef} style={{ width: "100%", height: "500px" }}></div>
    </>
  );
};

export default PatientsBarChart;
