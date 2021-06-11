using System;
using System.Collections.Generic;
using System.Text;

namespace VT_Lab1.DAL.Entities
{
    public class Tile
    {
        public int TileId { get; set; } // id блюда
        public string TileName { get; set; } // название блюда
        public string Description { get; set; } // описание блюда
        public double Size { get; set; } // кол. калорий на порцию
        public string Image { get; set; } // имя файла изображения 

        // Навигационные свойства
        /// <summary>
        /// группа блюд (например, супы, напитки и т.д.)
        /// </summary>
        public int TileGroupId { get; set; }
        public TileGroup Group { get; set; }
    }
}
