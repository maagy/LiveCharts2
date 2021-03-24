﻿using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Input;

namespace ViewModelsSamples.Lines.Properties
{
    public class ViewModel
    {
        private readonly LineSeries<double> lineSeries;
        private readonly Color[] colors = ColorPacks.FluentDesign;
        private readonly Random random = new Random();
        private int currentColor = 0;

        public ViewModel()
        {
            lineSeries = new LineSeries<double>
            {
                Values = new List<double> { -2, -1, 3, 5, 3, 4, 6 },
                LineSmoothness = 0.5
            };

            Series = new List<ISeries>();
            Series.Add(lineSeries);
        }

        public List<ISeries> Series { get; set; }

        public void ChangeValuesInstance()
        {
            var t = 0;
            var values = new List<double>();
            for (int i = 0; i < 10; i++)
            {
                t += random.Next(-5, 10);
                values.Add(t);
            }

            lineSeries.Values = values;
        }

        public void NewStroke()
        {
            var nextColorIndex = currentColor++ % colors.Length;
            var color = colors[nextColorIndex];
            lineSeries.Stroke = new SolidColorPaintTask(new SKColor(color.R, color.G, color.B)) { StrokeThickness = 3 };
        }

        public void NewFill()
        {
            var nextColorIndex = currentColor++ % colors.Length;
            var color = colors[nextColorIndex];

            lineSeries.Fill = new SolidColorPaintTask(new SKColor(color.R, color.G, color.B, 90));
        }

        public void NewGeometryFill()
        {
            var nextColorIndex = currentColor++ % colors.Length;
            var color = colors[nextColorIndex];

            lineSeries.GeometryFill = new SolidColorPaintTask(new SKColor(color.R, color.G, color.B));
        }

        public void NewGeometryStroke()
        {
            var nextColorIndex = currentColor++ % colors.Length;
            var color = colors[nextColorIndex];

            lineSeries.GeometryStroke = new SolidColorPaintTask(new SKColor(color.R, color.G, color.B)) { StrokeThickness = 3 };
        }

        public void IncreaseLineSmoothness()
        {
            if (lineSeries.LineSmoothness == 1) return;

            lineSeries.LineSmoothness += 0.1;
        }

        public void DecreaseLineSmoothness()
        {
            if (lineSeries.LineSmoothness == 0) return;

            lineSeries.LineSmoothness -= 0.1;
        }

        public void IncreaseGeometrySize()
        {
            if (lineSeries.GeometrySize == 60) return;

            lineSeries.GeometrySize += 10;
        }

        public void DecreaseGeometrySize()
        {
            if (lineSeries.GeometrySize == 0) return;

            lineSeries.GeometrySize -= 10;
        }

        // The next commands are only to enable XAML bindings
        // they are not used in the WinForms sample
        public ICommand ChangeValuesInstanceCommand => new Command(o => ChangeValuesInstance());
        public ICommand NewStrokeCommand => new Command(o => NewStroke());
        public ICommand NewFillCommand => new Command(o => NewFill());
        public ICommand NewGeometryFillCommand => new Command(o => NewGeometryFill());
        public ICommand NewGeometryStrokeCommand => new Command(o => NewGeometryStroke());
        public ICommand IncreaseLineSmoothnessCommand => new Command(o => IncreaseLineSmoothness());
        public ICommand DecreseLineSmoothnessCommand => new Command(o => DecreaseLineSmoothness());
        public ICommand IncreaseGeometrySizeCommand => new Command(o => IncreaseGeometrySize());
        public ICommand DecreseGeometrySizeCommand => new Command(o => DecreaseGeometrySize());
    }
}
