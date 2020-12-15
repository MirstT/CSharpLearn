namespace _2048
{
    //test
    internal struct Location
    {
        public int Rindex { get; set; }
        public int CIndex { get; set; }

        public Location(int rIndex, int cIndex) : this()
        {
            this.Rindex = rIndex;
            this.CIndex = cIndex;
        }
    }
}