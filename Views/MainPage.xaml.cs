using System;
using Brief_for_Reddit.Services;
using Brief_for_Reddit.Cells;
using Xamarin.Forms;
using Xamarin.Forms.Extended;

namespace Brief_for_Reddit.Views
{
    public partial class MainPage : ContentPage
    {
        public DataTemplate imageTemplate { get; set; }
        public DataTemplate linkTemplate { get; set; }
        public DataTemplate unsupportedTemplate { get; set; }

        public InfiniteScrollCollection<Models.Post> Items { get; }
        private string After { get; set; }

        public MainPage()
        {
            InitializeComponent();
            SetupDataTemplates();

            listView.ItemTemplate = new PostTemplateSelector
            {
                ImageTemplate = imageTemplate,
                UnsupportedTemplate = unsupportedTemplate
            };

            Items = new InfiniteScrollCollection<Models.Post>
            {
                OnLoadMore = async () =>
                {
                    var result = await PostDataService.GetPosts(25, After);
                    var items = result.Item1;
                    After = result.Item2;
                    return items;
                }
            };

            Populate();
        }

        private async void Populate()
        {
            var result = await PostDataService.GetPosts(25, null);
            var items = result.Item1;
            After = result.Item2;

            Items.AddRange(items);
            listView.ItemsSource = Items;
            //listView.ItemsSource = await PostDataService.GetPosts(25);
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // TODO: Insert code to handle a list item selected event.
            // Logger.Info($"Selected Color : {e.SelectedItem}");
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            // TODO: Insert code to handle a list item tapped event.
            //Logger.Info($"Tapped Color : {e.Item}");
        }

        private void SetupDataTemplates()
        {
            // Solution: https://forums.xamarin.com/discussion/22634/how-can-i-access-navigation-from-within-a-viewcell
            imageTemplate = new DataTemplate(() =>
            {
                var nativeCell = new Cells.ImageCell(this.Navigation);

                return nativeCell;
            });

            unsupportedTemplate = new DataTemplate(() =>
            {
                return new UnsupportedCell();
            });
        }
    }
}
