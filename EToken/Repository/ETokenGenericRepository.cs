using EToken.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EToken.Repository
{
    public class ETokenGenericRepository<AnyType> : IDisposable where AnyType : class
    {


        // Creating object like below, because it solves the dependency injection problem
        //For More details :https://github.com/aspnet/EntityFrameworkCore/issues/6493




        ETokenDBContext OBJApplicationDbContext;
        public ETokenGenericRepository(ETokenDBContext OBJETokenDBContext)
        {
            OBJApplicationDbContext = OBJETokenDBContext;
        }



        //This method used to dispose the DBContext object

        public void Dispose()
        {
            OBJApplicationDbContext.Dispose();
        }



        public async Task AddAnyTpyeAsync(AnyType invObjAnyType)
        {

            // string rpDataChangerLoginID = "DataChangerLoginID";
            string rpDateDataChanged = "DateDataChanged";
            if (invObjAnyType.GetType().GetProperty(rpDateDataChanged) != null)
            {

                invObjAnyType.GetType().GetProperty(rpDateDataChanged).SetValue(invObjAnyType, DateTime.Now, null);
            }





            if (invObjAnyType == null)
            {
                throw new ArgumentNullException("entity");
            }

            OBJApplicationDbContext.Set<AnyType>().Add(invObjAnyType);



            await OBJApplicationDbContext.SaveChangesAsync();

        }



        public async Task<int> GetTotalCountForAnyTypeListAsync()
        {


            int TotalCount = 0;
            IQueryable<AnyType> AnyTypeList = OBJApplicationDbContext.Set<AnyType>();

            if (AnyTypeList != null)
            {
                TotalCount = await AnyTypeList.CountAsync();
            }


            return TotalCount;

        } // end of method GetTotalCountForEntity()



    }  // End of EtokenGenericRepository

      


        


}
