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
    class PropertyTemplateSelector : DataTemplateSelector
    {
        //As a static resource is assigned there is no need for a dependency property
        public DataTemplate IntegerTemplate { get; set; }
        public DataTemplate BooleanTemplate { get; set; }

        public override System.Windows.DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            ActionProperty propertyObject = item as ActionProperty;
            switch (propertyObject.PropertyType)
            {
                case PropertyType.Int:
                    return IntegerTemplate;

                case PropertyType.Boolean:
                    return BooleanTemplate;

                default:
                    return base.SelectTemplate(item, container);
            }
        }
    }
}
