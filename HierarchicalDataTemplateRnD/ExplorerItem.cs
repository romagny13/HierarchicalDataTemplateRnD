using System.Collections.Generic;

namespace HierarchicalDataTemplateRnD
{
    public class ExplorerItem
    {
        public string Header { get; set; }

        public string ImagePath { get; set; }

        public string Path { get; set; }

        public List<ExplorerItem> Items { get; set; }

        public ExplorerItem()
        {
            Items = new List<ExplorerItem>();
        }
    }
}

