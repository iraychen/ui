﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using Osm.Data.XML.Raw.Processor;
using Osm.Data.Core.Processor.Filter.Sort;
using Routing.Core;
using Routing.Core.Router;
using Routing.Core.Interpreter;
using Osm.Routing.Data;
using Routing.Core.Router.Memory;
using Osm.Routing.Data.Processing;
using Osm.Core;
using Routing.CH.PreProcessing;
using Routing.CH.PreProcessing.Ordering.LimitedLevelOrdering;
using Routing.CH.PreProcessing.Witnesses;
using Routing.CH.Routing;

namespace Osm.UnitTests.Routing.CH
{
    [TestClass]
    public class CHSparseRoutingTest : SimpleRoutingTests<RouterPoint, CHEdgeData>
    {
        /// <summary>
        /// Builds the data.
        /// </summary>
        /// <param name="interpreter"></param>
        /// <returns></returns>
        public override IRouterDataSource<CHEdgeData> BuildData(IRoutingInterpreter interpreter)
        {
            OsmTagsIndex tags_index = new OsmTagsIndex();

            // do the data processing.
            MemoryRouterDataSource<CHEdgeData> data =
                new MemoryRouterDataSource<CHEdgeData>(tags_index);
            CHEdgeDataGraphProcessingTarget target_data = new CHEdgeDataGraphProcessingTarget(
                data, interpreter, data.TagsIndex);
            XmlDataProcessorSource data_processor_source = new XmlDataProcessorSource(
                Assembly.GetExecutingAssembly().GetManifestResourceStream("Osm.UnitTests.test_network.osm"));
            DataProcessorFilterSort sorter = new DataProcessorFilterSort();
            sorter.RegisterSource(data_processor_source);
            target_data.RegisterSource(sorter);
            target_data.Pull();
            
            // do the pre-processing part.
            CHPreProcessor pre_processor = new CHPreProcessor(data,
                new SparseOrdering(data), new DykstraWitnessCalculator(data));
            pre_processor.Start();

            return data;
        }

        /// <summary>
        /// Returns a new router.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="interpreter"></param>
        /// <returns></returns>
        public override IRouter<RouterPoint> BuildRouter(IRouterDataSource<CHEdgeData> data, 
            IRoutingInterpreter interpreter)
        {
            return new Router<CHEdgeData>(data, interpreter, new CHRouter(
                data));
        }

        /// <summary>
        /// Tests a simple shortest route calculation.
        /// </summary>
        [TestMethod]
        public void TestCHSparseShortedDefault()
        {
            this.DoTestShortestDefault();
        }

        /// <summary>
        /// Tests if the raw router preserves tags.
        /// </summary>
        [TestMethod]
        public void TestCHSparseResolvedTags()
        {
            this.DoTestResolvedTags();
        }

        /// <summary>
        /// Tests if the raw router preserves tags on arcs/ways.
        /// </summary>
        [TestMethod]
        public void TestCHSparseArcTags()
        {
            this.DoTestArcTags();
        }

        /// <summary>
        /// Test is the CH router can calculate another route.
        /// </summary>
        [TestMethod]
        public void TestCHSparseShortest1()
        {
            this.DoTestShortest1();
        }

        /// <summary>
        /// Test is the CH router can calculate another route.
        /// </summary>
        [TestMethod]
        public void TestCHSparseShortest2()
        {
            this.DoTestShortest2();
        }

        /// <summary>
        /// Test is the CH router can calculate another route.
        /// </summary>
        [TestMethod]
        public void TestCHSparseShortest3()
        {
            this.DoTestShortest3();
        }

        /// <summary>
        /// Test is the CH router can calculate another route.
        /// </summary>
        [TestMethod]
        public void TestCHSparseShortest4()
        {
            this.DoTestShortest4();
        }

        /// <summary>
        /// Test is the CH router can calculate another route.
        /// </summary>
        [TestMethod]
        public void TestCHSparseShortest5()
        {
            this.DoTestShortest5();
        }

        /// <summary>
        /// Test is the raw router can calculate another route.
        /// </summary>
        [TestMethod]
        public void TestCHShortestResolved1()
        {
            this.DoTestShortestResolved1();
        }

        /// <summary>
        /// Test if the ch router many-to-many weights correspond to the point-to-point weights.
        /// </summary>
        [TestMethod]
        public void TestCHSparseManyToMany1()
        {
            this.DoTestManyToMany1();
        }

        /// <summary>
        /// Test if the ch router handles connectivity questions correctly.
        /// </summary>
        [TestMethod]
        public void TestCHSparseConnectivity1()
        {
            this.DoTestConnectivity1();
        }
    }
}