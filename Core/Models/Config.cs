﻿using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;

namespace AppBar.Core.Models
{
    /// <summary>
    /// AppBar Configuration
    /// </summary>
    [Serializable]
    public class Config
    {
        #region Static Instances

        /// <summary>
        /// Configuration Instance for the current AppBar instance
        /// </summary>
        public static Config Instance = null;

        #endregion

        #region Public Properties
        /// <summary>
        /// List of programs saved in the configuration
        /// </summary>
        public List<Program> Programs;

        /// <summary>
        /// List of custom icons
        /// </summary>
        public List<BitmapImage> CustomIcons;

        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="pList"> List of programs </param>
        /// <param name="customIconList"> List of custom icons </param>
        public Config(List<Program> pList,List<BitmapImage> customIconList)
        {
            Programs = new List<Program>(pList);
            CustomIcons = new List<BitmapImage>(customIconList);
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Get a Configuration from file
        /// </summary>
        /// <param name="filename">Path + filename of configuration file</param>
        /// <returns>A Config if the Deserialization succeeded : null otherwise</returns>
        public static Config ReadConfiguration(string filename)
        {
            Config newConfig = null;

            try
            {
                newConfig = Helpers.Serializer.DeserializeObj<Config>(filename);
            }
            catch
            {
                return null;
            }

            return newConfig;
        }

        /// <summary>
        /// SAve a Configuration to file
        /// </summary>
        /// <param name="config">Configuration to be saved</param>
        /// <param name="filename">Path + filename of configuration file</param>
        /// <returns>True if Serialization succeeded : False otherwise</returns>
        public static bool SaveConfiguration(string filename)
        {
            try
            {
                Helpers.Serializer.SerializeObj<Config>(Instance, filename);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Loads an Empty Configuration
        /// </summary>
        public static void LoadDefaultConfiguration()
        {
            Instance = new Config(null, null);
        }
        
        #endregion
    }
}