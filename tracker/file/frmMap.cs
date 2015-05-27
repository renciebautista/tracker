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
        internal readonly GMapOverlay radio_overlay = new GMapOverlay("radio_overlay");
        public frmMap()
        {
            InitializeComponent();

            initMap();
        }

        public void initMap()
        {
            // config map         
            List<GMapProvider> List = GMapProviders.List;
            int index = 0;
            if (Properties.Settings.Default.MapProvider > 0)
            {
                index = Properties.Settings.Default.MapProvider;
            }
            gMap.MapProvider = List[index];
            gMap.Position = new PointLatLng(Convert.ToDouble(Properties.Settings.Default.Lat), Convert.ToDouble(Properties.Settings.Default.Lng));
            gMap.MinZoom = 0;
            gMap.MaxZoom = 24;
            gMap.Zoom = 13;
            gMap.DragButton = MouseButtons.Left;

            gMap.Overlays.Add(objects);
            gMap.Overlays.Add(radio_overlay);
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
            timer.Enabled = false;
            if (MysqlHelper.TestConnection())
            {
                objects.Markers.Clear();
                radio_overlay.Markers.Clear();
                plotTrain();
            }
            else
            {
                Application.Exit();
            }

            timer.Enabled = true;
           
        }
        private void plotTrain()
        {
            //this.Text = "Map View " + DateTime.Now.ToString();
            timer.Enabled = false;

            List<PointLatLng> positions = new List<PointLatLng>();
            var list = Properties.Settings.Default.Trains.Cast<string>().ToList();
            var radios = Properties.Settings.Default.Radios.Cast<string>().ToList();

            #region Read File Data
            if (list.Count > 0)
            {
               // DataTable dt = MysqlHelper.ExecuteDataTable("SELECT *" +
               //" FROM logs " +
               //" WHERE head = 1" +
               //" AND train_id IN(" + String.Join(",", list.ToArray()) +  ") " +
               //" GROUP BY train_id ORDER BY created_at DESC LIMIT 1");

                DataTable dt = MysqlHelper.ExecuteDataTable("SELECT * FROM (SELECT logs.train_code,logs.train_desc,train_id, lat,lng, image_index,created_at FROM logs " +
                    "JOIN trains ON logs.train_id = trains.id " +
                    "WHERE logs.head = 1 " +
                    "AND logs.train_id IN(" + String.Join(",", list.ToArray()) + ") " +
                    "ORDER BY logs.created_at DESC) as temp " +
                    "GROUP BY train_id");


                foreach (DataRow row in dt.Rows) // Loop over the rows.
                {
                    PointLatLng p = new PointLatLng
                    {
                        Lat = float.Parse(row["lat"].ToString()),
                        Lng = float.Parse(row["lng"].ToString())
                    };

                    Image[] images = 
                    {
                        Properties.Resources.train_green,
                        Properties.Resources.train_red,
                        Properties.Resources.train_yellow,
                        Properties.Resources.train_blue,
                        Properties.Resources.train_brown,
                    };
                    Image image_marker;
                    if (DateTime.Now.Subtract(Convert.ToDateTime(row["created_at"])).TotalSeconds > (int)Properties.Settings.Default.Limit) 
                    {
                        image_marker = Properties.Resources.train_gray;
                    }
                    else
                    {
                        image_marker = images[(int)row["image_index"]];
                    }
                    

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


            if (radios.Count > 0)
            {
                DataTable dt_radios = MysqlHelper.ExecuteDataTable("SELECT * FROM (SELECT radio_logs.radio_id, radio_logs.lat, radio_logs.lng, radio_logs.created_at,radio_logs.mnc,radio_logs.ssi, radios.image_index FROM radio_logs " +
                    "JOIN radios ON radio_logs.radio_id = radios.id " +
                    "WHERE radio_logs.radio_id IN(" + String.Join(",", radios.ToArray()) + ") " +
                    "ORDER BY radio_logs.created_at DESC) as temp " +
                    "GROUP BY radio_id");


                foreach (DataRow row in dt_radios.Rows) // Loop over the rows.
                {
                    PointLatLng p = new PointLatLng
                    {
                        Lat = float.Parse(row["lat"].ToString()),
                        Lng = float.Parse(row["lng"].ToString())
                    };

                    Image[] images = 
                    {
                        Properties.Resources.train_green,
                        Properties.Resources.train_red,
                        Properties.Resources.train_yellow,
                        Properties.Resources.train_blue,
                        Properties.Resources.train_brown,
                    };
                    Image image_marker;
                    if (DateTime.Now.Subtract(Convert.ToDateTime(row["created_at"])).TotalSeconds > (int)Properties.Settings.Default.Limit)
                    {
                        image_marker = Properties.Resources.train_gray;
                    }
                    else
                    {
                        image_marker = images[(int)row["image_index"]];
                    }


                    Image markerImage = image_marker;
                    GMapMarkerImage marker = new GMapMarkerImage(p, markerImage);
                    radio_overlay.Markers.Add(marker);

                    // marker.ToolTipMode = MarkerTooltipMode.Always; enable tooltip
                    marker.ToolTipText = row["mnc"].ToString() + " - " + row["ssi"].ToString();

                }
            }
            gMap.Refresh();
            #endregion
            timer.Enabled = true;
        }

        private void frmMap_Load(object sender, EventArgs e)
        {

        }

    }
}
