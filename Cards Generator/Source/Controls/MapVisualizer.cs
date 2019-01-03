using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cards_Generator
{
    public partial class MapVisualizer : PictureBox
    {
        public MapVisualizer()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public void SetMap(BoardMap boardMap)
        {
            int W = this.Width;
            int H = this.Height;

            int nTileW = boardMap.Tiles.GetLength(0);
            int nTileH = boardMap.Tiles.GetLength(1);

            int rectSizeX = W / nTileW;
            int rectSizeY = H / nTileH;

            Rectangle[] allRectangles = new Rectangle[nTileW * nTileH];

            Bitmap bitmap = new Bitmap(W, H);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                for (var i = 0; i < nTileW; ++i)
                {
                    for (var j = 0; j < nTileH; ++j)
                    {
                        int posX = rectSizeX * i;
                        int posY = rectSizeY * j;

                        Rectangle rectangle = new Rectangle(posX, posY, rectSizeX, rectSizeY);
                        BoardMap.ETileType tileType = boardMap.Tiles[i, j];
                        Brush currentBrush = new SolidBrush(Globals.UISettings.TilesDebugBrushColors[tileType]);
                        graphics.FillRectangle(currentBrush, rectangle);
                    }
                }
            }

            this.Image = bitmap;
        }
    }
}
