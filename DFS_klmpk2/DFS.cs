using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;


namespace DFS_klmpk2
{
    public partial class DFS : Form
    {
        int[] arr;
        int i = 0;
        public DFS()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RectangleShape[] rf =
               {V1, V2, V3, V4, V5, V6, V7, V8,V9, V10, V11, V12,
 V13, V14, V15,V16, V17, V18, V19, V20, V21, V22, V23,
    V24, V25, V26, V27, V28, V29, V30, V31, V32, V33,
  V34, V35, V36, V37, V38, V39, V40, V41, V42, V43, V44, 
 V45, V46, V47, V48, V49, V50, V51, V52, V53, V54, V55, 
                             V56, V57, V58, V59, V60, V61, V62, V63, V64, V65, V66,
                             V67, V68, V69, V70, V71, V72, V73, V74, V75, V76, V77,
                             V78, V79, V80};
            for (int j = 0; j < rf.Length; j++)
            {
                rf[j].FillStyle = FillStyle.Solid;
                rf[j].FillColor = Color.White;

            }
            Label[] lb = { L1, L2, L3, L4, L5, L6, L7, L8,L9, L10, L11, L12,
                             L13, L14, L15,L16, L17, L18, L19, L20, L21, L22, L23,
                             L24, L25, L26, L27, L28, L29, L30, L31, L32, L33,
                             L34, L35, L36, L37, L38, L39, L40, L41, L42, L43, L44, 
                             L45, L46, L47, L48, L49, L50, L51, L52, L53, L54, L55, 
                             L56, L57, L58, L59, L60, L61, L62, L63, L64, L65, L66,
                             L67, L68, L69, L70, L71, L72, L73, L74, L75, L76, L77,
                             L78, L79, L80 };
            for (int i = 0; i < lb.Length; i++)
            {
                lb[i].Text = "";
                
            }
            btn_left.Enabled = false;
            
        }
        private void timer_Tick(object sender, EventArgs e)
        {

            RectangleShape[] rf =
               {V1, V2, V3, V4, V5, V6, V7, V8,V9, V10, V11, V12,
 V13, V14, V15,V16, V17, V18, V19, V20, V21, V22, V23,
    V24, V25, V26, V27, V28, V29, V30, V31, V32, V33,
  V34, V35, V36, V37, V38, V39, V40, V41, V42, V43, V44, 
 V45, V46, V47, V48, V49, V50, V51, V52, V53, V54, V55, 
                             V56, V57, V58, V59, V60, V61, V62, V63, V64, V65, V66,
                             V67, V68, V69, V70, V71, V72, V73, V74, V75, V76, V77,
                             V78, V79, V80};
            Label[] lb = { L1, L2, L3, L4, L5, L6, L7, L8,L9, L10, L11, L12,
                             L13, L14, L15,L16, L17, L18, L19, L20, L21, L22, L23,
                             L24, L25, L26, L27, L28, L29, L30, L31, L32, L33,
                             L34, L35, L36, L37, L38, L39, L40, L41, L42, L43, L44, 
                             L45, L46, L47, L48, L49, L50, L51, L52, L53, L54, L55, 
                             L56, L57, L58, L59, L60, L61, L62, L63, L64, L65, L66,
                             L67, L68, L69, L70, L71, L72, L73, L74, L75, L76, L77,
                             L78, L79, L80 };

            
                lb[i].Text = "" + arr[i];
                lb[i].BackColor = Color.Red;
                rf[i].FillStyle = FillStyle.Solid;
                rf[i].FillColor= Color.LightGreen;
                
                if (i > 1)
                {
                    lb[i - 2].BackColor = Color.LightGreen;
                    lb[i -2 ].ForeColor = Color.Black;

                }
            
            i++;
            if (i == 80 )
            {
                lb[78].BackColor = Color.LightGreen;
                lb[78].ForeColor = Color.Black;
                lb[79].BackColor = Color.LightGreen;
                lb[79].ForeColor = Color.Black;
                btn_right.Enabled = false;
                btn_left.Enabled = true;
                btn_autostart.Enabled = false;
                timerauto.Enabled = false;

              
            }
           
           
              

        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            dfs();
           
            timerauto.Enabled=true;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            about dfs = new about();
                dfs.Show();
        }
        void dfs()
        {
            
            var g = new Graph();

            for (int i = 80; i >= 1; i--)
            {
                for (int j = 80; j >= 1; j--)
                {
                    g.AddEdge(i, j);
                }
            }
            arr = g.DFSWalkWithStartNode(1);
        }

        // ALGORITMA DEPTH FIRST SEARCH
        public class Graph
        {
            public int[] arr = new int[80];
            public Graph()
            {
                Adj = new Dictionary<int, HashSet<int>>();
            }

            public Dictionary<int, HashSet<int>> Adj { get; private set; }

            public void AddEdge(int source, int target)
            {
                if (Adj.ContainsKey(source))
                {
                    try
                    {
                        Adj[source].Add(target);
                    }
                    catch
                    {
                        MessageBox.Show("This edge already exists: " + source + " to " + target);
                    }
                }
                else
                {
                    var hs = new HashSet<int>();
                    hs.Add(target);
                    Adj.Add(source, hs);
                }
            }


            public int[] DFSWalkWithStartNode(int vertex)
            {
                int i = 0;
                var visited = new HashSet<int>();
                // Mark this node as visited
                visited.Add(vertex);
                // Stack for DFS
                var s = new Stack<int>();
                // Add this node to the stack
                s.Push(vertex);

                while (s.Count > 0)
                {
                    var current = s.Pop();
                    arr[i]=current;
                    // ADD TO VISITED HERE
                    if (!visited.Contains(current))
                    {
                        visited.Add(current);
                    }
                    // Only if the node has a any adj notes
                    if (Adj.ContainsKey(current))
                    {
                        // Iterate through UNVISITED nodes
                        foreach (int neighbour in Adj[current].Where(a => !visited.Contains(a)))
                        {
                            visited.Add(neighbour);
                            s.Push(neighbour);
                        }
                    }
                    i++;
                }
                return arr;
            }
        }


        public Color FillColor { get; set; }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            i = 0;
            Label[] lb = { L1, L2, L3, L4, L5, L6, L7, L8,L9, L10, L11, L12,
                             L13, L14, L15,L16, L17, L18, L19, L20, L21, L22, L23,
                             L24, L25, L26, L27, L28, L29, L30, L31, L32, L33,
                             L34, L35, L36, L37, L38, L39, L40, L41, L42, L43, L44, 
                             L45, L46, L47, L48, L49, L50, L51, L52, L53, L54, L55, 
                             L56, L57, L58, L59, L60, L61, L62, L63, L64, L65, L66,
                             L67, L68, L69, L70, L71, L72, L73, L74, L75, L76, L77,
                             L78, L79, L80 };
            for (int j = 0; j < lb.Length; j++)
            {
                lb[j].Text = "";

            }
            RectangleShape[] rf =
               {V1, V2, V3, V4, V5, V6, V7, V8,V9, V10, V11, V12,
 V13, V14, V15,V16, V17, V18, V19, V20, V21, V22, V23,
    V24, V25, V26, V27, V28, V29, V30, V31, V32, V33,
  V34, V35, V36, V37, V38, V39, V40, V41, V42, V43, V44, 
 V45, V46, V47, V48, V49, V50, V51, V52, V53, V54, V55, 
                             V56, V57, V58, V59, V60, V61, V62, V63, V64, V65, V66,
                             V67, V68, V69, V70, V71, V72, V73, V74, V75, V76, V77,
                             V78, V79, V80};
            for (int j = 0; j < rf.Length; j++)
            {
                rf[j].FillColor = Color.White;

            }




            timerauto.Enabled = false;
            btn_left.Enabled = false;
            btn_right.Enabled = true;
            btn_autostart.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            btn_left.Enabled = true;
            dfs();
            
            Label[] lb = { L1, L2, L3, L4, L5, L6, L7, L8,L9, L10, L11, L12,
                             L13, L14, L15,L16, L17, L18, L19, L20, L21, L22, L23,
                             L24, L25, L26, L27, L28, L29, L30, L31, L32, L33,
                             L34, L35, L36, L37, L38, L39, L40, L41, L42, L43, L44, 
                             L45, L46, L47, L48, L49, L50, L51, L52, L53, L54, L55, 
                             L56, L57, L58, L59, L60, L61, L62, L63, L64, L65, L66,
                             L67, L68, L69, L70, L71, L72, L73, L74, L75, L76, L77,
                             L78, L79, L80 };
             RectangleShape[] rf =
               {V1, V2, V3, V4, V5, V6, V7, V8,V9, V10, V11, V12,
 V13, V14, V15,V16, V17, V18, V19, V20, V21, V22, V23,
    V24, V25, V26, V27, V28, V29, V30, V31, V32, V33,
  V34, V35, V36, V37, V38, V39, V40, V41, V42, V43, V44, 
 V45, V46, V47, V48, V49, V50, V51, V52, V53, V54, V55, 
                             V56, V57, V58, V59, V60, V61, V62, V63, V64, V65, V66,
                             V67, V68, V69, V70, V71, V72, V73, V74, V75, V76, V77,
                             V78, V79, V80};
             
                 lb[i].Text = "" + arr[i];
                 lb[i].BackColor = Color.Red;
                 rf[i].FillStyle = FillStyle.Solid;
                 rf[i].FillColor = Color.LightGreen;

                 if (i > 1)
                 {
                     lb[i - 2].BackColor = Color.LightGreen;
                     lb[i - 2].ForeColor = Color.Black;

                 }
             
             i++;
            
             if (i == 80)
             {
                 lb[78].BackColor = Color.LightGreen;
                 lb[78].ForeColor = Color.Black;
                 lb[79].BackColor = Color.LightGreen;
                 lb[79].ForeColor = Color.Black;
                 btn_right.Enabled = false;

             }
           timerauto.Enabled = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            btn_right.Enabled = true;
            dfs();
           int j = 1;
           
            Label[] lb = { L1, L2, L3, L4, L5, L6, L7, L8,L9, L10, L11, L12,
                             L13, L14, L15,L16, L17, L18, L19, L20, L21, L22, L23,
                             L24, L25, L26, L27, L28, L29, L30, L31, L32, L33,
                             L34, L35, L36, L37, L38, L39, L40, L41, L42, L43, L44, 
                             L45, L46, L47, L48, L49, L50, L51, L52, L53, L54, L55, 
                             L56, L57, L58, L59, L60, L61, L62, L63, L64, L65, L66,
                             L67, L68, L69, L70, L71, L72, L73, L74, L75, L76, L77,
                             L78, L79, L80 };
            RectangleShape[] rf =
               {V1, V2, V3, V4, V5, V6, V7, V8,V9, V10, V11, V12,
 V13, V14, V15,V16, V17, V18, V19, V20, V21, V22, V23,
    V24, V25, V26, V27, V28, V29, V30, V31, V32, V33,
  V34, V35, V36, V37, V38, V39, V40, V41, V42, V43, V44, 
 V45, V46, V47, V48, V49, V50, V51, V52, V53, V54, V55, 
                             V56, V57, V58, V59, V60, V61, V62, V63, V64, V65, V66,
                             V67, V68, V69, V70, V71, V72, V73, V74, V75, V76, V77,
                             V78, V79, V80};

            lb[i-j].Text = "";

           
            rf[i-j].FillColor = Color.White;

            j++;
            i-=1;

           
            if (i == 0)
            {
                btn_left.Enabled = false;
                
            }
            btn_autostart.Enabled = true;

            timerauto.Enabled = false;
        }

       

       

       
    }
}
