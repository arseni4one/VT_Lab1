using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VT_Lab1.DAL.Entities;

namespace VT_Lab1.Models
{
    public class Cart
    {
        public Dictionary<int, CartItem> Items { get; set; }

        public Cart()
        {
            Items = new Dictionary<int, CartItem>();
        }

        ///<summary>
        ///Количество объектов в корзине
        /// </summary>
        public int Count
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity);
            }
        }
       /* public int Size
        {
            get
            {
                return (int)Items.Sum(item => item.Value.Quantity *
               item.Value.tilee.Size);
            }
        }*/

        ///<summary>
        ///Добавление в корзину
        /// </summary>
        /// /// <param name="tile">добавляемый объект</param>

        public virtual void AddToCart(Tile _tile)
        {
            //если такой объект уже есть в корзине, то увеличить его количество
            if (Items.ContainsKey(_tile.TileId)) Items[_tile.TileId].Quantity++;

            //иначе, добавить объект в корзину
            else Items.Add(_tile.TileId, new CartItem { tilee = _tile, Quantity = 1 });
        }

        ///<summary>
        ///Удаление объекта из корзины
        /// </summary>
        /// <param name="id">id удаляемого объекта</param>
        public virtual void RemoveFromCart(int id)
        {
            Items.Remove(id);
        }

        ///<summary>
        ///Очистка корзины
        /// </summary>
        public virtual void ClearAll()
        {
            Items.Clear();
        }
    }

    ///<summary>
    ///Класс описывающий одну позицию в корзине
    /// </summary>
    public class CartItem
    {
        public Tile tilee { get; set; }
        public int Quantity { get; set; }
    }
}
