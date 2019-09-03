using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PaymentApi.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }
        public string Address { get; set; }
        public int Phone { get; set;  }
        public int LeaseDuration { get; set; }
        public DateTime LastPaymentDate { get; set;  }
        public string Email { get; set; }
        public int Balance { get; set; }
    }
}
