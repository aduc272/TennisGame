using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tennis
{
    public class Player
    {
        public string Name { get; set; }
        public int Point { get; set; }

        public Player(string name)
        {
            Name = name;
            Point = 0;
        }

        public void WinsPoint()
        {
            Point++;
        }

        public bool EqualsPoint(Player player)
        {
            return player != null && Point == player.Point;
        }

        public bool IsLeadingPoint(Player player)
        {
            return player != null && Point > player.Point;
        }        
    }        
}
