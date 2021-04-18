using System;
using Xamarin.Forms;
using FFImageLoading.Forms;
using Tizen.Wearable.CircularUI.Forms;
using Xamarin.Forms.PinchZoomImage;

namespace Brief_for_Reddit.Cells
{
    class ImageCell : ViewCell
    {
        private readonly INavigation navigation;
        public ImageCell(INavigation navigation)
        {
            // Navigation solution
            this.navigation = navigation;

            // Making elements
            CachedImage image = new CachedImage();
            Grid grid = new Grid();
            StackLayout layout = new StackLayout();
            Label title = new Label();
            Label fullTitle = new Label();
            Button subreddit = new Button();

            // Bindings
            image.SetBinding(CachedImage.SourceProperty, "ContentUrl");
            title.SetBinding(Label.TextProperty, new Binding("ShortTitle"));
            fullTitle.SetBinding(Label.TextProperty, "Title");
            subreddit.SetBinding(Button.TextProperty, "Subreddit");

            // Styles
            image.VerticalOptions = LayoutOptions.StartAndExpand;
            layout.BackgroundColor = Color.FromHex("#191919");
            layout.HorizontalOptions = LayoutOptions.FillAndExpand;
            layout.Margin = new Thickness(0, 130, 0, 0);
            title.VerticalOptions = LayoutOptions.CenterAndExpand;
            title.HorizontalOptions = LayoutOptions.CenterAndExpand;
            title.HorizontalTextAlignment = TextAlignment.Center;
            subreddit.BackgroundColor = Color.FromHex("#ff4500");
            subreddit.VerticalOptions = LayoutOptions.StartAndExpand;
            subreddit.HorizontalOptions = LayoutOptions.CenterAndExpand;

            // Gesture recognizer
            var tgr = new TapGestureRecognizer();
            tgr.Tapped += (s, e) => onImageClicked(image.Source);
            image.GestureRecognizers.Add(tgr);

            // Creating view
            layout.Children.Add(title);
            layout.Children.Add(subreddit);
            grid.Children.Add(image);
            grid.Children.Add(layout);
            View = grid;
        }

        private async void onImageClicked(ImageSource source)
        {
            var modalPage = new ContentPage();
            ScrollView view = new ScrollView();
            StackLayout layout = new StackLayout();
            CachedImage image = new CachedImage();
            PinchZoom pinchImage = new PinchZoom();

            image.Source = source;
            image.Margin = new Thickness(0, 130, 0, 130);
            image.DownsampleToViewSize = false;
            image.VerticalOptions = LayoutOptions.Center;
            image.HorizontalOptions = LayoutOptions.Center;
            view.VerticalOptions = LayoutOptions.CenterAndExpand;
            layout.VerticalOptions = LayoutOptions.CenterAndExpand;

            pinchImage.Content = image;
            //pinchImage.IsClippedToBounds = true;
            layout.Children.Add(pinchImage);
            view.Content = layout;
            modalPage.Content = view;

            await navigation.PushModalAsync(modalPage);
        }
    }
}
