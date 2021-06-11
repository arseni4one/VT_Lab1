using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace VT_Lab1.Blazor.Data
{
    public class ListViewModel
    {
        [JsonPropertyName("tileId")]
        public int TileId { get; set; } // id плитки
        [JsonPropertyName("tileName")]
        public string TileName { get; set; } // название плитки
    }
    public class DetailsViewModel
    {
        [JsonPropertyName("tileName")]
        public string TileName { get; set; } // название плитки
        [JsonPropertyName("description")]
        public string Description { get; set; } // описание плитки
        [JsonPropertyName("size")]
        public double Size { get; set; } // размер плитки
        [JsonPropertyName("image")]
        public string Image { get; set; } // имя файла изображения 
    }
}
