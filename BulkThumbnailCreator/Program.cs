using System.Threading;
using System.Configuration;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using System;

namespace BulkThumbnailCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            var pathtoDirectory = ConfigurationManager.AppSettings["Path"]; // get information from app.config
            var pathToNewFolder = ConfigurationManager.AppSettings["NewPath"];

            ImageManipulation manipulator = new ImageManipulation(pathtoDirectory);
            string[] images = manipulator.GetImages("*.jpg");
            manipulator.SetBitmapObjects(images);
            Bitmap[] bitmaps = manipulator.GetBitmapArray();

            for (var i = 0; i < bitmaps.Length; i++) // zero version: both methods are executed in one thread
            {
                Thread thread = new Thread(manipulator.RenameResizeResaveImage);
                thread.Start(bitmaps[i]);
            }

            //Thread threadChangeImageSize = new Thread(manipulator.ChangeImageSize); // first version: 2 methods are executed in defferent threads
            //Thread threadSaveImages = new Thread(manipulator.SaveChangedImage);
            //threadSaveImages.Priority = ThreadPriority.Lowest;       
            //manipulator.SetBitmapObjects(images);
            //threadChangeImageSize.Start(new ImageSize(800,600));
            //threadSaveImages.Start(pathToNewFolder);

            //Parallel.ForEach(bitmaps, manipulator.RenameResizeResaveImage); // second version: tasks 
        }
    }
}
