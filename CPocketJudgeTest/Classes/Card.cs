using System;

namespace CPocketJudgeTest
{
    /// <summary>
    /// Class that represents a Magic: The Gathering(c) card.
    /// </summary>
    public class Card
    {
        public string oracle_id { get; set; }
        public string name { get; set; }
        public imgUris image_uris { get; set; }
        public string mana_cost { get; set; }
        public float cmc { get; set; }
        public string type_line { get; set; }
        public string oracle_text { get; set; }
        public Uri rulings_uri { get; set; }

        /// <summary>
        /// Class that contains urls to different pictures of a Magic: The Gathering(c) card.
        /// </summary>
        public class imgUris
        {
            public string small { get; set; }
            public string normal { get; set; }
            public string large { get; set; }
            public string png { get; set; }
            public string art_crop { get; set; }
            public string border_crop { get; set; }

        }
    }
}
