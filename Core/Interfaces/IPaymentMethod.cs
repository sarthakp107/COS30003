using AWEElectronicsBlazorApp.Core.Models;

namespace AWEElectronicsBlazorApp.Core.Interfaces
{
  public interface IPaymentMethod
    {
        string Name { get; }
        bool ProcessPayment(decimal amount); 
    }
}