using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Graphs
{
    public partial class RateCurvePlots : Form
    {
        double Amplitude;
        SortedDictionary<double, double> Points;

        public RateCurvePlots(SortedDictionary<double, double> points, double amplitude = 0.5)
        {
            Amplitude = amplitude;
            Points = new SortedDictionary<double, double>(points);
            InitializeComponent();
        }


        //private System.ComponentModel.IContainer components = null;
        Chart RateCurveChart;


        private void RateCurveChart_Load(object sender, EventArgs e)
        {
            RateCurveChart.Series.Clear();
            var series1 = new Series
            {
                Name = "Series1",
                Color = System.Drawing.Color.Blue,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Line
            };

            RateCurveChart.Series.Add(series1);

            foreach (var p in Points)
            {
                series1.Points.AddXY(p.Key.ToString(), p.Value);
            }

            RateCurveChart.Invalidate();
        }


        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ChartArea chartArea1 = new ChartArea();
            Legend legend1 = new Legend();
            RateCurveChart = new Chart();
            ((System.ComponentModel.ISupportInitialize)(RateCurveChart)).BeginInit();
            SuspendLayout();
            //
            // RateCurveChart
            //
            chartArea1.Name = "ChartArea1";
            chartArea1.AxisX.Minimum = 0;
            chartArea1.AxisX.Maximum = 30;
            chartArea1.AxisX.Interval = 5;
            chartArea1.AxisX.LogarithmBase = Math.E;
            RateCurveChart.ChartAreas.Add(chartArea1);
            RateCurveChart.Dock = DockStyle.Fill;
            legend1.Name = "Legend1";
            RateCurveChart.Legends.Add(legend1);
            RateCurveChart.Location = new System.Drawing.Point(0, 50);
            RateCurveChart.Name = "RateCurve";
            // this.chart1.Size = new System.Drawing.Size(284, 212);
            RateCurveChart.TabIndex = 0;
            RateCurveChart.Text = "Interest Rate Curve";
            //
            // RateCurve Form
            //
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(484, 462);
            Controls.Add(RateCurveChart);
            Name = "RandomChart";
            Text = "Rate Curve";
            Load += new EventHandler(RateCurveChart_Load);
            ((System.ComponentModel.ISupportInitialize)(RateCurveChart)).EndInit();
            ResumeLayout(false);
        }
    }
}
