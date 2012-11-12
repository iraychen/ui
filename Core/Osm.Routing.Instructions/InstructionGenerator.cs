﻿// OsmSharp - OpenStreetMap tools & library.
// Copyright (C) 2012 Abelshausen Ben
// 
// This file is part of OsmSharp.
// 
// OsmSharp is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 2 of the License, or
// (at your option) any later version.
// 
// OsmSharp is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with OsmSharp. If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Routing.Core.Route;
using Routing.Core.ArcAggregation.Output;
using Routing.Instructions.LanguageGeneration;

namespace Routing.Instructions
{
    public class InstructionGenerator
    {
        public List<Instruction> Generate(OsmSharpRoute raw_route)
        {
            return this.Generate(raw_route, 
                new Routing.Instructions.LanguageGeneration.Defaults.SimpleEnglishLanguageGenerator());
        }

        public List<Instruction> Generate(OsmSharpRoute raw_route, ILanguageGenerator language_generator)
        {
            Routing.Core.ArcAggregation.ArcAggregator aggregator = 
                new Routing.Core.ArcAggregation.ArcAggregator();
            AggregatedPoint point = 
                aggregator.Aggregate(raw_route);

            return this.Generate(point, language_generator);
        }

        public List<Instruction> Generate(AggregatedPoint aggregate_point)
        {
            return this.Generate(aggregate_point, 
                new Routing.Instructions.LanguageGeneration.Defaults.SimpleEnglishLanguageGenerator());
        }

        public List<Instruction> Generate(AggregatedPoint point, ILanguageGenerator language_generator)
        {
            Routing.Core.ArcAggregation.Output.AggregatedPoint p = point;
            while (p != null && p.Next != null)
            {
                // print point.
                Tools.Core.Output.OutputStreamHost.WriteLine("Point: {0}:", p.Location);

                if (p.ArcsNotTaken != null)
                {
                    foreach (KeyValuePair<Tools.Math.Geo.Meta.RelativeDirection, Routing.Core.ArcAggregation.Output.AggregatedArc> arc in p.ArcsNotTaken)
                    {
                        Tools.Core.Output.OutputStreamHost.WriteLine("ArcNotTaken:{0} - {1}", arc.Key.Direction.ToString(), arc.Value.Name);
                    }
                }

                if (p.Points != null)
                {
                    foreach (PointPoi poi in p.Points)
                    {
                        string angle_string = "None";
                        if(poi.Angle != null)
                        {
                            angle_string = poi.Angle.Direction.ToString();
                        }
                        Tools.Core.Output.OutputStreamHost.WriteLine("Poi [{0}]:{1}", poi.Name, angle_string);
                        foreach (KeyValuePair<string, string> tag in poi.Tags)
                        {
                            Tools.Core.Output.OutputStreamHost.WriteLine("PoiTag: {0}->{1}", tag.Key, tag.Value);
                        }
                    }
                }

                // print arc.
                if (p.Angle != null)
                {
                    Tools.Core.Output.OutputStreamHost.WriteLine("Arc: {0}[{1}] {2}", p.Angle.Direction, p.Next.Distance, p.Next.Name);
                }
                else
                {
                    Tools.Core.Output.OutputStreamHost.WriteLine("Arc: {0}[{1}]", p.Next.Name, p.Next.Distance);
                }
                Tools.Core.Output.OutputStreamHost.WriteLine("");

                p = p.Next.Next;
            }
            if (p != null)
            {
                Tools.Core.Output.OutputStreamHost.WriteLine("Point: {0}:", p.Location);
            }

            MicroPlanning.MicroPlanner planner = new MicroPlanning.MicroPlanner(language_generator);
            return planner.Plan(point);
        }
    }
}
