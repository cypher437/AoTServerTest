//using System.ComponentModel.DataAnnotations;
using System;
using System.IO;
using System.Text;
using System.Net;

namespace AoT.Models
{
    public class InventoryManager
    {
        protected List<Inventory> Inventories {get; set;}        // Player could have multiple inventories across multiple products

        public InventoryManager(uint accountId){
            Inventories = new List<Inventory>();
            CreateInventory(TEASER, accountId);
        }
        public void CreateInventory(GameType game, uint accountId)
        {
            // check it doesn't exist.
            let inventory = Inventories.Select(x => x).Where(x=> x.Game == game).SingleOrDefault();
            if(inventory == null)
                Inventories.Append(new Inventory(game));
            // could return error if already added so we don't erase inventory

            // Assign to user, check they haven't gone one already
            inventory.User = accountId;
            // update DB or add it to a batch update.
            StoreStateToDB();
        }
        public void AddItem(GameType game, uint itemId)
        {
            let list = Inventories.Select(x => x).Where(x => x.Game == game);
            StoreStateToDB();
        }
        private void StoreStateToDB(){
            // Here I'd call an SQL command to update state on the database
        }
        public void RemoteItem(GameType game, uint itemId)
        {
            StoreStateToDB();
        }

        public Inventory getInventory(GameType game){
            return new Inventory(game);
        }

    }

    public class Inventory
    {
        public uint ID {get; set;}      // Inventory ID
        public GameType Game { get; set; } // maybe even a gameID would be better.
        public uint User { get; set; }  // account that owns this inventory
        public IReadOnlyList<Item> Items { get; } // Only read this from DB
        public Inventory(GameType game)
        {
            Game = game;
            Items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            if (Inventory.Items.Any(x => x.ID == item.ID)){
                 //If Item exists increase count?
                item.Count ++;
            }else{
                Items.Append(item);
            }
            //NOTES We need to update server DB so when player logs in again his item is visible.
        }
        public void RemoteItem(Item item, uint count = 1)
        {

            let itemToRemove = Inventory.Items.Single(r => r.ID == item.ID);

            if (itemToRemove == null) //No item in inventory
                return


            itemToRemove.Count -= count;

            if(itemToRemove.Count <= 0)
                resultList.Remove(itemToRemove);

            //NOTES We need to update server DB so inventory state is recorded
        }
    }

    public class Item {
        public uint ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // are these items unique or can you stack them ?
        public uint Count {get; set;}
    }

    // NOTES my mind was thinking about future scaling and having separate items/inventories per game
    public enum GameType
    {
        TEASER,        // teaser game
        ARMY_OF_TAC,   // game 1
        FUTURE_GAME,   // promo game
        META_VERSE,     // some meta verse
    }
}

