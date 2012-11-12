﻿//// OsmSharp - OpenStreetMap tools & library.
//// Copyright (C) 2012 Abelshausen Ben
//// 
//// This file is part of OsmSharp.
//// 
//// OsmSharp is free software: you can redistribute it and/or modify
//// it under the terms of the GNU General Public License as published by
//// the Free Software Foundation, either version 2 of the License, or
//// (at your option) any later version.
//// 
//// OsmSharp is distributed in the hope that it will be useful,
//// but WITHOUT ANY WARRANTY; without even the implied warranty of
//// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
//// GNU General Public License for more details.
//// 
//// You should have received a copy of the GNU General Public License
//// along with OsmSharp. If not, see <http://www.gnu.org/licenses/>.
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Osm.Data.Core.Processor;
//using Routing.CH.PreProcessing;
//using Osm.Core.Simple;
//using Osm.Routing.Core.Processor;
//using Tools.Math.Geo;
//using Osm.Routing.Core.Roads.Tags;
//using Osm.Data.Core.DynamicGraph;
//using Routing.CH.PreProcessing.Tags;
//using Routing.CH.Routing;

//namespace Routing.CH.Processor
//{
//    /// <summary>
//    /// Data processor target for osm data that will be converted into a Contracted Graph.
//    /// </summary>
//    public class CHDataProcessorTarget : DynamicGraphDataProcessorTarget<CHEdgeData>
//    {
//        /// <summary>
//        /// Creates a new tags index.
//        /// </summary>
//        private CHDataSource _data_source;

//        /// <summary>
//        /// Creates a new CH data processor target.
//        /// </summary>
//        /// <param name="target"></param>
//        public CHDataProcessorTarget(CHDataSource data_source)
//            : base(data_source.Graph)
//        {
//            _data_source = data_source;
//        }

//        /// <summary>
//        /// Calculates edge data.
//        /// </summary>
//        /// <param name="from"></param>
//        /// <param name="to"></param>
//        /// <param name="interpreter"></param>
//        /// <returns></returns>
//        protected override CHEdgeData CalculateEdgeData(GeoCoordinate from, GeoCoordinate to,
//            RoadTagsInterpreterBase interpreter)
//        {
//            CHEdgeData data = new CHEdgeData();
//            data.Weight = (float) interpreter.Time(Core.VehicleEnum.Car, from, to);
//            data.Forward = !interpreter.IsOneWayReverse();
//            data.Backward = !interpreter.IsOneWay();
//            if (interpreter.Tags != null && interpreter.Tags.Count > 0)
//            {
//                data.HasTags = true;
//                data.Tags = _data_source.Add(interpreter.Tags);
//            }
//            else
//            {
//                data.HasTags = false;
//            }
//            data.HasContractedVertex = false;

//            return data;
//        }
//    }
//}