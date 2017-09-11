using System.Collections.Generic;
using VideoAppBLL.BO;

namespace VideoAppBLL
{
    public interface IRentalService
    {
        //C
        RentalBO Create(RentalBO rental);

        //R
        List<RentalBO> GetAll();

        RentalBO Get(int Id);

        //U
        RentalBO Update(RentalBO rental);

        //D
        RentalBO Delete(int Id);
    }
}
