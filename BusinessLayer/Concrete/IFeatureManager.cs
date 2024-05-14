using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class IFeatureManager : IFeatureService
	{
		private readonly IFeatureDal _featureDal;

		public IFeatureManager(IFeatureDal featureDal)
		{
			_featureDal = featureDal;
		}

		public void TAdd(Feature entity)
		{
			_featureDal.Add(entity);
		}

		public void TDelete(Feature entity)
		{
			_featureDal.Delete(entity);
		}

		public Feature TGetById(int id)
		{
			return _featureDal.GetById(id);	
		}

		public List<Feature> TGetList()
		{
			return _featureDal.GetList();
		}

		public void TUpdate(Feature entity)
		{
			_featureDal.Update(entity);
		}
	}
}
