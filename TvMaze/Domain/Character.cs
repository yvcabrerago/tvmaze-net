﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace TvMaze.Domain {
    public class Character {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public IDictionary<ImageType, string> Image;
        [JsonProperty(PropertyName = "_links")]
        public IDictionary<LinkType, Link> Links { get; set; }
    }
}
