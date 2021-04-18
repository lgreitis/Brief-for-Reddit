using Brief_for_Reddit.Models;
using Xamarin.Forms;

namespace Brief_for_Reddit.Services
{
    class PostTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ImageTemplate { get; set; }
        public DataTemplate UnsupportedTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            switch (((Post)item).PostHint)
            {
                case "image":
                    return ImageTemplate;
                default:
                    return UnsupportedTemplate;
            }
        }
    }
}
