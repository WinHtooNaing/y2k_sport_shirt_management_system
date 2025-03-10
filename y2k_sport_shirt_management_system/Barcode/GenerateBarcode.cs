    using System;
    using ZXing.Common;
    using ZXing;


    namespace y2k_sport_shirt_management_system.Barcode
    {
        public class GenerateBarcode
        {
            
     
        public void BarCodeGenerator(BarcodeFormat format, PictureBox pic, string barcodeName)
        {
            try
            {
                if (string.IsNullOrEmpty(barcodeName))
                {
                    MessageBox.Show("Barcode data is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (pic.Width <= 0 || pic.Height <= 0)
                {
                    MessageBox.Show("PictureBox size is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var barcodeWrite = new BarcodeWriterPixelData
                {
                    Format = format,
                    Options = new ZXing.Common.EncodingOptions
                    {
                        Height = pic.Height,
                        Width = pic.Width,
                        Margin = 5
                    }
                };

                var pixelDate = barcodeWrite.Write(barcodeName);

                if (pixelDate == null || pixelDate.Pixels == null || pixelDate.Pixels.Length == 0)
                {
                    MessageBox.Show("Failed to generate barcode pixel data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Color codeColor = Color.Indigo;
                Color backgroundColor = Color.White;

                var bitmap = new Bitmap(pixelDate.Width, pixelDate.Height);

                for (int i = 0; i < pixelDate.Height; i++)
                {
                    for (int j = 0; j < pixelDate.Width; j++)
                    {
                        int index = (i * pixelDate.Width + j) * 4;
                        bool isBlackpixel = pixelDate.Pixels[index] == 0 && pixelDate.Pixels[index + 1] == 0 && pixelDate.Pixels[index + 2] == 0;

                        bitmap.SetPixel(j, i, isBlackpixel ? codeColor : backgroundColor);
                    }
                }

                pic.Image = bitmap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating barcode: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}