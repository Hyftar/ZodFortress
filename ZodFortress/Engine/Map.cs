using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using ZodFortress.Engine.Units;

namespace ZodFortress.Engine
{
    public class Map
    {
        private readonly Board[] layers;

        /// <summary>
        /// Enumerable of the map layers
        /// </summary>
        public IEnumerable<Board> Layers { get { return this.layers; } }

        /// <summary>
        /// Number of layers the map contains.
        /// </summary>
        public int Depth { get; private set; }

        /// <summary>
        /// Gets or sets a specific board in the map.
        /// </summary>
        /// <param name="x">X axis of the map</param>
        /// <param name="y">Y axis of the map</param>
        /// <param name="z">Z axis of the map</param>
        /// <returns>Block at the specified coordinates</returns>
        public Units.BoardBlock this[int x, int y, int z]
        {
            get { return this.layers[z][x, y]; }
            set { this.layers[z][x, y] = value; }
        }

        /// <summary>
        /// Gets a specific board of the map.
        /// </summary>
        /// <param name="z">Z axis of the map</param>
        /// <returns>Layer at the Z axis specified</returns>
        public Board this[int z]
        {
            get { return this.layers[z]; }
        }

        /// <summary>
        /// Instantiates a map container.
        /// </summary>
        /// <param name="width">Width of the map</param>
        /// <param name="height">Height of the map</param>
        /// <param name="depth">Depth of the map (number of layers)</param>
        /// <param name="defaultBlock">The block the map is filled with by default</param>
        public Map(int width, int height, int depth, BoardBlock defaultBlock)
        {
            if (depth < 0)
                throw new ArgumentOutOfRangeException("depth");

            if (depth == 0)
                throw new ArgumentException("depth");

            this.Depth = depth;
            this.layers = Enumerable.Range(0, depth).Select(x => new Board(width, height, defaultBlock)).ToArray();
        }

        /// <summary>
        /// Instantiates a map container.
        /// </summary>
        /// <param name="size">Size of each board</param>
        /// <param name="depth">Depth of the map (number of layers)</param>
        /// <param name="defaultBlock">The block the map is filled with by default</param>
        public Map(Size size, int depth, BoardBlock defaultBlock) : this(size.Width, size.Height, depth, defaultBlock) { }
    }
}
