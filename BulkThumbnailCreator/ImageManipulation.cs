using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace BulkThumbnailCreator
{
    public class ImageManipulation
    {
        Bitmap[] bitmapArray;
        readonly object locker = new object();
        string Path { get; set; }
 
        public ImageManipulation(string path)
        {
            Path = path;
        }

        public string[] GetImages(string imageFormat)
        {
            string[] images = Directory.GetFiles(Path, imageFormat);
            Console.WriteLine("Images from director:");

            foreach(var image in images)
            {
                Console.WriteLine(image.ToString());
            }

            return images;
        }

        public void SetBitmapObjects(string[] images)
        {
            if (images != null)
            {
                bitmapArray = new Bitmap[images.Length];

                for (var i = 0; i < bitmapArray.Length; i++)
                {
                    bitmapArray[i] = new Bitmap(images[i]);
                }
            }
            else
            {
                Console.WriteLine("Error. Directory hasnt images.");
            }

            Console.WriteLine("\nBitmap object done.\n");
        }

        public void ChangeImageSize(object size)
        {
            lock (locker)
            {
                if (size is ImageSize)
                {
                    for (var i = 0; i < bitmapArray.Length; i++)
                    {
                        bitmapArray[i].SetResolution(((ImageSize)size).Weight, ((ImageSize)size).Height);
                    }
                }
                Console.WriteLine("Changes are done.\n");
            }
        }

        public void SaveChangedImages(object pathToSave)
        {
            lock (locker)
            {
                if (pathToSave is string)
                {
                    for (var i = 0; i < bitmapArray.Length; i++)
                    {
                        bitmapArray[i].Save($"{(string)pathToSave}\\{i}.jpg");
                    }
                }

                Console.WriteLine("Saves are done.\n");
            }
        }
    }
}
