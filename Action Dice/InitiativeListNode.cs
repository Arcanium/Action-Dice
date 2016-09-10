using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Action_Dice
{
    class InitiativeListNode
    {

        private int listLocation = 0;
        private string listName = "";
        private int listRoll = 0;
        private string listDown = "";

        public InitiativeListNode() { }

        public InitiativeListNode(int location, string name, int roll, string down)
        {
            Location = location;
            Name = name;
            Roll = roll;
            Down = down;
        }

        public InitiativeListNode(string node)
        {
            string[] contents = node.Split(' ');
            Location = Convert.ToInt32(contents[0]);
            Name = contents[1];
            Roll = Convert.ToInt32(contents[2]);
            if (contents.Length > 3)
                Down = contents[3];
            else
                Down = "";
        }

        public int Location
        {
            get
            {
                return listLocation;
            }

            set
            {
                listLocation = value;
            }
        }

        public string Name
        {
            get
            {
                return listName;
            }

            set
            {
                listName = value;
            }
        }

        public int Roll
        {
            get
            {
                return listRoll;
            }
            set
            {
                listRoll = value;
            }
        }

        public string Down
        {
            get
            {
                return listDown;
            }
            set
            {
                listDown = value;
            }
        }

        public string ListItem
        {
            get
            {
                return Convert.ToString(listLocation) + " " + listName + " " + Convert.ToString(listRoll) + " " + listDown;
            }
            set
            {
                string[] contents = value.Split(' ');
                listLocation = Convert.ToInt32(contents[0]);
                listName = contents[1];
                listRoll = Convert.ToInt32(contents[2]);
                if (contents.Length > 3)
                    listDown = contents[3];
            }
        }

    }
}
