namespace PayrollLite.Application.Common.Interfaces.Others;

public interface IMapFrom<T>
{
    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
}
