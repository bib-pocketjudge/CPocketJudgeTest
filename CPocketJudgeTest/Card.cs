using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPocketJudgeTest
{
    /// <summary>
    /// Class that represents a Magic: The Gathering(c) card.
    /// </summary>
    class Card
    {
        /*
        {
          "object": "card",
          "id": "68c73755-9678-467a-abd5-f8dd1556864e",
          "oracle_id": "721eb5a2-d7cf-4db0-8013-ef3f596c52a5",
          "multiverse_ids": [
            442077
          ],
          "mtgo_id": 67090,
          "mtgo_foil_id": 67091,
          "tcgplayer_id": 161443,
          "name": "Doomsday",
          "lang": "en",
          "released_at": "2018-03-16",
          "uri": "https://api.scryfall.com/cards/68c73755-9678-467a-abd5-f8dd1556864e",
          "scryfall_uri": "https://scryfall.com/card/a25/88/doomsday?utm_source=api",
          "layout": "normal",
          "highres_image": true,
          "image_uris": {
            "small": "https://img.scryfall.com/cards/small/en/a25/88.jpg?1521726223",
            "normal": "https://img.scryfall.com/cards/normal/en/a25/88.jpg?1521726223",
            "large": "https://img.scryfall.com/cards/large/en/a25/88.jpg?1521726223",
            "png": "https://img.scryfall.com/cards/png/en/a25/88.png?1521726223",
            "art_crop": "https://img.scryfall.com/cards/art_crop/en/a25/88.jpg?1521726223",
            "border_crop": "https://img.scryfall.com/cards/border_crop/en/a25/88.jpg?1521726223"
          },
          "mana_cost": "{B}{B}{B}",
          "cmc": 3.0,
          "type_line": "Sorcery",
          "oracle_text": "Search your library and graveyard for five cards and exile the rest. Put the chosen cards on top of your library in any order. You lose half your life, rounded up.",
          "colors": [
            "B"
          ],
          "color_identity": [
            "B"
          ],
          "legalities": {
            "standard": "not_legal",
            "future": "not_legal",
            "frontier": "not_legal",
            "modern": "not_legal",
            "legacy": "legal",
            "pauper": "not_legal",
            "vintage": "legal",
            "penny": "not_legal",
            "commander": "legal",
            "duel": "legal",
            "oldschool": "not_legal"
          },
          "games": [
            "mtgo",
            "paper"
          ],
          "reserved": false,
          "foil": true,
          "nonfoil": true,
          "oversized": false,
          "promo": false,
          "reprint": true,
          "set": "a25",
          "set_name": "Masters 25",
          "set_uri": "https://api.scryfall.com/sets/41ee6e2f-69b3-4c53-8a8e-960f5e974cfc",
          "set_search_uri": "https://api.scryfall.com/cards/search?order=set&q=e%3Aa25&unique=prints",
          "scryfall_set_uri": "https://scryfall.com/sets/a25?utm_source=api",
          "rulings_uri": "https://api.scryfall.com/cards/68c73755-9678-467a-abd5-f8dd1556864e/rulings",
          "prints_search_uri": "https://api.scryfall.com/cards/search?order=released&q=oracleid%3A721eb5a2-d7cf-4db0-8013-ef3f596c52a5&unique=prints",
          "collector_number": "88",
          "digital": false,
          "rarity": "mythic",
          "watermark": "set",
          "illustration_id": "f7f9a52f-2ff7-48fd-802f-0a481b0c69fb",
          "artist": "Noah Bradley",
          "border_color": "black",
          "frame": "2015",
          "full_art": false,
          "story_spotlight": false,
          "edhrec_rank": 2875,
          "prices": {
            "usd": "2.25",
            "usd_foil": "9.77",
            "eur": "1.44",
            "tix": "0.56"
          },
          "related_uris": {
            "gatherer": "https://gatherer.wizards.com/Pages/Card/Details.aspx?multiverseid=442077",
            "tcgplayer_decks": "https://decks.tcgplayer.com/magic/deck/search?contains=Doomsday&page=1&partner=Scryfall&utm_campaign=affiliate&utm_medium=scryfall&utm_source=scryfall",
            "edhrec": "http://edhrec.com/route/?cc=Doomsday",
            "mtgtop8": "http://mtgtop8.com/search?MD_check=1&SB_check=1&cards=Doomsday"
          },
          "purchase_uris": {
            "tcgplayer": "https://shop.tcgplayer.com/magic/masters-25/doomsday?partner=Scryfall&utm_campaign=affiliate&utm_medium=scryfall&utm_source=scryfall",
            "cardmarket": "https://www.cardmarket.com/en/Magic/Products/Singles/Masters-25/Doomsday?referrer=scryfall&utm_campaign=card_prices&utm_medium=text&utm_source=scryfall",
            "cardhoarder": "https://www.cardhoarder.com/cards/67090?affiliate_id=scryfall&ref=card-profile&utm_campaign=affiliate&utm_medium=card&utm_source=scryfall"
          }
        }
        */

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
