using Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ICollection<IPlugin> plugins = PluginBusiness.Instance.ListPlugins();

            if(sender.ToString() == "Load Menu")
            {
        
                foreach(var plugin in plugins)
                {
                    ToolStripMenuItem fileItem = new ToolStripMenuItem(plugin.MenuTitle);

                    plugin.Menu.ForEach(n =>
                    {
                        ToolStripMenuItem firstSubitem = new ToolStripMenuItem(n);
                        fileItem.DropDownItems.Add(firstSubitem);

                    });

                    menuStrip1.Items.RemoveAt(0);
                    menuStrip1.Items.Insert(0, fileItem);

                }







            }

           


        }
    }
}
