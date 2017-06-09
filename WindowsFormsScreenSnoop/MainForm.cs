using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsScreenSnoop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Thread newThread = new Thread(DrawPicture);
            newThread.Start();
        }
        public  void DrawPicture()
        {

            try
            {
                Int32 port = 13000;
                using (TcpClient client = new TcpClient("127.0.0.1", port))
                {
                    using (NetworkStream stream = client.GetStream())
                    {
                        IFormatter formatter = new BinaryFormatter();
                        while (true)
                        {
                            MethodInvoker mi = delegate () {
                                Image image = (Image)formatter.Deserialize(stream);
                                if(PictureBoxSnoop.Width != 0 && PictureBoxSnoop.Height !=0)
                                {
                                    image = ResizeImage(image, PictureBoxSnoop.Width, PictureBoxSnoop.Height);
                                }
                         
                                PictureBoxSnoop.Image = image;
                                /*
                                PictureBoxSnoop.Height = image.Height;
                                PictureBoxSnoop.Width = image.Width;
                                */
                               PictureBoxSnoop.SizeMode = PictureBoxSizeMode.CenterImage;
                            };
                            this.Invoke(mi);
                            Thread.Sleep(1000);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public  Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }


        /*
        bool receiveWriteImage(Stream fileForWrite, NetworkStream stream)
        {
            try
            {
                //logger.Info("receiveWriteImage");
                Byte[] inputDataLength = new Byte[4];
                int dataLength = 0;

                lock (this)
                {
                    dataLength = BitConverter.ToInt32(inputDataLength, 0);
                    // logger.Info("dataLength accepted {0}", dataLength.ToString());
                    int chunkSize = 1024;
                    Byte[] data = new Byte[0];
                    while (data.Length <= dataLength || stream.DataAvailable)
                    {
                        Byte[] buffer = new Byte[chunkSize];
                        int size = stream.Read(buffer, 0, chunkSize);
                        Byte[] concatMassive = new Byte[data.Length + buffer.Length];
                        data.CopyTo(concatMassive, 0);
                        buffer.CopyTo(concatMassive, data.Length);
                        data = concatMassive;
                    }
                    fileForWrite.Write(data, 0, data.Length);
                }
                
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("image wasn't received. Exception {0}", ex.Message);
                //logger.Info("image wasn't received. Exception {0}", ex.Message);
                return false;
            }
        }

    */
        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
    }
}
