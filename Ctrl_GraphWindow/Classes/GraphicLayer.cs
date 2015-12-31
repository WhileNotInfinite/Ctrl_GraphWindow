using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ctrl_GraphWindow
{
    internal delegate Image LayerDrawingMethodHandler(Graphics ImgGraphics);

    internal class GraphicLayer
    {
        #region Public members

        public Image LayerImage;
        public Graphics LayerGraphics;

        public LayerDrawingMethodHandler DrawingMethod;

        #endregion

        public GraphicLayer(LayerDrawingMethodHandler LayerDrawingMethod)
        {
            DrawingMethod = LayerDrawingMethod;
        }

        #region Public methods

        public void ResetLayer(Size ImageSize)
        {
            LayerImage = new Bitmap(ImageSize.Width, ImageSize.Height);
            LayerGraphics = Graphics.FromImage(LayerImage);
        }

        public Image GetLayerImage()
        {
            return (DrawingMethod.Invoke(LayerGraphics));
        }

        #endregion
    }

    internal class MultiLayerImage
    {
        #region Public member

        public Image FinalImage;

        #endregion

        #region Private members

        private Size ImgSize;
        private Color ImgBackColor;
        private Graphics ImgGraphics;

        private List<GraphicLayer> Layers;

        #endregion

        public MultiLayerImage(LayerDrawingMethodHandler[] DrawingMethods)
        {
            if (DrawingMethods.Length > 0)
            {
                Layers = new List<GraphicLayer>();

                foreach(LayerDrawingMethodHandler DrawingFuncDelegate in DrawingMethods)
                {
                    GraphicLayer oLayer = new GraphicLayer(DrawingFuncDelegate);
                    Layers.Add(oLayer);
                }
            }
        }

        #region Public methods 

        public void ResetImage(Size ImageSize, Color ImageBackColor)
        {
            ImgSize = ImageSize;
            ImgBackColor = ImageBackColor;

            foreach (GraphicLayer oLayer in Layers)
            {
                oLayer.ResetLayer(ImgSize);
            }
        }

        public void DrawImage(int StartingLayer)
        {
            Point OriginPoint = new Point(0, 0);

            if (StartingLayer == 0) //Draw image from strach
            {
                FinalImage = new Bitmap(ImgSize.Width, ImgSize.Height);
                ImgGraphics = Graphics.FromImage(FinalImage);
                ImgGraphics.Clear(ImgBackColor);
            }
            else //Draw image from an intermediate stage
            {
                FinalImage = new Bitmap(Layers[StartingLayer].LayerImage);
                ImgGraphics = Graphics.FromImage(FinalImage);
            }

            for (int iLayer = StartingLayer; StartingLayer < Layers.Count; iLayer++)
            {
                GraphicLayer oLayer = Layers[iLayer];

                oLayer.LayerImage = (Image)FinalImage.Clone(); //Store final image after the previous stage
                ImgGraphics.DrawImage(oLayer.GetLayerImage(), OriginPoint); //Stack the new layer on the final image
            }
        }

        #endregion
    }
}
