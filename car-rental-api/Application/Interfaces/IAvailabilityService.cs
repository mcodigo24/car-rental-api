namespace car_rental_api.Application.Interfaces
{
    public interface IAvailabilityService
    {
        Task<bool> IsCarAvailableAsync(int carId, DateTime startDate, DateTime endDate, int? rentalId = null);
    }
}
