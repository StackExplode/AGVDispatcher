using AGVDispatcher.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGVDispatcher.UI
{
    public interface IAGVDevConfigBlock
    {
        IAGVDevConfig GenerateConfig();
        public void Init(IAGVDevConfig conf);

    }
}
