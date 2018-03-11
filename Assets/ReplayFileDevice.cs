using CommonTools;

namespace TestGame
{
    public class ReplayFileDevice : BaseHandMovementFileDevice
    {
        public override IHandData CreateHandMovementData()
        {
            return new HandCoordinates(new float[CommonConstants.SCALED_SESORS_ARRAY_LENGTH]);
        }

        public override string GetFileName()
        {
            return ConfigurationManager.Instance.Configuration.ReplayFilePath;
        }
    }
}