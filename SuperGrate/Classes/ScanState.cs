using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperGrate.Classes
{
    class ScanState
    {
        // /ue:*\* /ui:belowaverage\dylan #Generate this on the fly
        // /progress:SuperGrate.progress
        // /l:SuperGrate.log
        public static Task<bool> Do(string Target)
        {
            return Task.Run(() => {
                
                return false;
            });
        }
    }
}
