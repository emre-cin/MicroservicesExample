﻿using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Example.Services.Catalog.Domain.Models.Dtos
{
    public class FeatureDto : BaseDto
    {
        public int Duration { get; set; }

        [BsonRepresentation(BsonType.Boolean)]
        public bool IsDownloadable { get; set; }
    }
}
