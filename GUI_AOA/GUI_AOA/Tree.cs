using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GUI_AOA
{
    class Tree:Form3
    {
        public List<Node> getListFromFile()
        {
            List<Node> nodeList = new List<Node>();
            String filename = Item; 
            try
            {
                FileStream stream = new FileStream(filename, FileMode.Open, FileAccess.Read);
                for (int i = 0; i < stream.Length; i++)
                {
                    string read = Convert.ToChar(stream.ReadByte()).ToString();
                    if (nodeList.Exists(x => x.symbol == read))
                        nodeList[nodeList.FindIndex(y => y.symbol == read)].FrequencyIncrement();
                    else
                        nodeList.Add(new Node(read));
                }
                nodeList.Sort();
                return nodeList;


            }
            catch (Exception)
            {
                return null;
            }

        }
        public void Filewrite()
        {
            StreamWriter File = new StreamWriter(@"C:\Users\Pisces Khan\OneDrive\Documents\GitHub\AOA-Project\Text file Compression\Copy.txt");
            File.Close();
        }
        public void TreeList(List<Node> n)
        {
            while (n.Count > 1)
            {
                Node n1 = n[0];
                n.RemoveAt(0);
                Node n2 = n[0];
                n.RemoveAt(0);
                n.Add(new Node(n1, n2));
                n.Sort();
            }
        }
        public void setBitcode(string code, Node node)
        {
            if (node == null)
                return;
            if (node.Left == null && node.Right == null)
            {
                node.bitcode = code;
                return;
            }
            setBitcode(code + "0", node.Left);
            setBitcode(code + "1", node.Right);
        }
        public void PrintFrequency(List<Node> n)
        {
            foreach (var item in n)
                Console.WriteLine("Symbol : {0} - Frequency : {1}", item.symbol, item.frequency);
        }
        public void Printcode(Node node)
        {
            if (node == null)
                return;
            if (node.Left == null && node.Right == null)
            {
                Console.WriteLine("Symbol : {0} -  Code : {1}", node.symbol, node.bitcode);
                return;
            }
            Printcode(node.Left);
            Printcode(node.Right);
        }
    }
}
