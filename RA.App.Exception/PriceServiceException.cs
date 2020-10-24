namespace RA.App.Exception {
    public class PriceServiceException : AppException {
        public PriceServiceException(string message) : base(message) {
        }

        public PriceServiceException(string message, System.Exception innerException) : base(message, innerException) {
        }

        public PriceServiceException(System.Exception innerException) : base("Failed to process the service.", innerException) {
        }
    }
}
