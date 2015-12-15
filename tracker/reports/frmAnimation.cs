using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
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
        internal readonly GMapOverlay traces = new GMapOverlay("traces");
        private DataTable dtLogs;
        private string header;
        private string id;
        private string name;
        int lastCount;
        private ReportType _type;

        readonly Dictionary<string, GMapMarkerImage> objectMarkers = new Dictionary<string, GMapMarkerImage>();
        Image[] images = 
            {
                Properties.Resources.train_green,
                Properties.Resources.train_red,
                Properties.Resources.train_yellow,
                Properties.Resources.train_blue,
                Properties.Resources.train_brown,
                                Properties.Resources.b_unit1,
                Properties.Resources.b_unit2,
                Properties.Resources.b_unit3,
                Properties.Resources.b_unit4,
                Properties.Resources.b_unit5,
                Properties.Resources.b_unit6,
                Properties.Resources.b_unit7,
                Properties.Resources.b_unit8,
                Properties.Resources.b_unit9,
                Properties.Resources.b_unit10,
                Properties.Resources.b_unit11,
                Properties.Resources.b_unit12,
                Properties.Resources.b_unit13,
                Properties.Resources.b_unit14,
                Properties.Resources.b_unit15,
                Properties.Resources.b_unit16,
                Properties.Resources.b_unit17,
                Properties.Resources.b_unit18,
                Properties.Resources.b_unit19,
                Properties.Resources.b_unit20,
                Properties.Resources.g_unit1,
                Properties.Resources.g_unit2,
                Properties.Resources.g_unit3,
                Properties.Resources.g_unit4,
                Properties.Resources.g_unit5,
                Properties.Resources.g_unit6,
                Properties.Resources.g_unit7,
                Properties.Resources.g_unit8,
                Properties.Resources.g_unit9,
                Properties.Resources.g_unit10,
                Properties.Resources.g_unit11,
                Properties.Resources.g_unit12,
                Properties.Resources.g_unit13,
                Properties.Resources.g_unit14,
                Properties.Resources.g_unit15,
                Properties.Resources.g_unit16,
                Properties.Resources.g_unit17,
                Properties.Resources.g_unit18,
                Properties.Resources.g_unit19,
                Properties.Resources.g_unit20,
                Properties.Resources.r_unit1,
                Properties.Resources.r_unit2,
                Properties.Resources.r_unit3,
                Properties.Resources.r_unit4,
                Properties.Resources.r_unit5,
                Properties.Resources.r_unit6,
                Properties.Resources.r_unit7,
                Properties.Resources.r_unit8,
                Properties.Resources.r_unit9,
                Properties.Resources.r_unit10,
                Properties.Resources.r_unit11,
                Properties.Resources.r_unit12,
                Properties.Resources.r_unit13,
                Properties.Resources.r_unit14,
                Properties.Resources.r_unit15,
                Properties.Resources.r_unit16,
                Properties.Resources.r_unit17,
                Properties.Resources.r_unit18,
                Properties.Resources.r_unit19,
                Properties.Resources.r_unit20,
            };

        Image[] radio_images = 
            {
                Properties.Resources.BLUE_HILITED,
                Properties.Resources.RED_HILITED,
                Properties.Resources.FIRE_BLUE_HILITED,
                Properties.Resources.FIRE_GREY_HILITED,
                Properties.Resources.FIRE_RED_HILITED,
                Properties.Resources.INDIE_BLUE_HILITED,
                Properties.Resources.INDIE_GREY_HILITED,
                Properties.Resources.INDIE_RED_HILITED,
                Properties.Resources.MEDIC_BLUE_HILITED,
                Properties.Resources.MEDIC_GREY_HILITED,
                Properties.Resources.MEDIC_RED_HILITED,
                Properties.Resources.PET_BLUE_HILITED,
                Properties.Resources.PET_GREY_HILITED,
                Properties.Resources.PET_RED_HILITED,
                Properties.Resources.POLICE_BLUE_HILITED,
                Properties.Resources.POLICE_GREY_HILITED,
                Properties.Resources.POLICE_RED_HILITED,
                Properties.Resources.VEHICLE_BLUE_HILITED,
                Properties.Resources.VEHICLE_GRE_HILITED,
                Properties.Resources.VEHICLE_RED_HILITED,
                Properties.Resources.b_unit1,
                Properties.Resources.b_unit2,
                Properties.Resources.b_unit3,
                Properties.Resources.b_unit4,
                Properties.Resources.b_unit5,
                Properties.Resources.b_unit6,
                Properties.Resources.b_unit7,
                Properties.Resources.b_unit8,
                Properties.Resources.b_unit9,
                Properties.Resources.b_unit10,
                Properties.Resources.b_unit11,
                Properties.Resources.b_unit12,
                Properties.Resources.b_unit13,
                Properties.Resources.b_unit14,
                Properties.Resources.b_unit15,
                Properties.Resources.b_unit16,
                Properties.Resources.b_unit17,
                Properties.Resources.b_unit18,
                Properties.Resources.b_unit19,
                Properties.Resources.b_unit20,
                Properties.Resources.g_unit1,
                Properties.Resources.g_unit2,
                Properties.Resources.g_unit3,
                Properties.Resources.g_unit4,
                Properties.Resources.g_unit5,
                Properties.Resources.g_unit6,
                Properties.Resources.g_unit7,
                Properties.Resources.g_unit8,
                Properties.Resources.g_unit9,
                Properties.Resources.g_unit10,
                Properties.Resources.g_unit11,
                Properties.Resources.g_unit12,
                Properties.Resources.g_unit13,
                Properties.Resources.g_unit14,
                Properties.Resources.g_unit15,
                Properties.Resources.g_unit16,
                Properties.Resources.g_unit17,
                Properties.Resources.g_unit18,
                Properties.Resources.g_unit19,
                Properties.Resources.g_unit20,
                Properties.Resources.r_unit1,
                Properties.Resources.r_unit2,
                Properties.Resources.r_unit3,
                Properties.Resources.r_unit4,
                Properties.Resources.r_unit5,
                Properties.Resources.r_unit6,
                Properties.Resources.r_unit7,
                Properties.Resources.r_unit8,
                Properties.Resources.r_unit9,
                Properties.Resources.r_unit10,
                Properties.Resources.r_unit11,
                Properties.Resources.r_unit12,
                Properties.Resources.r_unit13,
                Properties.Resources.r_unit14,
                Properties.Resources.r_unit15,
                Properties.Resources.r_unit16,
                Properties.Resources.r_unit17,
                Properties.Resources.r_unit18,
                Properties.Resources.r_unit19,
                Properties.Resources.r_unit20,
            };

        public enum ReportType
        {
            Train, Radio
        };
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

        public frmAnimation(ReportType type)
        {
            InitializeComponent();
            _type = type;
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

            gMap.Overlays.Add(traces);
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
            timer1.Enabled = true;
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            gMap.Zoom = trackBar.Value;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (lastCount < dtLogs.Rows.Count)
            {

                PointLatLng p = new PointLatLng
                {
                    Lat = float.Parse(dtLogs.Rows[lastCount]["lat"].ToString()),
                    Lng = float.Parse(dtLogs.Rows[lastCount]["lng"].ToString())
                };

                GMapMarkerImage trace_marker;
                Image trace_image_marker;
                trace_image_marker = (Image)Properties.Resources.trace;
                Image imagemarkerImage = trace_image_marker;

                trace_marker = new GMapMarkerImage(p, imagemarkerImage); ;


               
                traces.Markers.Add(trace_marker);


                GMapMarkerImage marker;
                Image image_marker;
                if (_type == ReportType.Radio)
                {
                    image_marker = radio_images[(int)dtLogs.Rows[lastCount]["image_index"]];
                }
                else
                {
                    image_marker = images[(int)dtLogs.Rows[lastCount]["image_index"]];
                }
                

                string id = dtLogs.Rows[lastCount][name].ToString();
                if (!objectMarkers.TryGetValue(id, out marker))
                {
                    if (_type == ReportType.Radio)
                    {
                        marker = new GMapMarkerImage(p, image_marker,32,32);
                    }
                    else
                    {
                        marker = new GMapMarkerImage(p, image_marker);
                    }
                    
                    marker.Tag = id;

                    objectMarkers[id] = marker;
                    objects.Markers.Add(marker);
                }
                else
                {
                    marker.Position = p;
                }

                objects.Markers.Add(marker);
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
            objects.Markers.Clear();
            traces.Markers.Clear();
            timer1.Enabled = true;
            lastCount = 0;
        }


        
    }
}
