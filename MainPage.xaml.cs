using System;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Maps
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            myMap.Loaded += MyMap_loadedAsync;

        }

        private async void MyMap_loadedAsync(object sender, RoutedEventArgs e)
        {
            var center = new Geopoint(new BasicGeoposition()
            {
                Latitude = 52.707,
                Longitude = -2.645
            });

            // retrieve map
            await myMap.TrySetSceneAsync(MapScene.CreateFromLocationAndRadius(center, 200));

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var center =
                            new Geopoint(new BasicGeoposition()
                            {
                                Latitude = 53.707013,
                                Longitude = -2.645195
                            });

            // retrieve map
            await myMap.TrySetSceneAsync(MapScene.CreateFromLocationAndRadius(center, 200));
        }

        private void Roads_Click(object sender, RoutedEventArgs e)
        {
            RadioButton radio = sender as RadioButton;
            switch (radio.Name)
            {
                case "Roads":
                    myMap.Style = MapStyle.Road;
                    break;

                case "Hybrid":
                    myMap.Style = MapStyle.AerialWithRoads;
                    break;

                case "Satellite":
                    myMap.Style = MapStyle.Aerial;
                    break;

				case "Dark":
                    myMap.StyleSheet = MapStyleSheet.RoadDark();
                    break;

                default:
                    break;
            }
        }
    }
}
