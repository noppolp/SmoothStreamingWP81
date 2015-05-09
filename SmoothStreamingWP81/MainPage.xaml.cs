using Microsoft.Media.AdaptiveStreaming;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace SmoothStreamingWP81
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        public Windows.Media.MediaExtensionManager MediaManager;
        public IAdaptiveSourceManager AdaptiveSrcManager { get; private set; }
        void RegisterPlugins()
        {
            if (MediaManager == null)
                MediaManager = new Windows.Media.MediaExtensionManager();
            if (AdaptiveSrcManager == null)
                AdaptiveSrcManager = AdaptiveSourceManager.GetDefault();
            PropertySet ssps = new PropertySet();
            ssps["{A5CE1DE8-1D00-427B-ACEF-FB9A3C93DE2D}"] = AdaptiveSrcManager;


            MediaManager.RegisterByteStreamHandler("Microsoft.Media.AdaptiveStreaming.SmoothByteStreamHandler", ".ism", "text/xml", ssps);
            MediaManager.RegisterByteStreamHandler("Microsoft.Media.AdaptiveStreaming.SmoothByteStreamHandler", ".ism", "application/vnd.ms-sstr+xml", ssps);
            MediaManager.RegisterByteStreamHandler("Microsoft.Media.AdaptiveStreaming.SmoothByteStreamHandler", ".isml", "text/xml", ssps);
            MediaManager.RegisterByteStreamHandler("Microsoft.Media.AdaptiveStreaming.SmoothByteStreamHandler", ".isml", "application/vnd.ms-sstr+xml", ssps);
            MediaManager.RegisterSchemeHandler("Microsoft.Media.AdaptiveStreaming.SmoothSchemeHandler", "ms-sstr:", ssps);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            RegisterPlugins();
            Player.Source = new Uri("http://mediadl.microsoft.com/mediadl/iisnet/smoothmedia/Experience/BigBuckBunny_720p.ism/Manifest");
        }
    }
}
