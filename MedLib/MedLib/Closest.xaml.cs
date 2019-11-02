using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MedLib
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Closest : ContentPage
	{

        Options op;
        public Closest (Options _op)
		{
			InitializeComponent ();
            op = _op;
            L2.Text = op.uloc;
            L1.Text = op.closest;
            B1.Text = op.gloc;
        }

        async private void Click(object sender, EventArgs e)
        {

            try
            {

                Location loc1 = new Location(53.9097347, 27.5835274);
                Hospital h1 = new Hospital("National Hospital of Belarus'Interior Ministry", loc1);

                Location loc2 = new Location(53.9189888, 27.5989957);
                Hospital h2 = new Hospital("Hospital #1", loc2);

                Location loc3 = new Location(53.9016824, 27.6093842);
                Hospital h3 = new Hospital("Hospital #6", loc3);

                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    string st = $"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}";
                    L2.Text = op.uloc + " " + st;
                    Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");


                    Xamarin.Essentials.DistanceUnits unit = DistanceUnits.Kilometers;
                    double miles1 = Location.CalculateDistance(location, loc1, unit);
                    double miles2 = Location.CalculateDistance(location, loc2, unit);

                    double min = Math.Min(miles1, miles2);
                    
                        if (min == miles1)
                            L1.Text = op.closest + " " +h1.Name + " it's in " + miles1 + " km";
                        else
                            L1.Text = op.closest+ " " + h2.Name + " it's in " + miles2 + " km";
                    
                    
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                L1.Text = "Hey";
                // Handle not supported on device exception
            }
            catch (PermissionException pEx)
            {
                L1.Text = "loc Hey";
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
            }
        }
    }
}