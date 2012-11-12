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

namespace Tools.Core.Output
{
    public class ConsoleOutputStream : IOutputStream
    {
        #region IOutputTextStream Members

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        public void Write(string text)
        {
            Console.Write(text);
        }

        private string _previous_progress_string;

        //private string _previous_key;

        public void ReportProgress(double progress, string key, string message)
        {
            string current_progress_string = message;//string.Format("{0}:{1}", key, message);
            if (current_progress_string == _previous_progress_string)
            {
                Console.SetCursorPosition(0, Console.CursorTop);
            }
            else
            {
                Console.WriteLine();
            }
            
            //if (_previous_key != key)
            //{
            //    Console.WriteLine(key);
            //}
            //_previous_key = key;

            Console.Write(string.Format("{0} : {1}%",
                current_progress_string, System.Math.Round(progress * 100, 2).ToString().PadRight(6), key, message));
            _previous_progress_string = current_progress_string;
        }

        #endregion


    }
}
