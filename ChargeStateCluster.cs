namespace MS1_DataSimulator
{
    internal class ChargeStateIsotopeCluster
    {
        public readonly double firstMzValue;
        public readonly double mzSpacing;
        public readonly int peakCount;
        public readonly int chargeState;
        public readonly (double[], double[]) unitSpectrum;

        public ChargeStateIsotopeCluster((double[], double[]) spectrum, int charge)
        {
            this.firstMzValue = spectrum.Item1[0];
            if(spectrum.Item1.Length== 1 ) 
            {
                this.mzSpacing = 1.0 / (double)charge;
            } 
                else
            {
                this.mzSpacing = spectrum.Item1[1] - spectrum.Item1[0];
            }
            this.peakCount = spectrum.Item1.Length;
            this.unitSpectrum = spectrum;
        }
    }
}
