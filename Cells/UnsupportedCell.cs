using System;
using Xamarin.Forms;

namespace Brief_for_Reddit.Cells
{
    class UnsupportedCell : ViewCell
    {
        public UnsupportedCell()
        {
            // Making elements
            Grid grid = new Grid();
            StackLayout layout = new StackLayout();
            Label title = new Label();
            Label info = new Label();
            Button subreddit = new Button();

            // Bindings
            title.SetBinding(Label.TextProperty, new Binding("PostHint"));
            info.Text = "Unsupported post type please report this to the developer";
            subreddit.SetBinding(Button.TextProperty, "Subreddit");

            // Styles
            layout.BackgroundColor = Color.FromHex("#191919");
            layout.HorizontalOptions = LayoutOptions.FillAndExpand;
            title.VerticalOptions = LayoutOptions.CenterAndExpand;
            title.HorizontalOptions = LayoutOptions.CenterAndExpand;
            title.HorizontalTextAlignment = TextAlignment.Center;
            info.VerticalOptions = LayoutOptions.CenterAndExpand;
            info.HorizontalOptions = LayoutOptions.CenterAndExpand;
            info.HorizontalTextAlignment = TextAlignment.Center;
            subreddit.BackgroundColor = Color.FromHex("#ff4500");
            subreddit.VerticalOptions = LayoutOptions.StartAndExpand;
            subreddit.HorizontalOptions = LayoutOptions.CenterAndExpand;


            // Creating view
            layout.Children.Add(title);
            layout.Children.Add(info);
            layout.Children.Add(subreddit);
            grid.Children.Add(layout);
            View = grid;
        }
    }
}
