namespace CustomCalculationServiceConnectionLib
{
    public interface IServiceConnection
    {
        object Request(CustomCalculationServiceRequest request);
        T Request<T>(CustomCalculationServiceRequest request);
    }
}
