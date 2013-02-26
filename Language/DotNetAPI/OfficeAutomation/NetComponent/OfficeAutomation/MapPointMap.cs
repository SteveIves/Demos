using System;
using System.Collections.Generic;
using System.Text;
using MapPoint;

namespace OfficeAutomation
{
    public class MapPointMap
    {
        MapPoint.Application app;
        MapPoint.Map map;

        private object oNotPassed = System.Reflection.Missing.Value;

        #region Main map methods

        public MapPointMap()
        {
            app = new Application();
            app.Visible = false;
            map = app.ActiveMap;
        }

        ~MapPointMap()
        {
            if (app != null)
                Close();
        }

        public void Close()
        {
            map = null;
            ((MapPoint._Application)app).Quit();
            app = null;
        }

        public void SaveAs(string fileName, GeoSaveFormat format)
        {
            map.SaveAs(fileName.Trim(),(MapPoint.GeoSaveFormat)format,false);
        }

        public void Save()
        {
            if (!map.Saved)
                map.Save();
        }

        #endregion

        public void GotoAddress(string address)
        {
            map.Location = (Location)map.FindResults(address)[1];
        }

        public void AddPushPin(string address, string name, string note, bool goThere, bool addWayPoint)
        {
            Location l = (Location)map.FindResults(address)[1];
            MapPoint.Pushpin pin = map.AddPushpin(l);
            pin.Name = name;
            pin.Note = note;
            pin.Symbol = 85;
            pin.BalloonState = GeoBalloonState.geoDisplayBalloon;

            if (goThere)
                map.Location = l;

            if (addWayPoint)
                map.ActiveRoute.Waypoints.Add(pin);
        }

        public void ZoomToRoute()
        {
            map.ActiveRoute.ZoomTo();
        }

        public void ClearRoute()
        {
            map.ActiveRoute.Clear();
        }

    }

}
