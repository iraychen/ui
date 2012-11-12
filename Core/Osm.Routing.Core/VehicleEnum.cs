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

namespace Routing.Core
{
    /// <summary>
    /// Enumeration of supported vehicle types.
    /// </summary>
    public enum VehicleEnum
    {
        Car,
        Bus,
        Pedestrian,
        Bike
    }

    /// <summary>
    /// Extensions for VehicleEnum
    /// </summary>
    public static class VehicleEnumExtensions
    {
        /// <summary>
        /// Returns true if the given vehicle type is a motorized vehicle.
        /// </summary>
        /// <param name="vehicle"></param>
        /// <returns></returns>
        public static bool IsMotorVehicle(this VehicleEnum vehicle)
        {
            switch (vehicle)
            {
                case VehicleEnum.Bike:
                case VehicleEnum.Pedestrian:
                    return false;
            }
            return true;
        }
    }
}
