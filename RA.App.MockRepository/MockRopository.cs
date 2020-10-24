using RA.App.Domain;
using System.Collections.Generic;

namespace RA.App.MockRepository {
    public abstract class MockRopository {
        protected readonly IEnumerable<Price> _priceData;
        protected readonly IEnumerable<Calculator> _calculatorData;

        public MockRopository() {
            _priceData = GetPriceData();
            _calculatorData = GetCalculatorData();
        }

        private IEnumerable<Price> GetPriceData() {
            return new List<Price> {
                new Price {
                    Id = 1,
                    FromDDDCode = 11,
                    ToDDDCode = 16,
                    PricePerMinute = 1.9m
                },
                new Price {
                    Id = 2,
                    FromDDDCode = 16,
                    ToDDDCode = 11,
                    PricePerMinute = 2.9m
                },
                new Price {
                    Id = 3,
                    FromDDDCode = 11,
                    ToDDDCode = 17,
                    PricePerMinute = 1.7m
                },
                new Price {
                    Id = 4,
                    FromDDDCode = 17,
                    ToDDDCode = 11,
                    PricePerMinute = 2.7m
                },
                new Price {
                    Id = 5,
                    FromDDDCode = 11,
                    ToDDDCode = 18,
                    PricePerMinute = 0.9m
                },
                new Price {
                    Id = 6,
                    FromDDDCode = 18,
                    ToDDDCode = 11,
                    PricePerMinute = 1.9m
                }
            };
        }

        private IEnumerable<Calculator> GetCalculatorData() {
            return new List<Calculator>();
        }
    }
}