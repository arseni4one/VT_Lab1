using System;
using System.Collections.Generic;
using System.Text;

namespace VT_Lab1.DAL.Entities
{
    public class TileGroup
    {

        public int TileGroupId { get; set; }
        public string GroupName { get; set; }
        /// <summary>
        /// Навигационное свойство 1-ко-многим
        /// </summary>
        public List<Tile> Tiles { get; set; }
    }
}
