using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WinFormsAssignmentTwoApp2
{
    public partial class Form1 : Form
    {
        private TextBox dataInputTextBox;
        private Button generateButton;
        private Chart barChart;

        public Form1()
        {
            InitializeComponent();
            SetupForm();
        }

        private void SetupForm()
        {
            // Setup form elements here
            Panel textBoxPanel = new Panel
            {
                Location = new Point(100, 90),
                Size = new Size(325, 30),
                BackColor = Color.Green,
                BorderStyle = BorderStyle.FixedSingle
            };

            dataInputTextBox = new TextBox
            {
                Width = 300,
                Location = new Point(5, 3),
                BorderStyle = BorderStyle.None,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                BackColor = Color.LightGray,
                PlaceholderText = "Enter comma-separated integer values"
            };

            textBoxPanel.Controls.Add(dataInputTextBox);
            Controls.Add(textBoxPanel);

            generateButton = new Button
            {
                Text = "Generate Bar Chart",
                Location = new Point(450, 30)
            };

            barChart = new Chart
            {
                Dock = DockStyle.Bottom,
                Height = 400
            };

            Controls.Add(generateButton);
            Controls.Add(barChart);

            generateButton.Click += GenerateBarChart;
        }

        private void GenerateBarChart(object sender, EventArgs e)
        {
            // Clear chart data
            barChart.Series.Clear();
            barChart.ChartAreas.Clear();

            int[] numbers;
            try
            {
                numbers = dataInputTextBox.Text.Split(',').Select(int.Parse).ToArray();
            }
            catch
            {
                MessageBox.Show("Enter valid comma-separated integers.");
                return;
            }

            ChartArea chartArea = new ChartArea("MainArea");
            barChart.ChartAreas.Add(chartArea);

            Series series = new Series
            {
                Name = "BarSeries",
                ChartType = SeriesChartType.Bar,
                IsValueShownAsLabel = true
            };

            series["PointWidth"] = "0.5";

            Color[] colors = { Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Blue, Color.Purple, Color.Brown, Color.Black };

            for (int i = 0; i < numbers.Length; i++)
            {
                DataPoint dataPoint = new DataPoint
                {
                    YValues = new double[] { numbers[i] },
                    AxisLabel = "Data " + (i + 1),
                    Color = colors[i % colors.Length]
                };

                series.Points.Add(dataPoint);
            }

            barChart.Series.Add(series);

            chartArea.AxisX.Title = "Values";
            chartArea.AxisY.Title = "Bars";
            chartArea.AxisY.Interval = 1;

            barChart.Invalidate();
        }
    }
}
