﻿namespace BarChartRaceNet.Tools
{
    using BarChartRaceNet.Core;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Defines the <see cref="Statistics" />.
    /// </summary>
    public static class Statistics
    {
        #region Methods

        /// <summary>
        /// The Calculate.
        /// </summary>
        /// <param name="values">The values<see cref="IList{double}"/>.</param>
        /// <param name="statisticsMethod">The statisticsOutput<see cref="StatisticsMethod"/>.</param>
        /// <param name="digits">The digit<see cref="int"/>.</param>
        /// <returns>The <see cref="string"/>.</returns>
        public static string Calculate(this IList<double> values, StatisticsMethod statisticsMethod, int digits = 0)
        {
            double result;
            switch (statisticsMethod)
            {
                case StatisticsMethod.None:
                    return null;

                case StatisticsMethod.平均:
                    result = values.GetAverage();
                    return $"平均: {result.Format(digits)}";


                case StatisticsMethod.总和:
                    result = values.GetTotal();
                    return $"总和: {result.Format(digits)}";
                default:
                    result = values.GetTotal();
                    return $"总和: {result.Format(digits)}";
            }
        }

        public static string Format(this double value, int digits)
        {
            var format = "{0:N"+$"{digits}"+"}";
            var resultString = string.Format(format, value);
            return resultString;
        }

        /// <summary>
        /// The GetAverage.
        /// </summary>
        /// <param name="values">The values<see cref="IList{double}"/>.</param>
        /// <returns>The <see cref="double"/>.</returns>
        public static double GetAverage(this IList<double> values)
        {
            var total = values.GetTotal();
            var average = total / values.Count;
            return average;
        }

        /// <summary>
        /// The GetTotal.
        /// </summary>
        /// <param name="values">The values<see cref="IList{double}"/>.</param>
        /// <returns>The <see cref="double"/>.</returns>
        public static double GetTotal(this IList<double> values)
        {
            var total = 0.0;
            for (var i = 0; i < values.Count; i++)
            {
                total += values[i];
            }

            return total;
        }

        #endregion Methods
    }
}