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
using System.Threading;
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
        public frmMap()
        {
            InitializeComponent();

            initMap();

            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;

           backgroundWorker2.WorkerReportsProgress = true;
            backgroundWorker2.WorkerSupportsCancellation = true;
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


        private void frmMap_Load(object sender, EventArgs e)
        {


        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            gMap.Zoom = trackBar.Value;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();

            }

            if (backgroundWorker2.IsBusy != true)
            {
                backgroundWorker2.RunWorkerAsync();
            }
            
            /*timer.Enabled = false;
            this.doPlot();
            timer.Enabled = true;*/
           
        }

        private void doPlot()
        {
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

                DataTable dt = MysqlHelper.ExecuteDataTable("SELECT train_id,train_code,train_desc, lat,lng, image_index,last_update FROM cur_trains " +
                   "JOIN trains ON trains.id = cur_trains.train_id " +
                    "AND cur_trains.train_id IN(" + String.Join(",", list.ToArray()) + ") ");


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
                    Image image_marker;
                    if (DateTime.Now.Subtract(Convert.ToDateTime(row["last_update"])).TotalSeconds > (int)Properties.Settings.Default.Limit) 
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
                DataTable dt_radios =  MysqlHelper.ExecuteDataTable("SELECT radio_id, lat, lng,last_update,mnc,ssi, image_index FROM cur_radios " +
                    "JOIN radios ON  radios.id = cur_radios.radio_id " +
                    "WHERE cur_radios.radio_id IN(" + String.Join(",", radios.ToArray()) + ") " );


                foreach (DataRow row in dt_radios.Rows) // Loop over the rows.
                {
                    PointLatLng p = new PointLatLng
                    {
                        Lat = float.Parse(row["lat"].ToString()),
                        Lng = float.Parse(row["lng"].ToString())
                    };

                    Image image_marker;

                    if (DateTime.Now.Subtract(Convert.ToDateTime(row["last_update"])).TotalSeconds > (int)Properties.Settings.Default.Limit)
                    {
                        image_marker = Properties.Resources.GREY_HILITED;
                    }
                    else
                    {
                        image_marker = radio_images[(int)row["image_index"]];
                    }

                    GMapMarkerImage marker = new GMapMarkerImage(p, image_marker,32,32);
                    radio_overlay.Markers.Add(marker);

                    // marker.ToolTipMode = MarkerTooltipMode.Always; enable tooltip
                    marker.ToolTipText = row["mnc"].ToString() + " - " + row["ssi"].ToString();

                }
            }
            gMap.Refresh();
            #endregion
            timer.Enabled = true;
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var list = Properties.Settings.Default.Trains.Cast<string>().ToList();
            var dt = new DataTable();
             if (list.Count > 0)
             {
                 dt = MysqlHelper.ExecuteDataTable("SELECT train_id,train_code,train_desc, lat,lng, image_index,last_update FROM cur_trains " +
                   "JOIN trains ON trains.id = cur_trains.train_id " +
                    "AND cur_trains.train_id IN(" + String.Join(",", list.ToArray()) + ") ");
             }

           
            e.Result =   dt;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DataTable dt = (DataTable)e.Result;

            objects.Markers.Clear();

            var list = Properties.Settings.Default.Trains.Cast<string>().ToList();

            foreach (DataRow row in dt.Rows) // Loop over the rows.
            {
                if (list.Contains(row["train_id"].ToString()))
                {
                    PointLatLng p = new PointLatLng
                    {   
                        Lat = float.Parse(row["lat"].ToString()),
                        Lng = float.Parse(row["lng"].ToString())
                    };

                    Image image_marker;
                    if (DateTime.Now.Subtract(Convert.ToDateTime(row["last_update"])).TotalSeconds > (int)Properties.Settings.Default.Limit)
                    {
                        image_marker = Properties.Resources.train_gray;
                    }
                    else
                    {
                        image_marker = images[(int)row["image_index"]];
                    }


                    Image markerImage = image_marker;

                    GMapMarkerImage marker = new GMapMarkerImage(p, markerImage);
                    objects.Markers.Add(marker);
                    marker.ToolTipText =  row["train_code"].ToString() + " - " + row["train_desc"].ToString();
                    //marker.ToolTipMode = MarkerTooltipMode.Always;
                }
                

            }

            gMap.Refresh();

        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            var radios = Properties.Settings.Default.Radios.Cast<string>().ToList();
            var dt_radios = new DataTable();

            if (radios.Count > 0)
            {
                dt_radios = MysqlHelper.ExecuteDataTable("SELECT radio_id, lat, lng,last_update,mnc,ssi, image_index FROM cur_radios " +
                    "JOIN radios ON  radios.id  = cur_radios.radio_id " +
                    "WHERE cur_radios.radio_id IN(" + String.Join(",", radios.ToArray()) + ") " );
            }


            e.Result = dt_radios;
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
           var radios = Properties.Settings.Default.Radios.Cast<string>().ToList();
            DataTable dt_radios = (DataTable)e.Result;
            radio_overlay.Markers.Clear();
            foreach (DataRow row in dt_radios.Rows) // Loop over the rows.
            {
                if(radios.Contains(row["radio_id"].ToString())){
                    PointLatLng p = new PointLatLng
                    {
                        Lat = float.Parse(row["lat"].ToString()),
                        Lng = float.Parse(row["lng"].ToString())
                    };

                    Image image_marker;

                    if (DateTime.Now.Subtract(Convert.ToDateTime(row["last_update"])).TotalSeconds > (int)Properties.Settings.Default.Limit)
                    {
                        image_marker = Properties.Resources.GREY_HILITED;
                    }
                    else
                    {
                        image_marker = radio_images[(int)row["image_index"]];
                    }

                    GMapMarkerImage marker = new GMapMarkerImage(p, image_marker, 32, 32);
                    radio_overlay.Markers.Add(marker);

                    // marker.ToolTipMode = MarkerTooltipMode.Always; enable tooltip
                    marker.ToolTipText = row["mnc"].ToString() + " - " + row["ssi"].ToString();
                    //marker.ToolTipMode = MarkerTooltipMode.Always;
                }


            }
        }

    }
}
