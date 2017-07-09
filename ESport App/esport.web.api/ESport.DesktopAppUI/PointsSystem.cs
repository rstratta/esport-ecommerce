using ESport.Data.Commons;
using ESport.Data.Service;
using System;
using System.Windows.Forms;

namespace ESport.DesktopAppUI
{

    public partial class PointsSystem : UserControl
    {
        private IPointSystemConfigurationService pointSystemConfigurationService;
        public PointsSystem(IPointSystemConfigurationService pointSystemConfigurationService)
        {
            InitializeComponent();
            this.pointSystemConfigurationService = pointSystemConfigurationService;
            PointSystemConfigurationDTO currentConfiguration= pointSystemConfigurationService.GetPointSystemConfiguration();
            SetCurrentConfigurationValueLabel(currentConfiguration.PropertyValue);
        }

        private void SetCurrentConfigurationValueLabel(double currentValue)
        {
            currentPointConfigurationValue.Text = " $ " + currentValue;
        }

        private void pointSystemConfigurationButton_Click(object sender, EventArgs e)
        {
            try
            {
                double inputValue = Convert.ToDouble(pointSystemConfigurationValue.Value);
                pointSystemConfigurationService.SavePointSystemCongirutraion(new PointSystemConfigurationDTO() { PropertyName = ESportUtils.LOYALTY_PROPERTY_NAME, PropertyValue = inputValue });
                SetCurrentConfigurationValueLabel(inputValue);
                MessageBox.Show("La actualización se realizó correctamente");
            }
            catch(BadRequestException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch(OperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
