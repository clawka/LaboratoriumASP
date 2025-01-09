namespace WebApp.Models.Services;

public interface IContactService
{
    int Add(ContactModel book);
    void Delete(int id);
    void Update(ContactModel book);
    List<ContactModel> FindAll();
    ContactModel? FindById(int id);
}