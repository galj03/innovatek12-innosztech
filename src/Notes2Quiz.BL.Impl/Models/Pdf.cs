using Notes2Quiz.BL.Models;

namespace Notes2Quiz.BL.Impl.Models
{
    internal class Pdf : IPdf
    {
        #region Properties
        public string Name { get; }
        public byte[] Data { get; }
        #endregion

        #region ctor
        public Pdf(string name, byte[] data)
        {
            Name = name;
            Data = data;
        }
        #endregion
    }
}
