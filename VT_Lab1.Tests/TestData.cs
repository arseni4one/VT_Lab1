using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VT_Lab1.DAL.Entities;

namespace VT_Lab1.Tests
{
    public class TestData
    {
        public static List<Tile> GetTilesList()
        {
            return new List<Tile>
                {
                    new Tile{TileId = 1, TileGroupId = 1 },
                    new Tile{ TileId = 2, TileGroupId = 2 },
                    new Tile{ TileId = 3, TileGroupId = 3 },
                    new Tile{ TileId = 4, TileGroupId = 4 },
                    new Tile{ TileId = 5, TileGroupId = 5 }
                };
        }

        public static IEnumerable<object[]> Params()
        {
            yield return new object[] { 1, 3, 1 }; //страница - 1, кол-во объектов на странице - 3, id первого объекта - 1
            yield return new object[] { 2, 2, 4 }; //страница - 2, кол-во объектов на странице - 2, id первого объекта - 4
        }
    }
}
