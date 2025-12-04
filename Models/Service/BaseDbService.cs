using EF_Core.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EF_Core.Models.Service
{
    public class BaseDbService
    {
        private AppDbContext context;
        public AppDbContext Context => context;
        private BaseDbService() 
        { 
            context=new AppDbContext();
        }

        private static BaseDbService? instance;

        public static BaseDbService Instance
        {
            get
            {
                if (instance == null) instance=new BaseDbService();
                return instance;
            }
        }

    }
}
