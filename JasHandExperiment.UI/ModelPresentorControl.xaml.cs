using HelixToolkit.Wpf;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace JasHandExperiment.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ModelPresentorControl : UserControl
    {
        #region Data Members
        /// <summary>
        /// Model for 3D vsualiation
        /// </summary>
        ModelVisual3D mDeviceVisual3D;

        /// <summary>
        /// 3D devise to present a model
        /// </summary>
        Model3D mDevice3D;

        #endregion

        #region Ctor
        public ModelPresentorControl()
        {
            InitializeComponent();
            mDeviceVisual3D = new ModelVisual3D();
        }
        #endregion

        #region Functions
        /// <summary>
        /// The functino loads given model with given color to the 3D device.
        /// model need to be an .obj file.
        /// </summary>
        /// <param name="modelPath">path to the model file</param>
        /// <param name="col">the color to paint the model</param>
        /// <returns>boolean indicating successful operation</returns>
        public bool LoadModel(string modelPath, Color col)
        {
            try
            {
                // get 3D content
                mDeviceVisual3D.Content = Display3d(modelPath, col);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error loading model. exeption: " + ex.Message);
                return false;
            }
            if (!viewPort3d.Children.Contains(mDeviceVisual3D))
            {
                // Add to view port
                viewPort3d.Children.Add(mDeviceVisual3D);
            }
            return true;
        }

        /// <summary>
        /// Display 3D Model
        /// </summary>
        /// <param name="modelPath">Path to the Model file</param>
        /// <param name="modelColor">color to set to model</param>
        /// <returns>3D Model Content</returns>
        private Model3D Display3d(string modelPath, Color modelColor)
        {
            try
            {
                //Adding a gesture here
                viewPort3d.RotateGesture = new MouseGesture(MouseAction.LeftClick);

                //Import 3D model file
                ModelImporter import = new ModelImporter();

                //Load the 3D model file
                mDevice3D = import.Load(modelPath);

                ChangeModelColor(modelColor);
            }
            catch (Exception e)
            {
                // Handle exception in case can not file 3D model
                MessageBox.Show("Exception Error : " + e.Message);
            }
            return mDevice3D;
        }

        /// <summary>
        /// The function sets the model color accordign to 'modelColor'
        /// </summary>
        /// <param name="modelColor">the color to set</param>
        public void ChangeModelColor(Color modelColor)
        {
            // Set your RGB Color on the SolitColorBrush
            Material mat = MaterialHelper.CreateMaterial(new SolidColorBrush(modelColor));

            //Replace myModel3DGroup by your Model3DGroup of your view....

            Model3DGroup groupDevice = (Model3DGroup)mDevice3D;
            foreach (System.Windows.Media.Media3D.GeometryModel3D geometryModel in groupDevice.Children)
            {
                geometryModel.Material = mat;
                geometryModel.BackMaterial = mat;
            }
        }

        #endregion
    }
}