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

namespace Routing.Core.Graph
{
    /// <summary>
    /// Abstracts a graph implementation.
    /// </summary>
    public interface IDynamicGraph<EdgeData> : IDynamicGraphReadOnly<EdgeData>
        where EdgeData : IDynamicGraphEdgeData
    {
        /// <summary>
        /// Adds a vertex.
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        uint AddVertex(float latitude, float longitude);

        /// <summary>
        /// Adds an arc with associated data.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="data"></param>
        void AddArc(uint from, uint to, EdgeData data);

        /// <summary>
        /// Delete all arcs arc between two vertices.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        void DeleteArc(uint from, uint to);
    }
}
