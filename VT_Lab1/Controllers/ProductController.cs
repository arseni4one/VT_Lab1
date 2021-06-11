using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VT_Lab1.DAL.Data;
using VT_Lab1.DAL.Entities;
using VT_Lab1.Models;



namespace VT_Lab1.Controllers
{
    public class ProductController : Controller
    {
        //public List<Tile> _tiles;
        //List<TileGroup> _tileGroups;
        ApplicationDbContext _context;

        int _pageSize;

        private ILogger _logger;


        public ProductController(ApplicationDbContext context, ILogger<ProductController> logger)
        {
            _pageSize = 3;
            _context = context;
            _logger = logger;


        }
        [Route("Catalog")]
        [Route("Catalog/Page_{pageNo}")]

        public IActionResult Index(int? group, int pageNo )
        {

            var groupName = group.HasValue ? _context.TileGroups.Find(group.Value)?.GroupName : "all groups";
            _logger.LogInformation($"info: group={group}, page={pageNo}");
            // Поместить список групп во ViewData
            ViewData["Groups"] = _context.TileGroups;
            // Получить id текущей группы и поместить в TempData
            ViewData["CurrentGroup"] = group ?? 0;
            var tilesFiltered = _context.Tilees.Where(t => !group.HasValue || t.TileGroupId == group.Value);
            //var items = _tiles.Skip((pageNo - 1) * _pageSize).Take(_pageSize).ToList();
            //return View(ListViewModel<Tile>.GetModel(tilesFiltered, pageNo,_pageSize));
            var model = ListViewModel<Tile>.GetModel(tilesFiltered, pageNo, _pageSize);
            if (Request.Headers["x-requested-with"]
            .ToString().ToLower().Equals("xmlhttprequest"))
                return PartialView("_listpartial", model);
            else
                return View(model);
        }
        public void InitData()
        { }
        /// <summary>
        /// Инициализация списков
        /// </summary>
        private void SetupData()
        {
            /* _tileGroups = new List<TileGroup>
                  {
                  new TileGroup {TileGroupId=1, GroupName="Половая плитка"},
                  new TileGroup {TileGroupId=2, GroupName="Стеновая плитка"},
                  new TileGroup {TileGroupId=3, GroupName="Тротуарная плитка"},
                  new TileGroup {TileGroupId=4, GroupName="Плитка мозаика"},
                  new TileGroup {TileGroupId=5, GroupName="Клинкерная плитка"},
                  new TileGroup {TileGroupId=6, GroupName="Керамогранитная плитка"}
                  };
             _tiles = new List<Tile>
                  {
                  new Tile {TileId = 1, TileName="Cersanit",
                 Description="18x59 Под дерево",
                 Size =0.72, TileGroupId=1, Image="CERSANIT PATINAWOOD БЕЖ РЕЛЬЕФ 18,5X59,8.jpg" },
                 new Tile { TileId = 2, TileName="Cersanit WOOD",
                 Description="18x59 Рисунок дерева(светлая)",
                 Size =0.8, TileGroupId=3, Image="CERSANIT SANDWOOD БЕЛЫЙ 18,5X59,8.jpg" },
                 new Tile { TileId = 3, TileName="MOZ-MIX",
                 Description="Черно-белая",Size =0.3, TileGroupId=4, Image="moz-mix.jpg" },
                 new Tile { TileId = 4, TileName="Skinali",
                 Description="Узор",
                 Size =0.9, TileGroupId=4, Image="skinali-5866.jpg" },
                 new Tile { TileId = 5, TileName="Carpet",
                 Description="White",
                 Size =0.25, TileGroupId=6, Image="Плитка Carpet Silver W M 25х75 NR Satin 1.jpg" }
                  };*/
        }
    }
}
