using System.Collections.Generic;
using System.Linq;

namespace WebStore.ViewModels
{
    public class SectionViewModel
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public int Order { get; init; }
        public List<SectionViewModel> ChildSections { get; } = new();
        public SectionViewModel Parent { get; init; }
        public int ProductCount { get; set; }
        public int TotalProductCount => ProductCount + ChildSections.Sum(s => s.ProductCount);
    }
}
