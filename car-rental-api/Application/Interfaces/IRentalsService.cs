namespace car_rental_api.Application.Interfaces
{
    public interface IRentalsService
    {
        Task<bool> IsCarAvailableAsync(int carId, DateTime startDate, DateTime endDate);
    }
}
