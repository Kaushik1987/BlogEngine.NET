﻿using BlogEngine.Core.DataStore;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogEngine.Core.Helpers
{
    /// <summary>
    /// Widgets helper class
    /// </summary>
    public class WidgetHelper
    {
        /// <summary>
        /// Gets widget settings
        /// </summary>
        /// <param name="id">Widget ID</param>
        /// <returns>Settings object</returns>
        public static StringDictionary GetSettings(string id)
        {
            var cacheId = string.Format("be_widget_{0}", id);
            if (Blog.CurrentInstance.Cache[cacheId] == null)
            {
                var ws = new WidgetSettings(id);
                Blog.CurrentInstance.Cache[cacheId] = ws.GetSettings();
            }
            return (StringDictionary)Blog.CurrentInstance.Cache[cacheId];
        }

        /// <summary>
        /// Saves widget settings into datastore
        /// </summary>
        /// <param name="settings">Settings object (key/values)</param>
        /// <param name="widgetId">Widget Id</param>
        public static void SaveSettings(StringDictionary settings, string widgetId)
        {
            var cacheId = string.Format("be_widget_{0}", widgetId);

            var ws = new WidgetSettings(widgetId);
            ws.SaveSettings(settings);

            Blog.CurrentInstance.Cache[cacheId] = settings;
        }
    }
}
