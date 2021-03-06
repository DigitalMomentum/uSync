﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Jumoo.uSync.Core.Helpers
{
    public static class DeployIOHelper
    {
        public static void SaveNode(XElement node, string folder, string filename)
        {
            var mappedFolder = Umbraco.Core.IO.IOHelper.MapPath(folder);

            if (!Directory.Exists(mappedFolder))
                Directory.CreateDirectory(mappedFolder);

            var fullpath = Path.Combine(mappedFolder, filename);
            node.Save(fullpath);
        }

        public static void DeleteNode(Guid key, string folder)
        {
            var mappedFolder = Umbraco.Core.IO.IOHelper.MapPath(folder);
            var fullpath = Path.Combine(mappedFolder, string.Format("{0}.config", key.ToString()));

            XElement a = new XElement("uSyncArchive", new XAttribute("key", key.ToString()));
            a.Save(fullpath);
        }
    }
}
