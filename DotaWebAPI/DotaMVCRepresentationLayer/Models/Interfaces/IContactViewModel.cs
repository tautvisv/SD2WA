namespace DotaMVCRepresentationLayer.Models.Interfaces
{
    public interface IContactViewModel:IModelView
    {
        IContactModel ContactData { get; set; }
        string Title { get; set; }
        string Message { get; set; }
        string Support { get; set; }
    }
}