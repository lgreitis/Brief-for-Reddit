using System;
using System.Resources;
using System.Net.Http;
using System.Threading.Tasks;
using Tizen.Wearable.CircularUI.Forms;
using Tizen.Security;
using FFImageLoading;
using FFImageLoading.Config;
using Xamarin.Forms;

// TODO: Define the default culture of your app.
// This improves lookup performance for the first resource to load.
// For more details, see https://docs.microsoft.com/dotnet/api/system.resources.neutralresourceslanguageattribute.
[assembly: NeutralResourcesLanguage("en-US")]

namespace Brief_for_Reddit
{
    class TizenApplication : global::Xamarin.Forms.Platform.Tizen.FormsApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            ImageService.Instance.Initialize(new Configuration()
            {
                // TODO: Figure out what does it want from me
                HttpClient = new HttpClient(Services.NetworkHandler.GetHandler())
            });
            LoadApplication(new App());
        }

        static void Main(string[] args)
        {
            using (var tizenApplication = new TizenApplication())
            {
                Forms.Init(tizenApplication);
                FFImageLoading.Forms.Platform.CachedImageRenderer.Init(tizenApplication);
                FormsCircularUI.Init();
                tizenApplication.Run(args);
            }
        }
    }
}
