namespace GameZone.Services
{
    public interface ICatgeoriesService
    {
        IEnumerable<SelectListItem> GetSelectList();
    }
}
