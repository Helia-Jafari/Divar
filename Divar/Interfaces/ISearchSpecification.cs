namespace Divar.Interfaces
{
    public interface ISearchSpecification<T>
    {
        IQueryable<T> ApplyFilter(IQueryable<T> query, string searchString);
    }
}
