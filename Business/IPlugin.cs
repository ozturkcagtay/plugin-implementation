using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IPlugin
    {
        string MenuTitle { get;  }
        string ActionName { get;  }
        string ControllerName { get;  }
        List<string> Menu { get;  }
    }
}
