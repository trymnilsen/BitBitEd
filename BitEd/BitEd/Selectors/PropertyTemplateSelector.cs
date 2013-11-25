using BitEd.Models.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BitEd.Selectors
{
    public class PropertyTemplateSelector : DataTemplateSelector
    {
        //As a static resource is assigned there is no need for a dependency property
        public Grid IntegerTemplate { get; set; }
        public TextBlock BooleanTemplate { get; set; }

        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
             return base.SelectTemplate(item, container);
        }
    }
}
