using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using VT_Lab1.Controllers;
using VT_Lab1.DAL.Entities;
using Xunit;


namespace VT_Lab1.Tests
{
    public class ProductControllerTests
    {
        [Theory]
        [MemberData(nameof(TestData.Params), MemberType = typeof(TestData))]
        public void ControllerGetsProperPage(int page, int qty, int id)
        {
            // Arrange 
            var controller = new ProductController();
            controller._tiles = TestData.GetTilesList();
            // Act
            var result = controller.Index(pageNo: page, group: null) as ViewResult;
            var model = result?.Model as List<Tile>;
            // Assert
            Assert.NotNull(model);
            Assert.Equal(qty, model.Count);
            Assert.Equal(id, model[0].TileId);
        }
        /*
        [Theory]
        [InlineData(1, 3, 1)] // 1-я страница, кол. объектов 3, id первого  объекта 1
        [InlineData(2, 2, 4)] // 2-я страница, кол. объектов 2, id первого  объекта 4
        public void ControllerGetsProperPage(int page, int qty, int id)
        {
            // Arrange 
            var controller = new ProductController();
            controller._tiles = new List<Tile>
                     {
                    new Tile{ TileId=1},
                    new Tile{ TileId=2},
                    new Tile{ TileId=3},
                    new Tile{ TileId=4},
                    new Tile{ TileId=5}
                    };
            // Act
            var result = controller.Index(page) as ViewResult;
            var model = result?.Model as List<Tile>;
            // Assert
            Assert.NotNull(model);
            Assert.Equal(qty, model.Count);
            Assert.Equal(id, model[0].TileId);
        }*/
    }
}
