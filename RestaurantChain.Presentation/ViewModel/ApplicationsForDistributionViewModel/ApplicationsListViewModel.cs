using RestaurantChain.Domain.Models.View;
using RestaurantChain.DomainServices.Contracts;
using RestaurantChain.Presentation.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Presentation.ViewModel.ApplicationsForDistributionViewModel
{
    internal class ApplicationsListViewModel : ListViewModelBase<ApplicationsForDistributionView>
    {
        private readonly IApplicationsForDistributionService _applicationsForDistributionService;
        private readonly IRestaurantsService _restaurantsService;
        private readonly IProductsService _productsService;



        public ApplicationsListViewModel(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        protected override void DataBind()
        {
            throw new NotImplementedException();
        }

        protected override void SetCommands()
        {
            throw new NotImplementedException();
        }
    }
}
