using System;

namespace Action_Dice
{
    class InitiativeListNode
    {
        public int Location { get; set; } = 0;
        public string Name { get; set; } = "";
        public int Roll { get; set; } = 0;
        public string Down { get; set; } = "";

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

        public string ListItem
        {
            get
            {
                return Convert.ToString(Location) + " " + Name + " " + Convert.ToString(Roll) + " " + Down;
            }
            set
            {
                string[] contents = value.Split(' ');
                Location = Convert.ToInt32(contents[0]);
                Name = contents[1];
                Roll = Convert.ToInt32(contents[2]);
                if (contents.Length > 3)
                    Down = contents[3];
            }
        }
    }
}