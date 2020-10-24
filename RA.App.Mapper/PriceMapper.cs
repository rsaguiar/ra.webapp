using AutoMapper;
using RA.App.Domain;
using RA.App.ViewModel;

namespace RA.App.Mapper {
    public static class PriceMapper {
        public static PriceViewModel ToPriceViewModel(this Price model) {
            IMapper mapper = PriceForPriceViewModelConfig().CreateMapper();
            return mapper.Map<PriceViewModel>(model);
        }

        public static Price ToEntity(this PriceViewModel viewModel) {
            IMapper mapper = PriceForPriceViewModelConfig().CreateMapper();
            return mapper.Map<Price>(viewModel);
        }

        private static MapperConfiguration PriceForPriceViewModelConfig() {
            return new MapperConfiguration(m => {
                m.CreateMap<Price, PriceViewModel>();
                m.CreateMap<PriceViewModel, Price>();
            });
        }
    }
}
