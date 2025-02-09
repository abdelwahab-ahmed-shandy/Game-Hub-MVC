﻿using static System.Net.Mime.MediaTypeNames;

namespace GameZone.Settings
{
    public static class FileSettings
    {
        public const string ImagesPath = "/assets/images/games";
        public const string AllowedExtensions = ".png,.jpg,.jpes,.png";
        public const int FileMaxSizeInMB = 1;
        public const int FileMaxSizeInBytes = 1024 * 1024 * FileMaxSizeInMB;
    }
}
