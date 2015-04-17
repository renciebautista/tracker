using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tracker.Properties;
using WeifenLuo.WinFormsUI.Docking;

namespace tracker.file
{
    public partial class frmMap : DockContent
    {
        internal readonly GMapOverlay objects = new GMapOverlay("objects");
        public frmMap()
        {
            InitializeComponent();

            initMap();

            
            
        }

        public void initMap()
        {
            // config map         
            List<GMapProvider> List = GMapProviders.List;
            gMap.MapProvider = List[Properties.Settings.Default.MapProvider];
            gMap.Position = new PointLatLng(Convert.ToDouble(Properties.Settings.Default.Lat), Convert.ToDouble(Properties.Settings.Default.Lng));
            gMap.MinZoom = 0;
            gMap.MaxZoom = 24;
            gMap.Zoom = 13;
            gMap.DragButton = MouseButtons.Left;

            gMap.Overlays.Add(objects);

            // set cache mode only if no internet avaible
            if (!Stuff.PingNetwork("pingtest.com"))
            {
                gMap.Manager.Mode = AccessMode.CacheOnly;
                MessageBox.Show("No internet connection available, going to CacheOnly mode.", "Tracker", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            gMap.Zoom = trackBar.Value;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            objects.Markers.Clear();
            plotTrain();
        }
        private void plotTrain()
        {
            //this.Text = "Map View " + DateTime.Now.ToString();
            timer.Enabled = false;

            List<PointLatLng> positions = new List<PointLatLng>();

            var list = Properties.Settings.Default.Trains.Cast<string>().ToList();

            #region Read File Data

            if (list.Count > 0)
            {
               // DataTable dt = MysqlHelper.ExecuteDataTable("SELECT *" +
               //" FROM logs " +
               //" WHERE head = 1" +
               //" AND train_id IN(" + String.Join(",", list.ToArray()) +  ") " +
               //" GROUP BY train_id ORDER BY created_at DESC LIMIT 1");

                DataTable dt = MysqlHelper.ExecuteDataTable("SELECT * FROM (SELECT  * FROM logs " +
                    "WHERE head = 1 " +
                    "AND train_id IN(" + String.Join(",", list.ToArray()) + ") " +
                    "ORDER BY created_at DESC) as temp " +
                    "GROUP BY train_id");


                foreach (DataRow row in dt.Rows) // Loop over the rows.
                {
                    PointLatLng p = new PointLatLng
                    {
                        Lat = float.Parse(row["lat"].ToString()),
                        Lng = float.Parse(row["lng"].ToString())
                    };

                    Image image_marker = Resources.train_green;

                    Image markerImage = image_marker;


                    /* Bitmap bmp = new Bitmap(markerImage.Width, markerImage.Height);
                     using (Graphics g = Graphics.FromImage(bmp))
                     {
                         g.Clear(Color.SkyBlue);
                         g.InterpolationMode = InterpolationMode.NearestNeighbor;
                         g.PixelOffsetMode = PixelOffsetMode.None;
                         g.DrawImage(markerImage, Point.Empty);
                     }
                     */

                    GMapMarkerImage marker = new GMapMarkerImage(p, markerImage);
                    objects.Markers.Add(marker);

                    // marker.ToolTipMode = MarkerTooltipMode.Always; enable tooltip
                    marker.ToolTipText = row["train_code"].ToString() + " - " + row["train_desc"].ToString();

                }
            }
            gMap.Refresh();
            #endregion
            timer.Enabled = true;
        }

    }
}
