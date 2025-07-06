using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Full_Project.Global_Class
{
    public static class clsUtil
    {
        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {
            if (!System.IO.Directory.Exists(FolderPath))
            {
                try
                {
                    System.IO.Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error creating directory: {ex.Message}");
                    return false;
                }
            }
            return true;
        }
        public static string ReplaceFileNameWithGUID(string FilePath)
        {
            string Extension = System.IO.Path.GetExtension(FilePath);            
            return Guid.NewGuid().ToString() + Extension;
        }
        public static bool CopyImageToProjectImagesFolder (ref string SourceImage)
        {
            string DestinationFolder = @"C:\DVLD-People-Images\";
            if(!CreateFolderIfDoesNotExist(DestinationFolder))
            {
                return false;
            }
            string destinationFolder = DestinationFolder + ReplaceFileNameWithGUID(SourceImage);
            try
            {
                File.Copy(SourceImage, destinationFolder, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error copying image: {ex.Message}");
                return false;
            }
            SourceImage = destinationFolder;
            return true;
        }
    }
}
