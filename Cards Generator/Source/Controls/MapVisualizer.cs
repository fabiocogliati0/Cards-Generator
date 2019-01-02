﻿using System;
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

        public void SetMap(int[,] tiles)
        {
            int W = this.Width;
            int H = this.Height;

            int nTileW = tiles.GetLength(0);
            int nTileH = tiles.GetLength(1);

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

                        Brush currentBrush = null;

                        switch (tiles[i, j])
                        {
                            case 0:
                                currentBrush = Brushes.Blue;
                                break;
                            case 1:
                                currentBrush = Brushes.Red;
                                break;
                            case 2:
                                currentBrush = Brushes.Yellow;
                                break;
                            case 3:
                                currentBrush = Brushes.Purple;
                                break;
                            case 4:
                                currentBrush = Brushes.Orange;
                                break;
                            default:
                                currentBrush = Brushes.Black;
                                break;
                        }

                        Rectangle rectangle = new Rectangle(posX, posY, rectSizeX, rectSizeY);
                        graphics.DrawRectangle(Pens.Black, rectangle);
                        graphics.FillRectangle(currentBrush, rectangle);
                    }
                }
            }

            this.Image = bitmap;
        }
    }
}
