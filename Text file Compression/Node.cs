using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_file_Compression
{
    class Node
    {
        public string symbol;
        public int frequency;
        public Node Left, Right, Parent;
        public string bitcode;
        public bool isleaf;
        public Node(string input)
        {
            Left = null;
            Right = null;
            Parent = null;
            symbol = input;
            frequency = 1;
            bitcode = "";
            isleaf = true;
        }
        public Node(Node Zero, Node One)
        {
            Parent = null;
            bitcode = "";
            isleaf = false;
            if (Zero.frequency >= One.frequency)
            {
                Right = Zero;
                Left = One;
                Right.Parent = Left.Parent = this;
                frequency = Zero.frequency + One.frequency;
                symbol = Zero.symbol + One.symbol;
            }
            else if (Zero.frequency < One.frequency )
            {
                Right = One;
                Left = Zero;
                Right.Parent = Left.Parent = this;
                frequency = Zero.frequency + One.frequency;
                symbol = Zero.symbol + One.symbol;
            }
        }
        public int CompareTo(Node n)
        {
            return this.frequency.CompareTo(n.frequency);
        }
        public void FrequencyIncrement()
        {
            frequency++;
        }
    }
}
