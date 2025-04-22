namespace Challenge_Odontoprev_API.Repositories;

public class MongoEnderecoRepository
{
    private readonly IMongoCollection<Endereco> _enderecos;

    public MongoEnderecoRepository(IMongoDatabase database)
    {
        var client = new MongoClient(configuration.GetConnectionString("MongoConnection"));
        var database = client.GetDatabase("Mongo_OdontoCare");
        _enderecos = database.GetCollection<Endereco>("Enderecos");
    }

    public async Task<IEnumerable<Endereco>> GetAllAsync()
    {
        return await _enderecos.Find(_ => true).ToListAsync();
    }

    public async Task<Endereco> GetByIdAsync(string id)
    {
        return await _enderecos.Find(e => e.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Endereco> CreateAsync(Endereco endereco)
    {
        await _enderecos.InsertOneAsync(endereco);
        return endereco;
    }

    public async Task UpdateAsync(Endereco endereco)
    {
        await _enderecos.ReplaceOneAsync(e => e.Id == endereco.Id, endereco);
    }

    public async Task DeleteAsync(string id)
    {
        await _enderecos.DeleteOneAsync(e => e.Id == id);
    }
}