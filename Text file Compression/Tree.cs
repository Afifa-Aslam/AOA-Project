using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;

namespace TextFileCompression
{
    class Tree
    {
        public List<Node> getListFromFile()
        {
            List<Node> n = new List<Node>();
            Console.Write("Enter the path of the file");
            string name = Console.ReadLine();
            try
            {
                FileStream file = new FileStream(name, FileMode.Open, FileAccess.Read);
                for(int i=0;i<=file.Length;i++)
                {
                    string input = Convert.ToChar(file.ReadByte()).ToString();
                    if (n.Exists(a => a.symbol == input))
                        n[n.FindIndex(b => b.symbol == input)].FrequencyIncrement();
                    else
                        n.Add(new Node(input));
    
                }
                n.Sort();
                return n;
            }
            catch(Exception)
            {
                return null;
            }
        }
        public void TreeList(List<Node> nodelist)
        {
            while(nodelist.Count>1)
            {
                Node n = nodelist[0];
                nodelist.RemoveAt(0);
                Node nn = nodelist[0];
                nodelist.RemoveAt(0);
                nodelist.Add(new Node(n, nn));
                nodelist.Sort();
            }
        }


    }
}
