﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Tools.Math.TSP.Problems;
using Tools.TSPLIB.Problems;

namespace Tools.TSPLIB.Parser
{
    public class TSPLIBProblemGenerator
    {
        private const string TOKEN_NAME = "NAME:";
        private const string TOKEN_EOF = "EOF";
        private const string TOKEN_TYPE = "TYPE:";
        private const string TOKEN_DIMENSION = "DIMENSION:";
        private const string TOKEN_TYPE_VALUE_TSP = "TSP";
        private const string TOKEN_TYPE_VALUE_ATSP = "ATSP";
        private const string TOKEN_COMMENT = "COMMENT:";
        private const string TOKEN_EDGE_WEIGHT_TYPE = "EDGE_WEIGHT_TYPE:";
        private const string TOKEN_EDGE_WEIGHT_TYPE_VALUE_EUC_2D = "EUC_2D";
        private const string TOKEN_EDGE_WEIGHT_TYPE_EXPLICIT = "EXPLICIT";
        private const string TOKEN_EDGE_WEIGHT_FORMAT = "EDGE_WEIGHT_FORMAT:";
        private const string TOKEN_EDGE_WEIGHT_FORMAT_MATRIX = "MATRIX";
        private const string TOKEN_EDGE_WEIGHT_SECTION = "EDGE_WEIGHT_SECTION";
        private const string TOKEN_NODE_COORD_SECTION = "NODE_COORD_SECTION";

        public static void Generate(FileInfo file, TSPLIBProblem problem)
        {
            StreamWriter writer = new StreamWriter(file.OpenWrite());

            TSPLIBProblemGenerator.Generate(writer, problem);
        }

        public static void Generate(StreamWriter writer, TSPLIBProblem problem)
        {
            if (problem.Symmetric)
            {
                TSPLIBProblemGenerator.GenerateTSP(writer, problem);
            }
            else
            {
                TSPLIBProblemGenerator.GenerateATSP(writer, problem);
            }
        }

        private static void GenerateTSP(StreamWriter writer, TSPLIBProblem problem)
        {
            writer.WriteLine(string.Format("NAME: {0}", problem.Name));
            writer.WriteLine("TYPE: TSP");
            writer.WriteLine(string.Format("COMMENT: {0}", problem.Comment));
            writer.WriteLine(string.Format("DIMENSION: {0}", problem.Size));
            writer.WriteLine("EDGE_WEIGHT_TYPE: EXPLICIT");
            writer.WriteLine("EDGE_WEIGHT_FORMAT: FULL_MATRIX");
            //writer.WriteLine("EDGE_WEIGHT_FORMAT: UPPER_ROW");
            writer.WriteLine("DISPLAY_DATA_TYPE: TWOD_DISPLAY");
            writer.WriteLine("EDGE_WEIGHT_SECTION");

            //// get the biggest weight.
            //int max = 0;
            //int[][] upper_rows = new int[problem.Size - 1][];
            //for (int x = 0; x < problem.Size - 1; x++)
            //{
            //    upper_rows[x] = new int[problem.Size - 1 - x];
            //    for (int y = 0; y < problem.Size - 1 - x; y++)
            //    {
            //        int value = (int)problem.WeightMatrix[x][y];
            //        if (value > max)
            //        {
            //            max = value;
            //        }
            //        upper_rows[x][y] = value;
            //    }
            //}

            // get the biggest weight.
            int max = 0;
            int[][] upper_rows = new int[problem.Size][];
            for (int x = 0; x < problem.Size; x++)
            {
                upper_rows[x] = new int[problem.Size];
                for (int y = 0; y < problem.Size; y++)
                {
                    int value = (int)problem.WeightMatrix[x][y];
                    if (value > max)
                    {
                        max = value;
                    }
                    upper_rows[x][y] = value;
                }
            }

            int length = max.ToString().Length;
            for (int x = 0; x < upper_rows.Length; x++)
            {
                for (int y = 0; y < upper_rows[x].Length; y++)
                {
                    if (y > 0)
                    {
                        writer.Write(" ");
                    }
                    writer.Write(upper_rows[x][y].ToString().PadLeft(length));
                }
                writer.WriteLine();
            }
            writer.WriteLine("EOF");
            writer.Flush();
        }

        private static void GenerateATSP(StreamWriter writer, TSPLIBProblem problem)
        {
            writer.WriteLine(string.Format("NAME: {0}", problem.Name));
            writer.WriteLine("TYPE: ATSP");
            writer.WriteLine(string.Format("COMMENT: {0}", problem.Comment));
            writer.WriteLine(string.Format("DIMENSION: {0}", problem.Size));
            writer.WriteLine("EDGE_WEIGHT_TYPE: EXPLICIT");
            writer.WriteLine("EDGE_WEIGHT_FORMAT: FULL_MATRIX");
            //writer.WriteLine("EDGE_WEIGHT_FORMAT: UPPER_ROW");
            writer.WriteLine("DISPLAY_DATA_TYPE: TWOD_DISPLAY");
            writer.WriteLine("EDGE_WEIGHT_SECTION");

            //// get the biggest weight.
            //int max = 0;
            //int[][] upper_rows = new int[problem.Size - 1][];
            //for (int x = 0; x < problem.Size - 1; x++)
            //{
            //    upper_rows[x] = new int[problem.Size - 1 - x];
            //    for (int y = 0; y < problem.Size - 1 - x; y++)
            //    {
            //        int value = (int)problem.WeightMatrix[x][y];
            //        if (value > max)
            //        {
            //            max = value;
            //        }
            //        upper_rows[x][y] = value;
            //    }
            //}

            // get the biggest weight.
            int max = 0;
            int[][] upper_rows = new int[problem.Size][];
            for (int x = 0; x < problem.Size; x++)
            {
                upper_rows[x] = new int[problem.Size];
                for (int y = 0; y < problem.Size; y++)
                {
                    int value = (int)problem.WeightMatrix[x][y];
                    if (value > max)
                    {
                        max = value;
                    }
                    upper_rows[x][y] = value;
                }
            }

            int length = max.ToString().Length;
            for (int x = 0; x < upper_rows.Length; x++)
            {
                for (int y = 0; y < upper_rows[x].Length; y++)
                {
                    if (y > 0)
                    {
                        writer.Write(" ");
                    }
                    writer.Write(upper_rows[x][y].ToString().PadLeft(length));
                }
                writer.WriteLine();
            }
            writer.WriteLine("EOF");
            writer.Flush();
        }
    }
}