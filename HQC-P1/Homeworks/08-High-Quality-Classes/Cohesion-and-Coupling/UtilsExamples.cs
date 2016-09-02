﻿using System;

namespace CohesionAndCoupling
{
    public class UtilsExamples
    {
        public static void Main()
        {
            Console.WriteLine(FileUtils.GetFileExtension("example"));
            Console.WriteLine(FileUtils.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtils.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine(
                "Distance in the 2D space = {0:f2}",
                EuclideanDistanceCalculator.CalcDistance2D(1, -2, 3, 4));
            Console.WriteLine(
                "Distance in the 3D space = {0:f2}",
                EuclideanDistanceCalculator.CalcDistance3D(5, 2, -1, 3, -6, 4));

            CuboidCalculator.Width = 3;
            CuboidCalculator.Height = 4;
            CuboidCalculator.Depth = 5;
            Console.WriteLine("Volume = {0:f2}", CuboidCalculator.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", CuboidCalculator.CalcDiagonalXYZ());
            Console.WriteLine("Diagonal XY = {0:f2}", CuboidCalculator.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", CuboidCalculator.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", CuboidCalculator.CalcDiagonalYZ());
        }
    }
}
