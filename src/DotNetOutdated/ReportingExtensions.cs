﻿using System.Collections.Generic;
using System.Linq;

namespace DotNetOutdated
{
    public static class ReportingExtensions
    {
        public static string PackageTitle = "Package";
        public static string CurrentVersionTitle = "Current";
        public static string LatestVersionTitle = "Latest";
        public static string ProjectTitle = "Project and Target Framework";
        
        public static int[] DetermineColumnWidths(this List<ConsolidatedPackage> packages)
        {
            List<int> columnWidths = new List<int>();
            columnWidths.Add(packages.Select(p => p.Title).Aggregate(PackageTitle, (max, cur) => max.Length > cur.Length ? max : cur).Length);
            columnWidths.Add(packages.Select(p => p.ResolvedVersion.ToString()).Aggregate(CurrentVersionTitle, (max, cur) => max.Length > cur.Length ? max : cur).Length);
            columnWidths.Add(packages.Select(p => p.LatestVersion.ToString()).Aggregate(LatestVersionTitle, (max, cur) => max.Length > cur.Length ? max : cur).Length);
            columnWidths.Add(packages.SelectMany(p => p.Projects).Select(p => p.Name).Aggregate(ProjectTitle, (max, cur) => max.Length > cur.Length ? max : cur).Length);

            return columnWidths.ToArray();
        }
    }
}