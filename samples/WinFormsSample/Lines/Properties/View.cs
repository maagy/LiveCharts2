﻿using LiveChartsCore.SkiaSharpView.WinForms;
using System.Windows.Forms;
using ViewModelsSamples.Lines.Properties;

namespace WinFormsSample.Lines.Properties
{
    public partial class View : UserControl
    {
        private readonly CartesianChart cartesianChart;

        public View()
        {
            InitializeComponent();
            Size = new System.Drawing.Size(100, 100);

            var viewModel = new ViewModel();

            cartesianChart = new CartesianChart
            {
                Series = viewModel.Series,

                // out of livecharts properties...
                Location = new System.Drawing.Point(0, 50),
                Size = new System.Drawing.Size(100, 50),
                Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom
            };

            Controls.Add(cartesianChart);

            var b1 = new Button { Text = "new values", Location = new System.Drawing.Point(0, 0) };
            b1.Click += (object sender, System.EventArgs e) => viewModel.ChangeValuesInstance();
            Controls.Add(b1);

            var b2 = new Button { Text = "new fill", Location = new System.Drawing.Point(80, 0) };
            b2.Click += (object sender, System.EventArgs e) => viewModel.NewFill();
            Controls.Add(b2);

            var b3 = new Button { Text = "new stroke", Location = new System.Drawing.Point(160, 0) };
            b3.Click += (object sender, System.EventArgs e) => viewModel.NewStroke();
            Controls.Add(b3);

            var b4 = new Button { Text = "newGfill", Location = new System.Drawing.Point(240, 0) };
            b4.Click += (object sender, System.EventArgs e) => viewModel.NewGeometryFill();
            Controls.Add(b4);

            var b5 = new Button { Text = "newGstroke", Location = new System.Drawing.Point(320, 0) };
            b5.Click += (object sender, System.EventArgs e) => viewModel.NewGeometryStroke();
            Controls.Add(b5);

            var b6 = new Button { Text = "+ smooth", Location = new System.Drawing.Point(400, 0) };
            b6.Click += (object sender, System.EventArgs e) => viewModel.IncreaseLineSmoothness();
            Controls.Add(b6);

            var b7 = new Button { Text = "- smooth", Location = new System.Drawing.Point(480, 0) };
            b7.Click += (object sender, System.EventArgs e) => viewModel.DecreaseLineSmoothness();
            Controls.Add(b7);

            var b8 = new Button { Text = "+ size", Location = new System.Drawing.Point(560, 0) };
            b8.Click += (object sender, System.EventArgs e) => viewModel.IncreaseGeometrySize();
            Controls.Add(b6);

            var b9 = new Button { Text = "- size", Location = new System.Drawing.Point(620, 0) };
            b9.Click += (object sender, System.EventArgs e) => viewModel.DecreaseGeometrySize();
            Controls.Add(b7);
        }
    }
}
