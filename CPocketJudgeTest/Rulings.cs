using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CPocketJudgeTest
{
    /// <summary>
    /// Class that contains rulings of a Magic: The Gathering(c) card.
    /// </summary>
    public partial class Rulings
    {
        public Datum[] data { get; set; }

    }

    public partial class Datum
    {
        public Guid oracle_id { get; set; }

        public string source { get; set; }

        public DateTimeOffset published_at { get; set; }

        public string comment { get; set; }
    }

}
