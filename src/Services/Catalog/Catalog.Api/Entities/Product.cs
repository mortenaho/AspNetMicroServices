using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Catalog.Api.Entities;

public class Product
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    [BsonElement("Name")]
    public  string Name { set; get; }
    public  string Category { set; get; }
    public  string Summery { set; get; }
    public  string Description { set; get; }
    public  decimal Price { set; get; }
}