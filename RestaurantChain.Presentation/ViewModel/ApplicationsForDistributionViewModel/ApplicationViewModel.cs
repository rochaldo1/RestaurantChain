using RestaurantChain.Presentation.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantChain.Presentation.ViewModel.ApplicationsForDistributionViewModel
{
    internal class ApplicationViewModel : EditViewModelBase
    {
        public ApplicationViewModel(int? currentId) : base(currentId)
        {

        }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
