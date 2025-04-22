using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge_Odontoprev_API.Models;

public class Endereco
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("cep")]
    public string Cep { get; set; }

    [BsonElement("logradouro")]
    public string Logradouro { get; set; }

    [BsonElement("numero")]
    public string Numero { get; set; }

    [BsonElement("complemento")]
    public string Complemento { get; set; }

    [BsonElement("bairro")]
    public string Bairro { get; set; }

    [BsonElement("cidade")]
    public string Cidade { get; set; }

    [BsonElement("estado")]
    public string Estado { get; set; }

    [BsonElement("cep")]
    public string Cep {get; set;}
}