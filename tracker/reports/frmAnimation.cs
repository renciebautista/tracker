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

namespace tracker.reports
{
    public partial class frmAnimation : Form
    {
        internal readonly GMapOverlay objects = new GMapOverlay("objects");
        private DataTable dtLogs;
        private string header;
        private string id;
        private string name;
        int lastCount;
        public DataTable DataSource
        {
            set { dtLogs = value; }
        }
        public string Header
        {
            set { header = value; }
        }
        public string Id
        {
            set { id = value; }
        }

        public string Name
        {
            set { name = value; }
        }

        public frmAnimation()
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
            // set cache mode only if no internet avaible
            if (!Stuff.PingNetwork("pingtest.com"))
            {
                gMap.Manager.Mode = AccessMode.CacheOnly;
                MessageBox.Show("No internet connection available, going to CacheOnly mode.", "Tracker", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmAnimation_Load(object sender, EventArgs e)
        {
            this.Text = header;
            lastCount = 0;
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            gMap.Zoom = trackBar.Value;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (lastCount < dtLogs.Rows.Count)
            {
                objects.Markers.Clear();
                List<PointLatLng> positions = new List<PointLatLng>();

                PointLatLng p = new PointLatLng
                {
                    Lat = float.Parse(dtLogs.Rows[lastCount]["lat"].ToString()),
                    Lng = float.Parse(dtLogs.Rows[lastCount]["lng"].ToString())
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
                image_marker = images[(int)dtLogs.Rows[lastCount]["image_index"]];


                Image markerImage = image_marker;

                GMapMarkerImage marker = new GMapMarkerImage(p, markerImage);
                objects.Markers.Add(marker);
                marker.ToolTipText = dtLogs.Rows[lastCount][id].ToString() + " - " + dtLogs.Rows[lastCount][name].ToString();

                gMap.Refresh();
                lastCount++;
            }
            else
            {
                timer1.Enabled = false;
                MessageBox.Show("Animation complete.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void trackBarSpeed_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = 1000 / trackBarSpeed.Value;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            lastCount = 0;
        }


        
    }
}
