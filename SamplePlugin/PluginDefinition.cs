using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SamplePlugin
{
    public class PluginDefinition : IPlugin
    {
        public string MenuTitle
        {
            get { return "Human Resources"; }
        }
        
        public string ActionName
        {
            get { return "HumanResourcesAction"; }
        }
        
        public string ControllerName
        {
            get { return "HumanResourcesController"; }
        }

        
        public List<string> Menu
        {
            get
            {
                return new List<string>
                {
                    "Emploies",
                    "Recruitment"
                };
            }
        }
    }
}
