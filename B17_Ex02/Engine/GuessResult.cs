namespace B17_Ex02
{
    class GuessResult
    {
        // a symbol that appears in the same sequence location
        int m_BulHits = 0;
        // a symbol that appears in the sequence but not in the same location
        int m_PgiyaHits = 0;

        public int BulHits { get => m_BulHits; set => m_BulHits = value; }
        public int PgiyaHits { get => m_PgiyaHits; set => m_PgiyaHits = value; }
    }
}
