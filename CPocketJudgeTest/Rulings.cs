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
        /*
        {
          "object": "list",
          "has_more": false,
          "data": [
            {
              "object": "ruling",
              "oracle_id": "ef10c6c6-8e84-46f6-8e11-cd35a2b8fbf1",
              "source": "wotc",
              "published_at": "2018-01-19",
              "comment": "You activate X's first activated ability while X is on the battlefield under your control. This puts X into an opponent's hand. That opponent plays with their hand revealed, and they're not allowed to cast X or activate any of X's abilities-but you are. You can activate X's second ability to play one of the cards in that hand."
            },
            {
              "object": "ruling",
              "oracle_id": "ef10c6c6-8e84-46f6-8e11-cd35a2b8fbf1",
              "source": "wotc",
              "published_at": "2018-01-19",
              "comment": "You choose which card to play as X's last ability resolves. Your opponent can respond to you activating the ability to get other cards out of their hand. Whatever's left when the ability resolves is fair game."
            },
            {
              "object": "ruling",
              "oracle_id": "ef10c6c6-8e84-46f6-8e11-cd35a2b8fbf1",
              "source": "wotc",
              "published_at": "2018-01-19",
              "comment": "You play the card as X's last ability resolves, with one exception: You can't play a land this way unless it's your turn and you have an available land play. If you're casting a spell this way, you do so as the ability resolves. Ignore any timing restrictions based on the card's type. You can cast their sorceries or creatures during their turn, for example."
            },
            {
              "object": "ruling",
              "oracle_id": "ef10c6c6-8e84-46f6-8e11-cd35a2b8fbf1",
              "source": "wotc",
              "published_at": "2018-01-19",
              "comment": "You don't own the cards you play this way. An instant or sorcery cast this way will go to its owner's graveyard. A creature card you cast this way will enter the battlefield under your control, but it will be put into its owner's graveyard if it dies. The same is true for other permanent cards you cast or lands you play."
            }
          ]
        } 
        */

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
