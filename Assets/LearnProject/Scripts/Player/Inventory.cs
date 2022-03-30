using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.LearnProject.Player
{
    public class Inventory
    {
        public List<GameObject> Items { get; private set; }

        public Inventory()
        {
            Items = new List<GameObject>();
        }

        internal void AddItem(GameObject gameObject)
        {
            if (gameObject.name == "FirstKey")
            {
                Items.Add(gameObject);
            }
        }

        internal bool Exists(string itemName)
        {
            return Items.Exists(x => x.name == itemName);
        }
    }
}
