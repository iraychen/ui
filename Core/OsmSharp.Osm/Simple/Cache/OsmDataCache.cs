﻿using System.Collections.Generic;

namespace OsmSharp.Osm.Simple.Cache
{
    /// <summary>
    /// An osm data cache for simple OSM objects.
    /// </summary>
    public abstract class OsmDataCache
    {
        /// <summary>
        /// Adds a new node.
        /// </summary>
        /// <param name="node"></param>
        public abstract void AddNode(SimpleNode node);

        /// <summary>
        /// Returns the node with the given id if present.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SimpleNode GetNode(long id)
        {
            SimpleNode node;
            if (this.TryGetNode(id, out node))
            {
                return node;
            }
            return null;
        }

        /// <summary>
        /// Tries to get the node with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="node"></param>
        /// <returns></returns>
        public abstract bool TryGetNode(long id, out SimpleNode node);

        /// <summary>
        /// Returns a enumerable of all nodes in this cache.
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerable<SimpleNode> GetNodes();

        /// <summary>
        /// Adds a new way.
        /// </summary>
        /// <param name="way"></param>
        public abstract void AddWay(SimpleWay way);

        /// <summary>
        /// Returns the way with the given id if present.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SimpleWay GetWay(long id)
        {
            SimpleWay way;
            if (this.TryGetWay(id, out way))
            {
                return way;
            }
            return null;
        }

        /// <summary>
        /// Tries to get the way with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="way"></param>
        /// <returns></returns>
        public abstract bool TryGetWay(long id, out SimpleWay way);

        /// <summary>
        /// Returns a enumerable of all ways in this cache.
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerable<SimpleWay> GetWays();

        /// <summary>
        /// Adds a new relation.
        /// </summary>
        /// <param name="relation"></param>
        public abstract void AddRelation(SimpleRelation relation);

        /// <summary>
        /// Returns the relation with the given id if present.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public SimpleRelation GetRelation(long id)
        {
            SimpleRelation relation;
            if (this.TryGetRelation(id, out relation))
            {
                return relation;
            }
            return null;
        }

        /// <summary>
        /// Tries to get the relation with the given id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="relation"></param>
        /// <returns></returns>
        public abstract bool TryGetRelation(long id, out SimpleRelation relation);

        /// <summary>
        /// Returns an enumerable of all relations in this cache.
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerable<SimpleRelation> GetRelations();
    }
}