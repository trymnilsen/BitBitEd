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
    public class TypeTemplateSelector:DataTemplateSelector
    {
        public EntityTemplateCollection Templates { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            foreach(EntityTemplate dataTemplate in Templates)
            {
                if (dataTemplate.Value.IsInstanceOfType(item))
                    return dataTemplate.Template;
            }
            return base.SelectTemplate(item, container);
        }
    }
    public class EntityTemplateCollection : List<EntityTemplate> { }
    public class EntityTemplate
    {
        public DataTemplate Template { get; set; }
        public Type Value { get; set; }
    }
}
