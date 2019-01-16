using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace MainModule.Signals
{
    public interface ISignal
    {       
        /// <summary>
        /// Взаимоисключающее с SetPeriods
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        void SetBorders(double left, double right);
        /// <summary>
        /// Взаимоисключающее с SetBorders
        /// </summary>
        void SetPeriods(int periods);
        /// <summary>
        /// Возвращает набор точек, по которым строиться сигнал
        /// </summary>
        /// <returns></returns>
        CoordPair DrawOsc();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        CoordPair DrawAmpSpec();

        Pair<double, double> SpecBorders();

        void SetFreqSpan(double hz);

        CoordPair DrawPhaSpec();

        void SetPhaseSpan(double hz);

        SeriesChartType OscType();
        SeriesChartType AmpSpecType();
        SeriesChartType PhaseSpecType();
    }
}
