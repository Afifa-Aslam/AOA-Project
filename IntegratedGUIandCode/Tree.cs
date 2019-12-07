using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace IntegratedGUIandCode
{
    class Tree:Compression
    {
        public List<Node> getListFromFile()
        {
            
            List<Node> nodeList = new List<Node>();
            String filename = Items.Item ;
            //System.Windows.Forms.MessageBox.Show(filename);

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
        public void Filewrite(Node node)
        {
            StreamWriter streamWriter = new StreamWriter(@"C:\Users\Pisces Khan\OneDrive\Documents\GitHub\AOA-Project\Text file Compression\Copy.txt");
            writer(node, streamWriter);
            streamWriter.Close();
        }
        public void writer(Node node, StreamWriter path)
        {
            if (node == null)
                return;
            if (node.Left == null && node.Right == null)
            {

                path.WriteLine(/*"Symbol : {0} -  Code : {1}", node.symbol,*/ node.symbol);
                return;
            }
            writer(node.Left, path);
            writer(node.Right, path);
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

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Tree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.ClientSize = new System.Drawing.Size(1228, 685);
            this.Name = "Tree";
            this.Load += new System.EventHandler(this.Tree_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Tree_Load(object sender, EventArgs e)
        {

        }
    }
}

