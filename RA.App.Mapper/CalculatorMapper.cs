using AutoMapper;
using RA.App.Domain;
using RA.App.ViewModel;

namespace RA.App.Mapper {
    public static class CalculatorMapper {
        public static CalculatorViewModel ToCalculatorViewModel(this Calculator model) {
            IMapper mapper = CalculatorForCalculatorViewModelConfig().CreateMapper();
            return mapper.Map<CalculatorViewModel>(model);
        }

        public static Calculator ToEntity(this CalculatorViewModel viewModel) {
            IMapper mapper = CalculatorForCalculatorViewModelConfig().CreateMapper();
            return mapper.Map<Calculator>(viewModel);
        }

        private static MapperConfiguration CalculatorForCalculatorViewModelConfig() {
            return new MapperConfiguration(m => {
                m.CreateMap<Calculator, CalculatorViewModel>();
                m.CreateMap<CalculatorViewModel, Calculator>();
            });
        }
    }
}
