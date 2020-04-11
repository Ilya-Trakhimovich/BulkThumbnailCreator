using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace BulkThumbnailCreator
{
    public class ImageManipulation
    {
        private Bitmap[] _bitmapArray;
        private int _count = 0;

        string Path { get; set; }

        public ImageManipulation(string path)
        {
            Path = path;
        }

        public string[] GetImages(string imageFormat)
        {
            string[] images = Directory.GetFiles(Path, imageFormat);
            Console.WriteLine("Images from directory:");

            foreach (var image in images)
            {
                Console.WriteLine(image.ToString());
            }

            return images;
        }

        public void SetBitmapObjects(string[] images)
        {
            if (images != null)
            {
                _bitmapArray = new Bitmap[images.Length];

                for (var i = 0; i < _bitmapArray.Length; i++)
                {
                    _bitmapArray[i] = new Bitmap(images[i]);
                }
            }
            else
            {
                Console.WriteLine("Error. Directory hasnt images.");
            }

            Console.WriteLine("\nBitmap object done.\n");
        }

        public Bitmap[] GetBitmapArray()
        {
            return _bitmapArray;
        }

        public void RenameResizeResaveImage(object obj)
        {
            if (obj is Bitmap)
            {
                ChangeImageSize((Bitmap)obj);
                SaveChangedImage((Bitmap)obj);
            }
        }

        private void ChangeImageSize(Bitmap bitmap)
        {
            bitmap.SetResolution(800, 600);
            Console.WriteLine("Changes are done.");
        }

        private void SaveChangedImage(Bitmap bitmap)
        {

            bitmap.Save($@"E:\NewResizePhoto\{_count++}.jpg");
            Console.WriteLine("Save is done.\n");
        }
    }
}
