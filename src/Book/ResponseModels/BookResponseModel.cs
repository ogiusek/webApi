namespace WebApi.Book.ResponseModels;

public class BookResponseModel
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public BookResponseModel(int id, string name) => (Id, Name) = (id, name);
}