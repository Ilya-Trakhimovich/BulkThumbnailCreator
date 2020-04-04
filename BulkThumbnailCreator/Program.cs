using System;
using System.Drawing;
using System.IO;
using System.Threading;


namespace BulkThumbnailCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            ImageManipulation manipulator = new ImageManipulation(@"E:\Photo");
            Thread threadChangeImageSize = new Thread(manipulator.ChangeImageSize);
            Thread threadSaveImages = new Thread(manipulator.SaveChangedImages);
            threadSaveImages.Priority = ThreadPriority.Lowest;
            string[] images = manipulator.GetImages("*.jpg");

            manipulator.SetBitmapObjects(images);
            threadChangeImageSize.Start(new ImageSize(800,600));
            threadSaveImages.Start(@"E:\NewResizePhoto");
        }
    }
}
