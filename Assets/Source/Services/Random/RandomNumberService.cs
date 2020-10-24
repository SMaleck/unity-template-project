namespace Source.Services.Random
{
    public class RandomNumberService : IRandomNumberService
    {
        /// <summary>
        /// Return a random integer between minInclusive and maxExclusive
        /// </summary>
        /// <param name="minInclusive"></param>
        /// <param name="maxExclusive"></param>
        /// <returns></returns>
        public int Range(int minInclusive, int maxExclusive)
        {
            return UnityEngine.Random.Range(minInclusive, maxExclusive);
        }

        /// <summary>
        /// Return a random float between minInclusive and maxExclusive
        /// </summary>
        /// <param name="minInclusive"></param>
        /// <param name="maxExclusive"></param>
        /// <returns></returns>
        public float Range(float minInclusive, float maxExclusive)
        {
            return UnityEngine.Random.Range(minInclusive, maxExclusive);
        }

        /// <summary>
        /// Return a random double between minInclusive and maxExclusive
        /// </summary>
        /// <param name="minInclusive"></param>
        /// <param name="maxExclusive"></param>
        /// <returns></returns>
        public double Range(double minInclusive, double maxExclusive)
        {
            return UnityEngine.Random.Range((float)minInclusive, (float)maxExclusive);
        }
    }
}
