using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreeStructureIdeo.Models
{
    public class KnotElements
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int? ParentId { get; set; }
        public List<KnotElements> Children { get; set; }

        public KnotElements()
        {
            Children = new List<KnotElements>();
        }

        public KnotElements(Knots k)
        {
            this.Id = k.Id;
            this.Text = k.Text;
            this.ParentId = k.ParentId;
            this.Children = new List<KnotElements>();
        }

        public void AddChildren(KnotElements ke)
        {
            this.Children.Add(ke);
        }
    }
}
