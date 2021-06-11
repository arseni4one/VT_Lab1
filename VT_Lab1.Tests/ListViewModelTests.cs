using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VT_Lab1.DAL.Entities;
using VT_Lab1.Models;
using Xunit;

namespace VT_Lab1.Tests
{
    public class ListViewModelTests
    {
        [Fact]
        public void ListViewModelCountsPages()
        {
            // Act - выполнение теста
            var model = ListViewModel<Tile>.GetModel(TestData.GetTilesList(), 1, 3);

            // Assert - проверка того, что результат соответствует ожиданиям
            Assert.Equal(2, model.TotalPages);
        }

        [Theory]
        [MemberData(memberName: nameof(TestData.Params), MemberType = typeof(TestData))]
        public void ListViewModelSelectsCorrectQty(int page, int qty, int id)
        {
            // Act - выполнение теста
            var model = ListViewModel<Tile>.GetModel(TestData.GetTilesList(), page, 3);

            // Assert - проверка того, что результат соответствует ожиданиям
            Assert.Equal(qty, model.Count);
        }

        [Theory]
        [MemberData(memberName: nameof(TestData.Params), MemberType = typeof(TestData))]
        public void ListViewModelHasCorrectData(int page, int qty, int id)
        {
            // Act - выполнение теста
            var model = ListViewModel<Tile>.GetModel(TestData.GetTilesList(), page, 3);

            // Assert - проверка того, что результат соответствует ожиданиям
            Assert.Equal(id, model[0].TileId);
        }
    }
}
