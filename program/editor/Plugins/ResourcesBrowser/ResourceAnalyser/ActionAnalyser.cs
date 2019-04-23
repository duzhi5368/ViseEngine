﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourcesBrowser.ResourceAnalyser
{
    [D3DViewer.ResourceAnalyser(AnalyserType = "Action")]
    class ActionAnalyser : D3DViewer.IResourceAnalyser
    {
        public object[] GetResources(object[] info)
        {
            if (info == null)
                return null;

            if (info.Length == 0)
                return null;

            List<object> retList = new List<object>();
            retList.Add("Action");
            retList.AddRange(info);

            return retList.ToArray();
        }
    }
}
