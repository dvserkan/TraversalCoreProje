﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class IDestinationManager : IDestinationService
	{
		private readonly IDestinationDal _destinationDal;

		public IDestinationManager(IDestinationDal destinationDal)
		{
			_destinationDal = destinationDal;
		}

		public void TAdd(Destination entity)
		{
			_destinationDal.Add(entity);
		}

		public void TDelete(Destination entity)
		{
			_destinationDal.Delete(entity);
		}

		public Destination TGetById(int id)
		{
			return _destinationDal.GetById(id);
		}

        public Destination TGetDestinationWithGuide(int id)
        {
            return _destinationDal.GetDestinationWithGuide(id);
        }

        public List<Destination> TGetLast4Destinations()
        {
            return _destinationDal.GetLast4Destinations();
        }

        public List<Destination> TGetList()
		{
			return _destinationDal.GetList();
		}

		public void TUpdate(Destination entity)
		{
			_destinationDal.Update(entity);
		}
	}
}
