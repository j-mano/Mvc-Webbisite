using Joachim_Johnson_ConsidAplication.Models;
using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Joachim_Johnson_ConsidAplication.Servises
{
    public class GoogleAdressToGeoPos
    {
        // Putting in adress and city and get out the cordinates of that adress in the form of list<string>(latuitude,longtude); Returning list<string>(Faild to load cordinated from adress,Faild to load cordinated from adress) if fail to find adress
        public static ICordinatesModells getCordByPos(string adress, string city)
        {
            ICordinatesModells returCord = new CordinatesModells();

            string fulladress = adress + city;
            returCord.lat = "";
            returCord.lng = "";

            try
            {
                returCord = getcord(fulladress);

                returCord.lat = Regex.Replace(returCord.lat, "<.*?>", String.Empty);
                returCord.lng = Regex.Replace(returCord.lng, "<.*?>", String.Empty);
            }
            catch
            {
                throw;
            }

            return returCord;
        }

        private static ICordinatesModells getcord(String fulladress)
        {
            ICordinatesModells returCord = new CordinatesModells();

            string Apicall      = "https://maps.googleapis.com/maps/api/geocode/xml?key={1}&address={0}&sensor=false";
            string Googlekey    = "AIzaSyByBPNpTW84-yUD3VJyUN7DOURDaheR-rs";

            string requestUri   = string.Format(Apicall, Uri.EscapeDataString(fulladress), Googlekey);

            try
            {
                WebRequest request      = WebRequest.Create(requestUri);
                WebResponse response    = request.GetResponse();
                XDocument xdoc          = XDocument.Load(response.GetResponseStream());

                XElement result             = xdoc.Element("GeocodeResponse").Element("result");
                XElement locationElement    = result.Element("geometry").Element("location");

                XElement lat = locationElement.Element("lat");
                XElement lng = locationElement.Element("lng");

                returCord.lat = lat.ToString();
                returCord.lng = lng.ToString();

                if (returCord.lng == null || returCord.lat == null)
                {
                    throw new ArgumentException("Latitude / Longitude comming from google maps, Adress or city is Propably invalid adresses.", nameof(returCord.lng));
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                Console.WriteLine("Fail to load cordinated from adress");
            }

            return returCord;
        }
    }
}