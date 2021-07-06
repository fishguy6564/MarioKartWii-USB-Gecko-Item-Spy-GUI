using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Item_Spy
{
    class Player
    {
        private String name;
        private int item;
        private int character;
        private int itemState;
        private bool isMainPlayer;

        public Player(String name, int character, bool isMainPlayer)
        {
            this.name = name;
            this.character = character;
            this.isMainPlayer = isMainPlayer;
        }

        public String getName()
        {
            return this.name;
        }

        public int getItem()
        {
            return this.item;
        }

        public int getCharacter()
        {
            return this.character;
        }

        public int getItemState()
        {
            return this.itemState;
        }

        public bool isMain()
        {
            return this.isMainPlayer;
        }

        public void setItemState(int itemState)
        {
            this.itemState = itemState;
        }

        public void setItem(int item)
        {
            this.item = item;
        }
    }
    class Room
    {
        private Player[] orderedPlayers;
        private Player[] displayPlayers;
        private int maxPlayers;

        public Room()
        {
            this.orderedPlayers = new Player[12];
            this.displayPlayers = new Player[12];
            maxPlayers = 0;
        }

        public Player get(int index)
        {
            return this.displayPlayers[index];
        }

        public void clear()
        {

            Array.Clear(orderedPlayers, 0, orderedPlayers.Length);
            Array.Clear(displayPlayers, 0, displayPlayers.Length);
            this.maxPlayers = 0;
        }

        public void setMaxPlayers(int playerAmount)
        {
            this.maxPlayers = playerAmount;
        }

        public void add(Player p, int index)
        {
            this.orderedPlayers[index] = p;
        }

        public int getMaxPlayers()
        {
            return this.maxPlayers;
        }

        public void update(byte[] position, byte[][] item)
        {
            Player[] temp = new Player[this.maxPlayers];
            for(int i = 0; i < this.maxPlayers; i++)
            {
                orderedPlayers[i].setItem(item[i][0]);
                orderedPlayers[i].setItemState(item[i][1]);
                displayPlayers[position[i] - 1] = orderedPlayers[i];
            }

            //for(int i = 0; i < this.maxPlayers; i++) displayPlayers[i] = temp[i];

        }
    }
}
