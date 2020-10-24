using System;
using System.Collections.Generic;
using System.Text;

namespace RA.App.Exception {
    public class CalculatorServiceException : AppException {
        public CalculatorServiceException(string message) : base(message) {
        }

        public CalculatorServiceException(string message, System.Exception innerException) : base(message, innerException) {
        }

        public CalculatorServiceException(System.Exception innerException) : base("Failed to process the service.", innerException) {
        }
    }
}
