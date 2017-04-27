using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWebApplication.Models
{
    public class MenuItem
    {
        public MenuItem(string title, string controllerName, string actionName)
        {
            this.Title = title;
            this.ControllerName = controllerName;
            this.ActionName = actionName;
        }

        public string Title { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
    }
}